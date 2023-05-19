using CCSVSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCSVSystem.Controllers
{
    public class CortesController : Controller
    {
        private readonly API_Interface _api;
        private static string _baseurl;

        public CortesController(API_Interface api)
        {
            _api = api;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
