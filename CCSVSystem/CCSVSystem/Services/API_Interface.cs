using CCSVSystem.Models;

namespace CCSVSystem.Services
{
    public interface API_Interface
    {
        //Proveedores
        Task<List<Proveedor>> ObtenerProveedores();
        Task<Proveedor> ObtenerProveedor(string id);
        Task<bool> GuardarProveedor(Proveedor registro);
        Task<bool> EditarProveedor(Proveedor registro);
        Task<bool> EliminarProveedor(string id);

        //Paqueterias
        Task<List<Paqueteria>> ObtenerPaqueterias();
        Task<Paqueteria> ObtenerPaqueteria(string id);
        Task<bool> GuardarPaqueteria(Paqueteria registro);
        Task<bool> EditarPaqueteria(Paqueteria registro);
        Task<bool> EliminarPaqueteria(string id);

        Task<List<PrecioPaqueteria>> ObtenerPreciosPaqueterias();
        Task<PrecioPaqueteria> ObtenerPrecioPaqueteria(int id);
        Task<bool> GuardarPrecioPaqueteria(PrecioPaqueteria registro);
        Task<bool> EditarPrecioPaqueteria(PrecioPaqueteria registro);
        Task<bool> EliminarPrecioPaqueteria(int id);

        //Pedidos
        Task<List<Pedido>> ObtenerPedidos();
        Task<Pedido> ObtenerPedido(string id);
        Task<bool> GuardarPedido(Pedido registro);
        Task<bool> CalcularImportacion(Pedido registro);
        Task<bool> EditarPedido(Pedido registro);
        Task<bool> EliminarPedido(string id);

        //Productos
        Task<List<Producto>> ObtenerProductos();
        Task<Producto> ObtenerProducto(string id);
        Task<bool> GuardarProducto(Producto registro);
        Task<bool> EditarProducto(Producto registro);
        Task<bool> EliminarProducto(string id);

        Task<List<PrecioProducto>> ObtenerPreciosProductos();
        Task<PrecioProducto> ObtenerPrecioProducto(string id);
        Task<bool> GuardarPrecioProducto(PrecioProducto registro);
        Task<bool> EditarPrecioProducto(PrecioProducto registro);
        Task<bool> EliminarPrecioProducto(string id);
    }
}
