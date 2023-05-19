using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CCSVSystem.Models
{
    public class Paqueteria
    {
        [Display(Name = "ID Paqueteria")]
        public string idPaqueteria { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Proveedor")]
        public string? idProveedor { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Nombre")]
        [MaxLength(50)]
        public string? nombrePaqueteria { get; set; }

        [Display(Name = "Url de Imagen")]
        [MaxLength(200)]
        public string? urlImagenPaqueteria { get; set; }

        [Display(Name = "Proveedor")]
        public virtual Proveedor? proveedor { get; set; }
        public virtual PrecioPaqueteria? pp { get; set; }
        public virtual ICollection<PrecioPaqueteria> preciosPaqueteria { get; set; } = new List<PrecioPaqueteria>();

        public string? enUso { get; set; }
    }
}
