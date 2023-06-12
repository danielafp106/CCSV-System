using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CCSVSystem.Models
{
    public class PrecioProducto
    {
        public int idPrecioProducto { get; set; }

        public string? idProducto { get; set; }
        [Display(Name = "Pedido")]
        public string? idPedido { get; set; }

        [Display(Name = "Compra Total")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public decimal? compraTotalProducto { get; set; }
        [Display(Name = "Precio Unidad")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public decimal? compraUnidadProducto { get; set; }
        [Display(Name = "Importación")]
        public decimal? importacion { get; set; }
        [Display(Name = "Paqueteria")]
        public decimal? paqueteria { get; set; }
        [Display(Name = "Tarifa Envío")]
        public decimal? tarifaEnvio { get; set; }

        [Display(Name = "Precio Uni. Público")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public decimal? compraUnidadPublico { get; set; }
        [Display(Name = "Ganancia")]
        public decimal? ganancia { get; set; }
        [Display(Name = "Precio Público")]
        public decimal? precioPublico { get; set; }

        [Display(Name = "Stock Comprado")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int? stockTotalComprado { get; set; }
        [Display(Name = "Live Stock")]
        public int? stockTotalRealTime { get; set; }

        //public virtual ICollection<DetalleProductoModelo> detalleProductosModelos { get; set; } = new List<DetalleProductoModelo>();
        public virtual Pedido? pedido { get; set; }
        [Display(Name = "Producto")]
        public virtual Producto? producto { get; set; }
        public virtual bool productoRegistrado { get; set; }    
    }
}
