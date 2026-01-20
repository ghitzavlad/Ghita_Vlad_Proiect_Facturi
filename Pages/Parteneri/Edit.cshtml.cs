using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ghita_Vlad_Proiect_Facturi.Data;
using Ghita_Vlad_Proiect_Facturi.Models;

namespace Ghita_Vlad_Proiect_Facturi.Pages.Parteneri
{
    public class EditModel : PageModel
    {
        private readonly Ghita_Vlad_Proiect_Facturi.Data.GhitaVladProiectFacturiContext _context;

        public EditModel(Ghita_Vlad_Proiect_Facturi.Data.GhitaVladProiectFacturiContext context)
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

            var partener =  await _context.Parteneri.FirstOrDefaultAsync(m => m.ID == id);
            if (partener == null)
            {
                return NotFound();
            }
            Partener = partener;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Partener).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartenerExists(Partener.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PartenerExists(int id)
        {
            return _context.Parteneri.Any(e => e.ID == id);
        }
    }
}
