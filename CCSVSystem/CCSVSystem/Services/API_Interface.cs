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
    }
}
