using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CCSVSystem.Models
{
    public class Proveedor
    {
        [Display(Name = "ID Proveedor")]       
        public string idProveedor { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(100)]
        public string nombreProveedor { get; set; }

        [Display(Name = "Contacto")]
        [MaxLength(9)]
        public string? contactoProveedor { get; set; }

        [Display(Name = "Comentarios")]
        [MaxLength(200)]
        public string? comentarios { get; set; }


        //[JsonIgnore]
        //public virtual ICollection<Paqueteria> Paqueteria { get; set; } = new List<Paqueteria>();
        //[JsonIgnore]
        //public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
