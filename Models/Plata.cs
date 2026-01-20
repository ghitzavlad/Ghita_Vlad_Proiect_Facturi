using System;
using System.ComponentModel.DataAnnotations;

namespace Ghita_Vlad_Proiect_Facturi.Models
{
    public enum MetodaPlata
    {
        Numerar,
        Card,
        Transfer,
        CEC
    }

    public class Plata
    {
        public int ID { get; set; }

        [Display(Name = "Factura")]
        public int FacturaID { get; set; }
        public Factura? Factura { get; set; }

        [Display(Name = "Data platii")]
        [DataType(DataType.Date)]
        public DateTime DataPlatii { get; set; } = DateTime.Today;

        [DataType(DataType.Currency)]
        [Display(Name = "Suma")]
        public decimal Suma { get; set; }

        [Display(Name = "Metoda plata")]
        public MetodaPlata MetodaPlata { get; set; }

        [StringLength(500)]
        [Display(Name = "Observatii")]
        public string? Observatii { get; set; }
    }
}
