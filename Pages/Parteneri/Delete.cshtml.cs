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
    public class DeleteModel : PageModel
    {
        private readonly Ghita_Vlad_Proiect_Facturi.Data.GhitaVladProiectFacturiContext _context;

        public DeleteModel(Ghita_Vlad_Proiect_Facturi.Data.GhitaVladProiectFacturiContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partener = await _context.Parteneri.FindAsync(id);
            if (partener != null)
            {
                Partener = partener;
                _context.Parteneri.Remove(Partener);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
