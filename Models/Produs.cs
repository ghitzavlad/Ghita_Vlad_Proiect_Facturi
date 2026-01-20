using System.ComponentModel.DataAnnotations;

namespace Ghita_Vlad_Proiect_Facturi.Models
{
    public class Produs
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nume produs")]
        public string NumeProdus { get; set; } = string.Empty;

        [DataType(DataType.Currency)]
        [Display(Name = "Pret unitar")]
        public decimal PretUnitar { get; set; }

        [StringLength(500)]
        [Display(Name = "Descriere")]
        public string? Descriere { get; set; }
    }
}
