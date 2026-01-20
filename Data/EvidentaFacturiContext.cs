using Microsoft.EntityFrameworkCore;
using Ghita_Vlad_Proiect_Facturi.Models;

namespace Ghita_Vlad_Proiect_Facturi.Data
{
    public class GhitaVladProiectFacturiContext : DbContext
    {
        public GhitaVladProiectFacturiContext(DbContextOptions<GhitaVladProiectFacturiContext> options)
            : base(options)
        {
        }

        public DbSet<Partener> Parteneri { get; set; } = default!;
        public DbSet<Factura> Facturi { get; set; } = default!;
        public DbSet<Produs> Produse { get; set; } = default!;
        public DbSet<Plata> Plati { get; set; } = default!;
    }
}
