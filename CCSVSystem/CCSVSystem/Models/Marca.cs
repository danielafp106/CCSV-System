namespace CCSVSystem.Models
{
    public class Marca
    {
        public string idMarca { get; set; } = null!;

        public string? nombreMarca { get; set; }

        public virtual ICollection<Modelo> modelos { get; set; } = new List<Modelo>();
    }
}
