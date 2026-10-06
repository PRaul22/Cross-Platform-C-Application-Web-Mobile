using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Nonu_Stefania_Popa_Raul.Data;
using Proiect_Nonu_Stefania_Popa_Raul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Nonu_Stefania_Popa_Raul.Pages.Masini
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Proiect_Nonu_Stefania_Popa_Raul.Data.Proiect_Nonu_Stefania_Popa_RaulContext _context;

        public IndexModel(Proiect_Nonu_Stefania_Popa_Raul.Data.Proiect_Nonu_Stefania_Popa_RaulContext context)
        {
            _context = context;
        }

        public IList<Masina> Masina { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Masina = await _context.Masina
                .Include(m => m.Brand).ToListAsync();
        }
    }
}
