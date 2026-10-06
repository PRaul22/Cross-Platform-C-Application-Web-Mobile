using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect_Nonu_Stefania_Popa_Raul_.NETMAUI.Models
{
    public class Inchiriere
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [Indexed]
        public int MasinaID { get; set; }

        public string NumeClient { get; set; }
        public DateTime DataPreluare { get; set; }
        public DateTime DataReturnare { get; set; }
    }
}
