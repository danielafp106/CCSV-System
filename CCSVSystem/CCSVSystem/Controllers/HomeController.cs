using CCSVSystem.Models;
using CCSVSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace CCSVSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly API_Interface _api;

        public HomeController(API_Interface api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            //Proveedor ps = await _api.ObtenerProveedor("PVD0000002");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}