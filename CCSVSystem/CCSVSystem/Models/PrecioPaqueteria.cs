using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CCSVSystem.Models
{
    public class PrecioPaqueteria
    {
        [Display(Name = "ID Stock")]
        public int idPrecioPaqueteria { get; set; }

        [Display(Name = "ID Paqueteria")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string? idPaqueteria { get; set; }

        [Display(Name = "Compra Total")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public decimal? compraTotalPaqueteria { get; set; }

        [Display(Name = "Precio Unidad")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public decimal? precioUnidadPaqueteria { get; set; }

        [Display(Name = "Stock Total")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int? stockTotalCompradoPaqueteria { get; set; }

        [Display(Name = "¿Es Recurrente?")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public bool esPaqueteriaRecurrente { get; set; }

        [Display(Name = "Fecha de Compra")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [DataType(DataType.Date)]
        public DateTime? fechaCompra { get; set; }

        [Display(Name = "Inicio de Uso")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [DataType(DataType.Date)]
        public DateTime? fechaInicioUso { get; set; }

        [Display(Name = "Fin de Uso")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [DataType(DataType.Date)]
        public DateTime? fechaFinUso { get; set; }

        //public virtual Paqueteria? IdPaqueteriaNavigation { get; set; }
    }
}
