using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Nonu_Stefania_Popa_Raul.Models
{
    public class Masina
    {
        public int ID { get; set; }

        [Display(Name = "Model")]
        public string Model { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal PretPeZi { get; set; }
        public int? BrandID { get; set; }
        public Brand? Brand { get; set; }
        public ICollection<Inchiriere>? Inchirieri { get; set; }
    }
}
