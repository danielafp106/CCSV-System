namespace CCSVSystem.Models
{
    public class DetalleProductoModelo
    {
        public int idDetalleProductoModelo { get; set; }
        public int? idPrecioProducto { get; set; }
        public string? idModelo { get; set; }
        public int? stockProductoModelo { get; set; }
        public int? stockRealTimeProductoModelo { get; set; }
        public virtual string? DetalleModeloMarca { get; set; }
    }
}
