using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraVeiculos.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }
        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public int VeiculoId { get; set; }
        [ForeignKey("VeiculoId")]
        public string? Pagamento { get; set; }
    }
}
