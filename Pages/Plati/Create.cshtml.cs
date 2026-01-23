using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ghita_Vlad_Proiect_Facturi.Data;
using Ghita_Vlad_Proiect_Facturi.Models;

namespace Ghita_Vlad_Proiect_Facturi.Pages.Plati
{
    public class CreateModel : PageModel
    {
        private readonly GhitaVladProiectFacturiContext _context;

        public CreateModel(GhitaVladProiectFacturiContext context)
        {
            _context = context;
        }

        public SelectList FacturiSelectList { get; set; } = default!;

        [BindProperty]
        public Plata Plata { get; set; } = new Plata();

        public IActionResult OnGet()
        {
            FacturiSelectList = new SelectList(_context.Facturi, "ID", "Serie");
            return Page();
        }

        public async Task<IActionResult> OnGetFacturaInfoAsync(int? id)
        {
            if (id == null) return new JsonResult(null);

            var factura = await _context.Facturi
                .Include(f => f.Plati)
                .FirstOrDefaultAsync(f => f.ID == id);

            if (factura == null) return new JsonResult(null);

            return new JsonResult(new
            {
                total = factura.Total.ToString("C"),
                sumaPlatita = factura.SumaPlatita.ToString("C"),
                restDePlata = factura.RestDePlata.ToString("C")
            });
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var factura = await _context.Facturi
                .Include(f => f.Plati)
                .FirstOrDefaultAsync(f => f.ID == Plata.FacturaID);

            if (factura == null) return NotFound();

            if (Plata.Suma > factura.RestDePlata)
            {
                ModelState.AddModelError("Plata.Suma", $"Suma introdusă depășește restul de plată ({factura.RestDePlata:C}).");
                FacturiSelectList = new SelectList(_context.Facturi, "ID", "Serie", Plata.FacturaID);
                return Page();
            }

            _context.Plati.Add(Plata);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
