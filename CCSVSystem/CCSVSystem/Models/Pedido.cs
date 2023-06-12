using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CCSVSystem.Models
{
    public class Pedido
    {
        [Display(Name = "ID Pedido")]
        public string idPedido { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Proveedor")]
        public string? idProveedor { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Ordenado")]
        [DataType(DataType.Date)]
        public DateTime? fechaOrdenado { get; set; }

        [Display(Name = "Recibido")]
        [DataType(DataType.Date)]
        public DateTime? fechaRecibido { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Total de la Compra Final")]
        public decimal? totalProductosPedido { get; set; }

        [Display(Name = "Total de Importe")]
        [DataType(DataType.Currency)]
        public decimal? totalImportePedido { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Total Comprado")]
        public decimal? totalPedido { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Stock Ordenado")]
        public int? stockPedido { get; set; }
        [Display(Name = "Proveedor")]
        public virtual Proveedor? proveedor { get; set; }
        public virtual ICollection<PrecioProducto> PreciosProductos { get; set; } = new List<PrecioProducto>();

        public virtual PrecioProducto? pp { get; set; }
    }
}
