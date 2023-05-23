using CCSVSystem.Models;
using CCSVSystem.Services;
using Microsoft.AspNetCore.Mvc;

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
                List<Pedido> registros = await _api.ObtenerPedidos();
    
                ViewBag.UrlAPI = new Uri(_baseurl) + "Pedido/EliminarPedido/";
                ViewBag.UrlAPIPP = new Uri(_baseurl) + "PrecioPedido/EliminarPrecioPedido/";
                if (registros != null)
                {
                    return View(registros);
                }
                else
                {
                    TempData["msjSinRegistros"] = "No hay paqueterias registrados en el sistema.";
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
    }
}
