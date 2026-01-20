using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ghita_Vlad_Proiect_Facturi.Data;
using Ghita_Vlad_Proiect_Facturi.Models;

namespace Ghita_Vlad_Proiect_Facturi.Pages.Parteneri
{
    public class CreateModel : PageModel
    {
        private readonly Ghita_Vlad_Proiect_Facturi.Data.GhitaVladProiectFacturiContext _context;

        public CreateModel(Ghita_Vlad_Proiect_Facturi.Data.GhitaVladProiectFacturiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Partener Partener { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Parteneri.Add(Partener);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
