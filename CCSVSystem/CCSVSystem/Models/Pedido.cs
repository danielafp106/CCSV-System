namespace CCSVSystem.Models
{
    public class Pedido
    {
        public string idPedido { get; set; } = null!;

        public string? idProveedor { get; set; }

        public DateTime? fechaOrdenado { get; set; }

        public DateTime? fechaRecibido { get; set; }

        public decimal? totalProductosPedido { get; set; }

        public decimal? totalImportePedido { get; set; }

        public decimal? totalPedido { get; set; }

        public int? stockPedido { get; set; }

        public virtual Proveedor? proveedor { get; set; }
    }
}
