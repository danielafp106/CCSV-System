using CCSVSystem.Models;
using CCSVSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCSVSystem.Controllers
{
    public class PaqueteriaController : Controller
    {
        private readonly API_Interface _api;
        private static string _baseurl;

        public PaqueteriaController(API_Interface api)
        {
            _api = api;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                List<Paqueteria> registros = await _api.ObtenerPaqueterias();

                //Ordenando stocks
                foreach (var registro in registros)
                {                  
                    List<PrecioPaqueteria> aux = registro.preciosPaqueteria.ToList();
                    if (aux.Count != 0)
                    {
                        //ordenando
                        registro.preciosPaqueteria = aux.OrderByDescending(p => p.fechaCompra).ToList();
                        //esta en uso?
                        bool estaEnUso = aux.Where(p => p.esPaqueteriaRecurrente == true).Select(p => p.esPaqueteriaRecurrente).FirstOrDefault();
                        registro.enUso = estaEnUso ? "A" : "Z";
                    }
                    else
                    {
                        registro.enUso = "Z";
                    }
                }

                registros = registros.OrderBy(p => p.enUso).ThenBy(p=>p.nombrePaqueteria).ToList();

                ViewBag.UrlAPI = new Uri(_baseurl) + "Paqueteria/EliminarPaqueteria/";
                ViewBag.UrlAPIPP = new Uri(_baseurl) + "PrecioPaqueteria/EliminarPrecioPaqueteria/";
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

        }

        public async Task<IActionResult> NuevaPaqueteriaModal()
        {
            Paqueteria obj = new Paqueteria();
            List<Proveedor> provs = await _api.ObtenerProveedores();
            ViewBag.provs = provs.OrderBy(p => p.nombreProveedor);

            return PartialView("NuevaPaqueteriaModal", obj);
        }

        public async Task<IActionResult> GuardarPaqueteria(Paqueteria o)
        {
            bool resultado = false;
            if (ModelState.IsValid)
            {
                resultado = await _api.GuardarPaqueteria(o);
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
            return PartialView("NuevaPaqueteriaModal", o);
        }

        public async Task<IActionResult> EditarPaqueteriaModal(string idPaqueteria)
        {
            Paqueteria obj = await _api.ObtenerPaqueteria(idPaqueteria);
            List<Proveedor> provs = await _api.ObtenerProveedores();
            ViewBag.provs = provs.OrderBy(p => p.nombreProveedor);

            return PartialView("EditarPaqueteriaModal", obj);
        }

        public async Task<IActionResult> GuardarCambiosPaqueteria(Paqueteria o)
        {
            bool resultado = false;
            if (ModelState.IsValid)
            {
                resultado = await _api.EditarPaqueteria(o);
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
            return PartialView("NuevaPaqueteriaModal", o);
        }

        public async Task<IActionResult> EliminarPaqueteria(string idPaqueteria)
        {
            var resultado = await _api.EliminarPaqueteria(idPaqueteria);
            if (resultado)
            {

                return Json(new { success = true, responseText = "OK" });
            }
            else
            {
                return Json(new { success = false, responseText = "Algo salió mal, vuelva a intentarlo más tarde." });
            }
        }

        public async Task<IActionResult> NuevoPrecioPaqueteria(string idPaqueteria, string nombrePaqueteria)
        {
            PrecioPaqueteria obj = new PrecioPaqueteria();
            obj.precioUnidadPaqueteria = 0;
            obj.idPaqueteria = idPaqueteria;
            obj.fechaFinUso = new DateTime(2000, 01, 01);
            ViewBag.nombrePaqueteria = nombrePaqueteria;

            return PartialView("NuevoPrecioPaqueteria", obj);
        }

        public async Task<IActionResult> GuardarPrecioPaqueteria(PrecioPaqueteria o)
        {
            bool resultado = false;
            if (ModelState.IsValid)
            {
                resultado = await _api.GuardarPrecioPaqueteria(o);
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
            Paqueteria paq = await _api.ObtenerPaqueteria(o.idPaqueteria);
            ViewBag.nombrePaqueteria = paq.nombrePaqueteria;
            return PartialView("NuevoPrecioPaqueteria", o);
        }

        public async Task<IActionResult> EditarPrecioPaqueteria(int idPrecioPaqueteria, string nombrePaqueteria)
        {
            PrecioPaqueteria obj = await _api.ObtenerPrecioPaqueteria(idPrecioPaqueteria);
            ViewBag.nombrePaqueteria = nombrePaqueteria;

            return PartialView("EditarPrecioPaqueteria", obj);
        }

        public async Task<IActionResult> GuardarCambiosPrecioPaqueteria(PrecioPaqueteria o)
        {
            bool resultado = false;
            if (ModelState.IsValid)
            {
                resultado = await _api.EditarPrecioPaqueteria(o);
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
            Paqueteria paq = await _api.ObtenerPaqueteria(o.idPaqueteria);
            ViewBag.nombrePaqueteria = paq.nombrePaqueteria;
            return PartialView("NuevoPrecioPaqueteria", o);
        }

        public async Task<IActionResult> TerminarStock(int idPrecioPaqueteria, string nombrePaqueteria, string idPaqueteria)
        {    
            PrecioPaqueteria obj = new PrecioPaqueteria();
            obj.idPaqueteria = idPaqueteria;
            obj.idPrecioPaqueteria = idPrecioPaqueteria;
            obj.fechaFinUso = DateTime.Today;
            ViewBag.nombrePaqueteria = nombrePaqueteria;

            return PartialView("TerminarStock", obj);
        }

        public async Task<IActionResult> GuardarTerminarStock(PrecioPaqueteria o)
        {
            o.esPaqueteriaRecurrente = false;
            bool resultado = false;
            if (o.idPrecioPaqueteria !=0 && o.fechaFinUso.HasValue && o.fechaFinUso != new DateTime(2000, 01, 01))
            {
                resultado = await _api.EditarPrecioPaqueteria(o);
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
            Paqueteria paq = await _api.ObtenerPaqueteria(o.idPaqueteria);
            ViewBag.nombrePaqueteria = paq.nombrePaqueteria;
            return PartialView("TerminarStock", o);
        }

        public async Task<IActionResult> EmpezarStock(int idPrecioPaqueteria, string nombrePaqueteria, string idPaqueteria)
        {
            PrecioPaqueteria obj = new PrecioPaqueteria();
            obj.idPaqueteria = idPaqueteria;
            obj.idPrecioPaqueteria = idPrecioPaqueteria;
            obj.fechaInicioUso = DateTime.Today;
            ViewBag.nombrePaqueteria = nombrePaqueteria;

            return PartialView("EmpezarStock", obj);
        }

        public async Task<IActionResult> GuardarEmpezarStock(PrecioPaqueteria o)
        {
            bool resultado = false;
            if (o.idPrecioPaqueteria != 0 && o.fechaInicioUso.HasValue && o.fechaInicioUso != new DateTime(2000, 01, 01))
            {
                resultado = await _api.EditarPrecioPaqueteria(o);
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
            Paqueteria paq = await _api.ObtenerPaqueteria(o.idPaqueteria);
            ViewBag.nombrePaqueteria = paq.nombrePaqueteria;
            return PartialView("EmpezarStock", o);
        }
    }
}
