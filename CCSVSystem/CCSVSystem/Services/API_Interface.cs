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
        Task<PrecioPaqueteria> ObtenerPrecioPaqueteria(string id);
        Task<bool> GuardarPrecioPaqueteria(PrecioPaqueteria registro);
        Task<bool> EditarPrecioPaqueteria(PrecioPaqueteria registro);
        Task<bool> EliminarPrecioPaqueteria(string id);
    }
}
