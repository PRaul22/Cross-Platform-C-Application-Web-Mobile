using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect_Nonu_Stefania_Popa_Raul_.NETMAUI.Models
{
    public class Masina
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Marca { get; set; }
        public string Model { get; set; }
        public decimal PretPeZi { get; set; }
    }
}
