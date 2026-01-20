using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ghita_Vlad_Proiect_Facturi.Data;
using Ghita_Vlad_Proiect_Facturi.Models;

namespace Ghita_Vlad_Proiect_Facturi.Pages.Produse
{
    public class IndexModel : PageModel
    {
        private readonly GhitaVladProiectFacturiContext _context;

        public IndexModel(GhitaVladProiectFacturiContext context)
        {
            _context = context;
        }

        public IList<Produs> Produs { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Produs = await _context.Produse.ToListAsync();
        }
    }
}
