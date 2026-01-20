using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ghita_Vlad_Proiect_Facturi.Models
{
    public enum TipFactura
    {
        Vanzare,
        Achizitie
    }

    public enum StareFactura
    {
        Ciorna,
        Emisa,
        Platita,
        Anulata
    }

    public class Factura
    {
        public int ID { get; set; }

        [Required, StringLength(10)]
        public string Serie { get; set; }

        public int Numar { get; set; }

        [Display(Name = "Data emitere")]
        [DataType(DataType.Date)]
        public DateTime DataEmiterii { get; set; } = DateTime.Today;

        [Display(Name = "Data scadenta")]
        [DataType(DataType.Date)]
        public DateTime DataScadentei { get; set; } = DateTime.Today.AddDays(30);

        [Display(Name = "Tip factura")]
        public TipFactura TipFactura { get; set; }

        [Display(Name = "Partener")]
        public int PartenerID { get; set; }
        public Partener? Partener { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        public StareFactura Stare { get; set; } = StareFactura.Ciorna;

        public ICollection<Plata>? Plati { get; set; }

        [Display(Name = "Suma platita")]
        [DataType(DataType.Currency)]
        public decimal SumaPlatita => Plati?.Sum(p => p.Suma) ?? 0m;

        [Display(Name = "Rest de plata")]
        [DataType(DataType.Currency)]
        public decimal RestDePlata => Total - SumaPlatita;
    }
}
