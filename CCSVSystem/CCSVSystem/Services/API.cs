using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using CCSVSystem.Models;
using System;
using System.Diagnostics;

namespace CCSVSystem.Services
{
    public class API : API_Interface
    {
        private static string _baseurl;

        public API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        #region Proveedores
        public async Task<List<Proveedor>> ObtenerProveedores()
        {
            List<Proveedor> lista = new List<Proveedor>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync("Proveedor/ObtenerProveedores");
            if (response.IsSuccessStatusCode)
            {
                var json_repuesta = await response.Content.ReadAsStringAsync();
                var parsedObject = JObject.Parse(json_repuesta);
                var obj = parsedObject["response"].ToString();
                var resultado = JsonConvert.DeserializeObject<List<Proveedor>>(obj);
                lista.AddRange(resultado);
            }
            return lista;
        }

        public async Task<Proveedor> ObtenerProveedor(string id)
        {
            Proveedor objeto = new Proveedor();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"Proveedor/ObtenerProveedor/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json_repuesta = await response.Content.ReadAsStringAsync();
                var parsedObject = JObject.Parse(json_repuesta);
                var obj = parsedObject["response"].ToString();
                var resultado = JsonConvert.DeserializeObject<Proveedor>(obj);
                objeto = resultado;
            }
            return objeto;
        }
        public async Task<bool> GuardarProveedor(Proveedor registro)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"Proveedor/GuardarProveedor", content);

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<bool> EditarProveedor(Proveedor registro)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"Proveedor/EditarProveedor", content);

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<bool> EliminarProveedor(string id)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.DeleteAsync($"Proveedor/EliminarProveedor/{id}");

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }
        #endregion
    }
}
