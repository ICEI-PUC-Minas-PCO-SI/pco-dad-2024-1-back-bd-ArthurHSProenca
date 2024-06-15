namespace LocadoraVeiculos.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string? Modelo { get; set; }
        public string? Marca { get; set; }
        public int Ano { get; set; }
        public string? Placa { get; set; }
        public string? Disponibilidade { get; set; }
        public ICollection<Reserva>? Reserva { get; set; }
    }
}
