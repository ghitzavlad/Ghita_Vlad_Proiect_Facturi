using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ghita_Vlad_Proiect_Facturi.Models
{
    public enum TipPartener
    {
        Client,
        Furnizor,
        ClientFurnizor
    }

    public class Partener
    {
        public int ID { get; set; }

        [Required, StringLength(100)]
        public string Nume { get; set; }

        [StringLength(20)]
        public string? CUI { get; set; }

        [StringLength(200)]
        public string? Adresa { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public TipPartener Tip { get; set; }

        public ICollection<Factura>? Facturi { get; set; }
    }
}
