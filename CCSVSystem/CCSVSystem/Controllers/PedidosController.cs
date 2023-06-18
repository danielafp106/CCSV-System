using CCSVSystem.Models;
using CCSVSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CCSVSystem.Controllers
{
    public class PedidosController : Controller
    {
        private readonly API_Interface _api;
        private static string _baseurl;

        public PedidosController(API_Interface api)
        {
            _api = api;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                List<Producto> prods = await _api.ObtenerProductos();
                List<Pedido> registros = await _api.ObtenerPedidos();
                registros = registros.OrderByDescending(p => p.fechaOrdenado).ToList();
                foreach(var r in registros)
                {
                    foreach(var p in r.PreciosProductos)
                    {
                        p.producto = prods.Where(pr => pr.idProducto == p.idProducto).FirstOrDefault();
                    }
                }

                ViewBag.UrlAPI = new Uri(_baseurl) + "Pedido/EliminarPedido/";
                ViewBag.UrlAPIPP = new Uri(_baseurl) + "PrecioProducto/EliminarPrecioProducto/";
                if (registros != null)
                {
                    return View(registros);
                }
                else
                {
                    TempData["msjSinRegistros"] = "No hay pedidos registrados en el sistema.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Algo salió mal.., reintente.";
                return View();

            }
            return View();
        }

        public async Task<IActionResult> NuevoPedidoModal()
        {
            Pedido obj = new Pedido();
            obj.stockPedido = 0;
            obj.totalImportePedido = 0;
            obj.totalPedido = 0;
            obj.totalProductosPedido = 0;
            obj.fechaRecibido = new DateTime(2000, 01, 01);
            List<Proveedor> provs = await _api.ObtenerProveedores();

            ViewBag.provs = provs.OrderBy(p => p.nombreProveedor);

            return PartialView("NuevoPedidoModal", obj);
        }

        public async Task<IActionResult> GuardarPedido(Pedido o)
        {
            bool resultado = false;
            if (ModelState.IsValid)
            {
                resultado = await _api.GuardarPedido(o);
                TempData["resultado"] = resultado;
                if (resultado == true)
                {
                    return Json(new { success = true, responseText = "OK" });
                }
                else
                {
                    return Json(new { success = false, responseText = "Algo salió mal, vuelva a intentarlo más tarde." });
                }
            }
            List<Proveedor> provs = await _api.ObtenerProveedores();
            ViewBag.provs = provs.OrderBy(p => p.nombreProveedor);
            return PartialView("NuevoPedidoModal", o);
        }

        public async Task<IActionResult> CalcularImportacion(string idPedido)
        {
            Pedido obj = new Pedido();        
            obj.totalImportePedido = 0;
            obj.idPedido = idPedido;


            return PartialView("CalcularImportacion", obj);
        }

        public async Task<IActionResult> GuardarImportacion(Pedido o)
        {
            bool resultado = false;
            if (o.idPedido != null && o.idPedido != "" && o.totalImportePedido != null && o.totalImportePedido != 0)
            {
                resultado = await _api.CalcularImportacion(o);
                TempData["resultado"] = resultado;
                if (resultado == true)
                {
                    return Json(new { success = true, responseText = "OK" });
                }
                else
                {
                    return Json(new { success = false, responseText = "Algo salió mal, vuelva a intentarlo más tarde." });
                }
            }
            else
            {
                if (o.totalImportePedido == 0)
                {
                    ModelState.AddModelError(nameof(o.totalImportePedido), "El importe debe ser diferente de $0.00");
                }            
            }
            return PartialView("CalcularImportacion", o);
        }
    }
}
