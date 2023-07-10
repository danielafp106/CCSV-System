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
            obj.stockTotalComprado = 0; 
            List<Marca> modelos = await _api.ObtenerMarcas();
            ViewBag.modelos = modelos;
            return PartialView("AgregarProducto", obj);
        }

        public async Task<IActionResult> GuardarProducto(PrecioProducto o)
        {
            bool resultadoP = false;
            bool resultado = false;
            if (ModelState.IsValid && o.detalleProductosModelos.Count!=0)
            {
                o.importacion = 0;
                o.paqueteria = 0;
                o.tarifaEnvio = 0;
                o.ganancia = 0;
                o.stockTotalRealTime = o.stockTotalComprado;
                o.precioPublico = 0;
                o.idPrecioProducto = 0;

                List<DetalleProductoModelo> allmodelosstock = o.detalleProductosModelos.ToList();
                o.detalleProductosModelos.Clear();

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
                        List<PrecioProducto> PPs = await _api.ObtenerPreciosProductos();
                        PrecioProducto nuevoPP = PPs.OrderByDescending(p=>p.idPrecioProducto).Where(p=>p.idProducto == o.idProducto).FirstOrDefault();
                        foreach(var modelo in allmodelosstock)
                        {
                            if(modelo.stockProductoModelo!=null && modelo.stockProductoModelo!=0 && modelo.idModelo!= null && modelo.idModelo != "")
                            {
                                modelo.idPrecioProducto = nuevoPP.idPrecioProducto;
                                modelo.stockRealTimeProductoModelo = modelo.stockProductoModelo;
                                bool resultadoM = false;
                                resultadoM = await _api.GuardarDetalleProductoModelo(modelo);
                                if (resultadoM != true)
                                {
                                    return Json(new { success = false, responseText = "Algo salió mal, vuelva a intentarlo más tarde." });
                                }
                            }                           
                        }
                        return Json(new { success = true, responseText = "OK" });
                    }
                    else
                    {
                        return Json(new { success = false, responseText = "Algo salió mal, vuelva a intentarlo más tarde." });
                    }
                }              
                
            }
            else
            {
                if(o.detalleProductosModelos.Count == 0)
                {

                    ModelState.AddModelError(nameof(o.stockTotalComprado), "Ingresar stock para este producto");
                }
            }
            ViewBag.check = o.productoRegistrado ? "true" : "false";
            ViewBag.prods = await _api.ObtenerProductos();
            ViewBag.modelos = await _api.ObtenerMarcas();
            return PartialView("AgregarProducto", o);
        }
    }
}
