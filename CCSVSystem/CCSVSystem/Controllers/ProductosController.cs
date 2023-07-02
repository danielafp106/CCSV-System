using CCSVSystem.Models;
using CCSVSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCSVSystem.Controllers
{
    public class ProductosController : Controller
    {
        private readonly API_Interface _api;
        private static string _baseurl;

        public ProductosController(API_Interface api)
        {
            _api = api;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        public async Task<IActionResult> AgregarProducto(string idPedido)
        {
            ViewBag.check = "false";
            ViewBag.prods = await _api.ObtenerProductos();
            PrecioProducto obj = new PrecioProducto();
            obj.idPedido = idPedido;
            obj.compraTotalProducto = 0;
            List<Marca> modelos = await _api.ObtenerMarcas();
            ViewBag.modelos = modelos;
            return PartialView("AgregarProducto", obj);
        }

        public async Task<IActionResult> GuardarProducto(PrecioProducto o)
        {
            bool resultadoP = false;
            bool resultado = false;
            if (ModelState.IsValid)
            {
                o.importacion = 0;
                o.paqueteria = 0;
                o.tarifaEnvio = 0;
                o.ganancia = 0;
                o.stockTotalRealTime = o.stockTotalComprado;
                o.precioPublico = 0;
                o.idPrecioProducto = 0;

                if(o.idProducto=="ID" && o.producto.nombreProducto!="ID" && o.producto.urlImagenProducto!="ID" && o.producto.urlProductoProveedor != "ID")
                {
                    resultadoP = await _api.GuardarProducto(o.producto);
                    if (resultadoP != true)
                    {
                        return Json(new { success = false, responseText = "Algo salió mal, vuelva a intentarlo más tarde." });
                    }
                    else
                    {
                        List<Producto> Prods = await _api.ObtenerProductos();
                        Producto newP = Prods.Where(p=>p.nombreProducto==o.producto.nombreProducto).FirstOrDefault();
                        o.idProducto = newP.idProducto;
                        o.producto = null;
                    }
                }
                if(resultadoP || o.productoRegistrado)
                {
                    resultado = await _api.GuardarPrecioProducto(o);
                    if (resultado == true)
                    {
                        return Json(new { success = true, responseText = "OK" });
                    }
                    else
                    {
                        return Json(new { success = false, responseText = "Algo salió mal, vuelva a intentarlo más tarde." });
                    }
                }              
                
            }
            ViewBag.check = o.productoRegistrado ? "true" : "false";
            ViewBag.prods = await _api.ObtenerProductos();
            return PartialView("AgregarProducto", o);
        }
    }
}
