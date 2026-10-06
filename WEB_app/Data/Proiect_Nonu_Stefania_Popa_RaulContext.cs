using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Proiect_Nonu_Stefania_Popa_Raul.Models;

namespace Proiect_Nonu_Stefania_Popa_Raul.Data
{
    public class Proiect_Nonu_Stefania_Popa_RaulContext : IdentityDbContext
    {
        public Proiect_Nonu_Stefania_Popa_RaulContext (DbContextOptions<Proiect_Nonu_Stefania_Popa_RaulContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Nonu_Stefania_Popa_Raul.Models.Brand> Brand { get; set; } = default!;
        public DbSet<Proiect_Nonu_Stefania_Popa_Raul.Models.Inchiriere> Inchiriere { get; set; } = default!;
        public DbSet<Proiect_Nonu_Stefania_Popa_Raul.Models.Masina> Masina { get; set; } = default!;
    }
}
