using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ghita_Vlad_Proiect_Facturi.Data;
using Ghita_Vlad_Proiect_Facturi.Models;

namespace Ghita_Vlad_Proiect_Facturi.Pages.Plati
{
    public class IndexModel : PageModel
    {
        private readonly GhitaVladProiectFacturiContext _context;

        public IndexModel(GhitaVladProiectFacturiContext context)
        {
            _context = context;
        }

        public IList<Plata> Plata { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Plata = await _context.Plati
                .Include(p => p.Factura)
                .ToListAsync();
        }
    }
}
