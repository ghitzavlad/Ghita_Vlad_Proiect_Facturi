using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ghita_Vlad_Proiect_Facturi.Data;
using Ghita_Vlad_Proiect_Facturi.Models;
using System.Threading.Tasks;

namespace Ghita_Vlad_Proiect_Facturi.Pages.Facturi
{
    public class CreateModel : PageModel
    {
        private readonly GhitaVladProiectFacturiContext _context;
        public CreateModel(GhitaVladProiectFacturiContext context) => _context = context;

        [BindProperty]
        public Factura Factura { get; set; } = new Factura();

        public IActionResult OnGet()
        {
            ViewData["PartenerID"] = new SelectList(_context.Parteneri, "ID", "Nume");
            ViewData["ProduseID"] = new SelectList(_context.Produse, "ID", "NumeProdus");
            return Page();
        }

        public async Task<JsonResult> OnGetProdusPretAsync(int id)
        {
            var produs = await _context.Produse.FindAsync(id);
            return new JsonResult(new { pret = produs?.PretUnitar ?? 0m });
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var produs = await _context.Produse.FindAsync(Factura.ProdusID);
            if (produs != null)
                Factura.Total = produs.PretUnitar * Factura.Cantitate;

            if (!ModelState.IsValid)
            {
                ViewData["PartenerID"] = new SelectList(_context.Parteneri, "ID", "Nume", Factura.PartenerID);
                ViewData["ProduseID"] = new SelectList(_context.Produse, "ID", "NumeProdus", Factura.ProdusID);
                return Page();
            }

            _context.Facturi.Add(Factura);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
