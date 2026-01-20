using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ghita_Vlad_Proiect_Facturi.Data;
using Ghita_Vlad_Proiect_Facturi.Models;

namespace Ghita_Vlad_Proiect_Facturi.Pages.Facturi
{
    public class EditModel : PageModel
    {
        private readonly GhitaVladProiectFacturiContext _context;

        public EditModel(GhitaVladProiectFacturiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Factura Factura { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Factura = await _context.Facturi
                .Include(f => f.Partener)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Factura == null)
            {
                return NotFound();
            }

            ViewData["PartenerID"] = new SelectList(_context.Parteneri, "ID", "Nume", Factura.PartenerID);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["PartenerID"] = new SelectList(_context.Parteneri, "ID", "Nume", Factura.PartenerID);
                return Page();
            }

            var facturaExistenta = await _context.Facturi
                .FirstOrDefaultAsync(f => f.ID == Factura.ID);

            if (facturaExistenta == null)
            {
                return NotFound();
            }

            facturaExistenta.Serie = Factura.Serie;
            facturaExistenta.Numar = Factura.Numar;
            facturaExistenta.DataEmiterii = Factura.DataEmiterii;
            facturaExistenta.DataScadentei = Factura.DataScadentei;
            facturaExistenta.TipFactura = Factura.TipFactura;
            facturaExistenta.PartenerID = Factura.PartenerID;
            facturaExistenta.Stare = Factura.Stare;
            facturaExistenta.Total = Factura.Total;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaExists(Factura.ID))
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

        private bool FacturaExists(int id)
        {
            return _context.Facturi.Any(e => e.ID == id);
        }
    }
}
