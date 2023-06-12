using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CCSVSystem.Models
{
    public class Producto
    {
        [Display(Name = "ID Producto")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string idProducto { get; set; } = null!;

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string? nombreProducto { get; set; }

        [Display(Name = "Link en Proveedor")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string? urlProductoProveedor { get; set; }

        [Display(Name = "Imagen (Url)")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string? urlImagenProducto { get; set; }

        public virtual ICollection<PrecioProducto> preciosProductos { get; set; } = new List<PrecioProducto>();
    }
}
