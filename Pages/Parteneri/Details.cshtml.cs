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
    public class DetailsModel : PageModel
    {
        private readonly Ghita_Vlad_Proiect_Facturi.Data.GhitaVladProiectFacturiContext _context;

        public DetailsModel(Ghita_Vlad_Proiect_Facturi.Data.GhitaVladProiectFacturiContext context)
        {
            _context = context;
        }

        public Partener Partener { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partener = await _context.Parteneri.FirstOrDefaultAsync(m => m.ID == id);
            if (partener == null)
            {
                return NotFound();
            }
            else
            {
                Partener = partener;
            }
            return Page();
        }
    }
}
