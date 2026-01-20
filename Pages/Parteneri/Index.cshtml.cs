using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ghita_Vlad_Proiect_Facturi.Data;
using Ghita_Vlad_Proiect_Facturi.Models;

namespace Ghita_Vlad_Proiect_Facturi.Pages.Parteneri
{
    public class IndexModel : PageModel
    {
        private readonly Ghita_Vlad_Proiect_Facturi.Data.GhitaVladProiectFacturiContext _context;

        public IndexModel(Ghita_Vlad_Proiect_Facturi.Data.GhitaVladProiectFacturiContext context)
        {
            _context = context;
        }

        public IList<Partener> Partener { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Partener = await _context.Parteneri.ToListAsync();
        }
    }
}
