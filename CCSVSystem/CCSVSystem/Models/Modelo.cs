namespace CCSVSystem.Models
{
    public class Modelo
    {
        public string idModelo { get; set; } = null!;

        public string? idMarca { get; set; }

        public string? nombreModelo { get; set; }
       // [JsonIgnore]
       // public virtual ICollection<DetalleProductoModelo> DetalleProductosModelos { get; set; } = new List<DetalleProductoModelo>();
       // [JsonIgnore]
        public virtual Marca? marca { get; set; }
    }
}
