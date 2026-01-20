using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ghita_Vlad_Proiect_Facturi.Data;
using Ghita_Vlad_Proiect_Facturi.Models;

namespace Ghita_Vlad_Proiect_Facturi.Pages.Facturi
{
    public class IndexModel : PageModel
    {
        private readonly GhitaVladProiectFacturiContext _context;

        public IndexModel(GhitaVladProiectFacturiContext context)
        {
            _context = context;
        }

        public IList<Factura> Facturi { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Facturi = await _context.Facturi
                .Include(f => f.Partener)
                .ToListAsync();
        }
    }
}
