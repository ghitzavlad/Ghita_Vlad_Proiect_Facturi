using Ghita_Vlad_Proiect_Facturi.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ghita_Vlad_Proiect_Facturi.Data;

public class Ghita_Vlad_Proiect_FacturiContext : IdentityDbContext<Ghita_Vlad_Proiect_FacturiUser>
{
    public Ghita_Vlad_Proiect_FacturiContext(DbContextOptions<Ghita_Vlad_Proiect_FacturiContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
