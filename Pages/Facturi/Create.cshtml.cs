using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ghita_Vlad_Proiect_Facturi.Data;
using Ghita_Vlad_Proiect_Facturi.Models;

namespace Ghita_Vlad_Proiect_Facturi.Pages.Facturi
{
    public class CreateModel : PageModel
    {
        private readonly GhitaVladProiectFacturiContext _context;

        public CreateModel(GhitaVladProiectFacturiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Factura Factura { get; set; } = default!;

        public IActionResult OnGet()
        {
            ViewData["PartenerID"] = new SelectList(_context.Parteneri, "ID", "Nume");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                ViewData["PartenerID"] = new SelectList(_context.Parteneri, "ID", "Nume", Factura.PartenerID);
                return Page();
            }


            _context.Facturi.Add(Factura);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Details", new { id = Factura.ID });
        }
    }
}
