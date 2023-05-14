using CCSVSystem.Models;
using CCSVSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CCSVSystem.Controllers
{
    public class ProveedoresController : Controller
    {
        private readonly API_Interface _api;
        private static string _baseurl;

        public ProveedoresController(API_Interface api)
        {
            _api = api;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                List<Proveedor> registros = await _api.ObtenerProveedores();
                ViewBag.UrlAPI = new Uri(_baseurl)+"Proveedor/EliminarProveedor/";
                if (registros != null)
                {
                    return View(registros);
                }
                else
                {
                    TempData["msjSinRegistros"] = "No hay proveedores registrados en el sistema.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Algo salió mal.., reintente.";
                return View();

            }

        }
        public async Task<IActionResult> VerProveedorModal(string idProveedor)
        {
            Proveedor obj = await _api.ObtenerProveedor(idProveedor);

            return PartialView("VerProveedorModal", obj);
        }
        public async Task<IActionResult> NuevoProveedorModal()
        {
            Proveedor obj = new Proveedor();

            return PartialView("NuevoProveedorModal", obj);
        }

        public async Task<IActionResult> GuardarProveedor(Proveedor o)
        {
            bool resultado = false;
            if (ModelState.IsValid)
            {
                resultado = await _api.GuardarProveedor(o);
                TempData["resultado"] = resultado;
                if (resultado == true)
                {
                    return Json(new { success = true, responseText = "OK" });
                }
                else
                {
                    TempData["mensajeResultado"] = "Algo salió mal, vuelva a intentarlo";
                    throw new Exception("Algo salió mal, vuelva a intentarlo.");
                }
            }
            return PartialView("NuevoProveedorModal", o);
        }

        public async Task<IActionResult> EditarProveedorModal(string idProveedor)
        {
            Proveedor obj = await _api.ObtenerProveedor(idProveedor);

            return PartialView("EditarProveedorModal", obj);
        }

        public async Task<IActionResult> GuardarCambiosProveedor(Proveedor o)
        {
            o.comentarios = o.comentarios == null ? "" : o.comentarios;
            o.contactoProveedor = o.contactoProveedor == null ? "" : o.contactoProveedor;
            bool resultado = false;
            if (ModelState.IsValid)
            {
                resultado = await _api.EditarProveedor(o);
                TempData["resultado"] = resultado;
                if (resultado == true)
                {
                    return Json(new { success = true, responseText = "OK" });
                }
                else
                {
                    TempData["mensajeResultado"] = "Algo salió mal, vuelva a intentarlo";
                    throw new Exception("Algo salió mal, vuelva a intentarlo.");
                }
            }
            return PartialView("EditarProveedorModal", o);
        }

        public async Task<IActionResult> EliminarProveedor(string idProveedor)
        {

            var resultado = await _api.EliminarProveedor(idProveedor);
            TempData["resultado"] = resultado;
            if (resultado)
            {

                TempData["mensajeResultado"] = "¡Empleado Eliminado Exitosamente!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["mensajeResultado"] = "¡Algo salió mal";
                return RedirectToAction("Index");
            }
        }
    }
}
