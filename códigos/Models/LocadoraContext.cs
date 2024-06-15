using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculos.Models
{
    public class LocadoraContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; } = null!;
        public DbSet<Veiculo> Veiculo { get; set; } = null!;
        public DbSet<Reserva> Reserva { get; set; } = null!;

        public LocadoraContext(DbContextOptions<LocadoraContext> options)
            : base(options) { }
    }
}
