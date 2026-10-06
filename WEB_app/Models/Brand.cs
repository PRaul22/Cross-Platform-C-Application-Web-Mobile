using System.ComponentModel.DataAnnotations;

namespace Proiect_Nonu_Stefania_Popa_Raul.Models
{
    public class Brand
    {
        public int ID { get; set; }

        [Display(Name = "Marca Auto")]
        public string Nume { get; set; } 

        public ICollection<Masina>? Masini { get; set; }
    }
}
