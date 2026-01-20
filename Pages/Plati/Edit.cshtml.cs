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

namespace Ghita_Vlad_Proiect_Facturi.Pages.Plati
{
    public class EditModel : PageModel
    {
        private readonly GhitaVladProiectFacturiContext _context;

        public EditModel(GhitaVladProiectFacturiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Plata Plata { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plata = await _context.Plati.FirstOrDefaultAsync(m => m.ID == id);
            if (plata == null)
            {
                return NotFound();
            }
            Plata = plata;
            ViewData["FacturaID"] = new SelectList(_context.Facturi, "ID", "Serie", Plata.FacturaID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var factura = await _context.Facturi
                .Include(f => f.Plati)
                .FirstOrDefaultAsync(f => f.ID == Plata.FacturaID);

            if (factura != null)
            {
                var plataExistenta = await _context.Plati.FindAsync(Plata.ID);
                var sumaPlatitaExistenta = factura.Plati?.Where(p => p.ID != Plata.ID).Sum(p => p.Suma) ?? 0m;
                var sumaTotalaDupaPlata = sumaPlatitaExistenta + Plata.Suma;

                if (sumaTotalaDupaPlata > factura.Total)
                {
                    ModelState.AddModelError("Plata.Suma", 
                        $"Suma platii ({Plata.Suma:C}) plus celelalte plati ({sumaPlatitaExistenta:C}) = {sumaTotalaDupaPlata:C} depaseste totalul facturii ({factura.Total:C}). Rest de plata: {factura.Total - sumaPlatitaExistenta:C}");
                }
            }

            if (!ModelState.IsValid)
            {
                ViewData["FacturaID"] = new SelectList(_context.Facturi, "ID", "Serie", Plata.FacturaID);
                return Page();
            }

            _context.Attach(Plata).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlataExists(Plata.ID))
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

        private bool PlataExists(int id)
        {
            return _context.Plati.Any(e => e.ID == id);
        }
    }
}
