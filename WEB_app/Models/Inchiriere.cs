using System.ComponentModel.DataAnnotations;

namespace Proiect_Nonu_Stefania_Popa_Raul.Models
{
    public class Inchiriere
    {
        public int ID { get; set; }
        public int? MasinaID { get; set; }
        public Masina? Masina { get; set; }

        [Display(Name = "Nume Client")]
        public string NumeClient { get; set; } 

        [DataType(DataType.Date)]
        public DateTime DataPreluare { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataReturnare { get; set; }
    }
}
