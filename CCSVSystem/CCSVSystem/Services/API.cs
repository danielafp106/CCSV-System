﻿using Newtonsoft.Json;
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

        #region Paqueteria
        public async Task<List<Paqueteria>> ObtenerPaqueterias()
        {
            List<Paqueteria> lista = new List<Paqueteria>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync("Paqueteria/ObtenerPaqueterias");
            if (response.IsSuccessStatusCode)
            {
                var json_repuesta = await response.Content.ReadAsStringAsync();
                var parsedObject = JObject.Parse(json_repuesta);
                var obj = parsedObject["response"].ToString();
                var resultado = JsonConvert.DeserializeObject<List<Paqueteria>>(obj);
                lista.AddRange(resultado);
            }
            return lista;
        }

        public async Task<Paqueteria> ObtenerPaqueteria(string id)
        {
            Paqueteria objeto = new Paqueteria();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"Paqueteria/ObtenerPaqueteria/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json_repuesta = await response.Content.ReadAsStringAsync();
                var parsedObject = JObject.Parse(json_repuesta);
                var obj = parsedObject["response"].ToString();
                var resultado = JsonConvert.DeserializeObject<Paqueteria>(obj);
                objeto = resultado;
            }
            return objeto;
        }
        public async Task<bool> GuardarPaqueteria(Paqueteria registro)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"Paqueteria/GuardarPaqueteria", content);

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<bool> EditarPaqueteria(Paqueteria registro)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"Paqueteria/EditarPaqueteria", content);

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<bool> EliminarPaqueteria(string id)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.DeleteAsync($"Paqueteria/EliminarPaqueteria/{id}");

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }


        public async Task<List<PrecioPaqueteria>> ObtenerPreciosPaqueterias()
        {
            List<PrecioPaqueteria> lista = new List<PrecioPaqueteria>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync("PrecioPaqueteria/ObtenerPreciosPaqueterias");
            if (response.IsSuccessStatusCode)
            {
                var json_repuesta = await response.Content.ReadAsStringAsync();
                var parsedObject = JObject.Parse(json_repuesta);
                var obj = parsedObject["response"].ToString();
                var resultado = JsonConvert.DeserializeObject<List<PrecioPaqueteria>>(obj);
                lista.AddRange(resultado);
            }
            return lista;
        }

        public async Task<PrecioPaqueteria> ObtenerPrecioPaqueteria(int id)
        {
            PrecioPaqueteria objeto = new PrecioPaqueteria();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"PrecioPaqueteria/ObtenerPrecioPaqueteria/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json_repuesta = await response.Content.ReadAsStringAsync();
                var parsedObject = JObject.Parse(json_repuesta);
                var obj = parsedObject["response"].ToString();
                var resultado = JsonConvert.DeserializeObject<PrecioPaqueteria>(obj);
                objeto = resultado;
            }
            return objeto;
        }
        public async Task<bool> GuardarPrecioPaqueteria(PrecioPaqueteria registro)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"PrecioPaqueteria/GuardarPrecioPaqueteria", content);

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<bool> EditarPrecioPaqueteria(PrecioPaqueteria registro)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"PrecioPaqueteria/EditarPrecioPaqueteria", content);

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<bool> EliminarPrecioPaqueteria(int id)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.DeleteAsync($"PrecioPaqueteria/EliminarPrecioPaqueteria/{id}");

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }
        #endregion

        #region Pedido
        public async Task<List<Pedido>> ObtenerPedidos()
        {
            List<Pedido> lista = new List<Pedido>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync("Pedido/ObtenerPedidos");
            if (response.IsSuccessStatusCode)
            {
                var json_repuesta = await response.Content.ReadAsStringAsync();
                var parsedObject = JObject.Parse(json_repuesta);
                var obj = parsedObject["response"].ToString();
                var resultado = JsonConvert.DeserializeObject<List<Pedido>>(obj);
                lista.AddRange(resultado);
            }
            return lista;
        }

        public async Task<Pedido> ObtenerPedido(string id)
        {
            Pedido objeto = new Pedido();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"Pedido/ObtenerPedido/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json_repuesta = await response.Content.ReadAsStringAsync();
                var parsedObject = JObject.Parse(json_repuesta);
                var obj = parsedObject["response"].ToString();
                var resultado = JsonConvert.DeserializeObject<Pedido>(obj);
                objeto = resultado;
            }
            return objeto;
        }
        public async Task<bool> GuardarPedido(Pedido registro)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"Pedido/GuardarPedido", content);

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }
        public async Task<bool> CalcularImportacion(Pedido registro)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"Pedido/CalcularImportacion", content);

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<bool> EditarPedido(Pedido registro)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"Pedido/EditarPedido", content);

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<bool> EliminarPedido(string id)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.DeleteAsync($"Pedido/EliminarPedido/{id}");

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }
        #endregion

        #region Producto
        public async Task<List<Producto>> ObtenerProductos()
        {
            List<Producto> lista = new List<Producto>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync("Producto/ObtenerProductos");
            if (response.IsSuccessStatusCode)
            {
                var json_repuesta = await response.Content.ReadAsStringAsync();
                var parsedObject = JObject.Parse(json_repuesta);
                var obj = parsedObject["response"].ToString();
                var resultado = JsonConvert.DeserializeObject<List<Producto>>(obj);
                lista.AddRange(resultado);
            }
            return lista;
        }

        public async Task<Producto> ObtenerProducto(string id)
        {
            Producto objeto = new Producto();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"Producto/ObtenerProducto/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json_repuesta = await response.Content.ReadAsStringAsync();
                var parsedObject = JObject.Parse(json_repuesta);
                var obj = parsedObject["response"].ToString();
                var resultado = JsonConvert.DeserializeObject<Producto>(obj);
                objeto = resultado;
            }
            return objeto;
        }
        public async Task<bool> GuardarProducto(Producto registro)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"Producto/GuardarProducto", content);

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<bool> EditarProducto(Producto registro)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"Producto/EditarProducto", content);

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<bool> EliminarProducto(string id)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.DeleteAsync($"Producto/EliminarProducto/{id}");

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<List<PrecioProducto>> ObtenerPreciosProductos()
        {
            List<PrecioProducto> lista = new List<PrecioProducto>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync("PrecioProducto/ObtenerPreciosProductos");
            if (response.IsSuccessStatusCode)
            {
                var json_repuesta = await response.Content.ReadAsStringAsync();
                var parsedObject = JObject.Parse(json_repuesta);
                var obj = parsedObject["response"].ToString();
                var resultado = JsonConvert.DeserializeObject<List<PrecioProducto>>(obj);
                lista.AddRange(resultado);
            }
            return lista;
        }

        public async Task<PrecioProducto> ObtenerPrecioProducto(string id)
        {
            PrecioProducto objeto = new PrecioProducto();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"PrecioProducto/ObtenerPrecioProducto/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json_repuesta = await response.Content.ReadAsStringAsync();
                var parsedObject = JObject.Parse(json_repuesta);
                var obj = parsedObject["response"].ToString();
                var resultado = JsonConvert.DeserializeObject<PrecioProducto>(obj);
                objeto = resultado;
            }
            return objeto;
        }
        public async Task<bool> GuardarPrecioProducto(PrecioProducto registro)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"PrecioProducto/GuardarPrecioProducto", content);

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<bool> EditarPrecioProducto(PrecioProducto registro)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"PrecioProducto/EditarPrecioProducto", content);

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<bool> EliminarPrecioProducto(string id)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.DeleteAsync($"PrecioProducto/EliminarPrecioProducto/{id}");

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }
        #endregion

        #region Modelos
        public async Task<List<Modelo>> ObtenerModelos()
        {
            List<Modelo> lista = new List<Modelo>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync("Modelo/ObtenerModelos");
            if (response.IsSuccessStatusCode)
            {
                var json_repuesta = await response.Content.ReadAsStringAsync();
                var parsedObject = JObject.Parse(json_repuesta);
                var obj = parsedObject["response"].ToString();
                var resultado = JsonConvert.DeserializeObject<List<Modelo>>(obj);
                lista.AddRange(resultado);
            }
            return lista;
        }

        public async Task<Modelo> ObtenerModelo(string id)
        {
            Modelo objeto = new Modelo();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"Modelo/ObtenerModelo/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json_repuesta = await response.Content.ReadAsStringAsync();
                var parsedObject = JObject.Parse(json_repuesta);
                var obj = parsedObject["response"].ToString();
                var resultado = JsonConvert.DeserializeObject<Modelo>(obj);
                objeto = resultado;
            }
            return objeto;
        }
        public async Task<bool> GuardarModelo(Modelo registro)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"Modelo/GuardarModelo", content);

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<bool> EditarModelo(Modelo registro)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"Modelo/EditarModelo", content);

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<bool> EliminarModelo(string id)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.DeleteAsync($"Modelo/EliminarModelo/{id}");

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }
        #endregion

        #region Marcas
        public async Task<List<Marca>> ObtenerMarcas()
        {
            List<Marca> lista = new List<Marca>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync("Marca/ObtenerMarcas");
            if (response.IsSuccessStatusCode)
            {
                var json_repuesta = await response.Content.ReadAsStringAsync();
                var parsedObject = JObject.Parse(json_repuesta);
                var obj = parsedObject["response"].ToString();
                var resultado = JsonConvert.DeserializeObject<List<Marca>>(obj);
                lista.AddRange(resultado);
            }
            return lista;
        }

        public async Task<Marca> ObtenerMarca(string id)
        {
            Marca objeto = new Marca();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"Marca/ObtenerMarca/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json_repuesta = await response.Content.ReadAsStringAsync();
                var parsedObject = JObject.Parse(json_repuesta);
                var obj = parsedObject["response"].ToString();
                var resultado = JsonConvert.DeserializeObject<Marca>(obj);
                objeto = resultado;
            }
            return objeto;
        }
        public async Task<bool> GuardarMarca(Marca registro)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"Marca/GuardarMarca", content);

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<bool> EditarMarca(Marca registro)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"Marca/EditarMarca", content);

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<bool> EliminarMarca(string id)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.DeleteAsync($"Marca/EliminarMarca/{id}");

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }
        #endregion

        #region DetalleProductoModelos
        public async Task<List<DetalleProductoModelo>> ObtenerDetalleProductoModelos()
        {
            List<DetalleProductoModelo> lista = new List<DetalleProductoModelo>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync("DetalleProductoModelo/ObtenerDetalleProductoModelos");
            if (response.IsSuccessStatusCode)
            {
                var json_repuesta = await response.Content.ReadAsStringAsync();
                var parsedObject = JObject.Parse(json_repuesta);
                var obj = parsedObject["response"].ToString();
                var resultado = JsonConvert.DeserializeObject<List<DetalleProductoModelo>>(obj);
                lista.AddRange(resultado);
            }
            return lista;
        }

        public async Task<DetalleProductoModelo> ObtenerDetalleProductoModelo(int id)
        {
            DetalleProductoModelo objeto = new DetalleProductoModelo();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"DetalleProductoModelo/ObtenerDetalleProductoModelo/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json_repuesta = await response.Content.ReadAsStringAsync();
                var parsedObject = JObject.Parse(json_repuesta);
                var obj = parsedObject["response"].ToString();
                var resultado = JsonConvert.DeserializeObject<DetalleProductoModelo>(obj);
                objeto = resultado;
            }
            return objeto;
        }
        public async Task<bool> GuardarDetalleProductoModelo(DetalleProductoModelo registro)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"DetalleProductoModelo/GuardarDetalleProductoModelo", content);

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<bool> EditarDetalleProductoModelo(DetalleProductoModelo registro)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"DetalleProductoModelo/EditarDetalleProductoModelo", content);

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<bool> EliminarDetalleProductoModelo(int id)
        {
            bool resultado = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.DeleteAsync($"DetalleProductoModelo/EliminarDetalleProductoModelo/{id}");

            if (response.IsSuccessStatusCode)
            {
                resultado = true;
            }

            return resultado;
        }
        #endregion
    }
}
