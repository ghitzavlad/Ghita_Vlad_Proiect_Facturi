using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ghita_Vlad_Proiect_Facturi.Data;
using Ghita_Vlad_Proiect_Facturi.Models;

namespace Ghita_Vlad_Proiect_Facturi.Pages.Facturi
{
    public class DetailsModel : PageModel
    {
        private readonly GhitaVladProiectFacturiContext _context;

        public DetailsModel(GhitaVladProiectFacturiContext context)
        {
            _context = context;
        }

        public Factura Factura { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Factura = await _context.Facturi
                .Include(f => f.Partener)
                .Include(f => f.Plati)
                .Include(f => f.Produs)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Factura == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
