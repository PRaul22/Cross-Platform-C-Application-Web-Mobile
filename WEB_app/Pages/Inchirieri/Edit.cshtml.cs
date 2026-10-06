using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Nonu_Stefania_Popa_Raul.Data;
using Proiect_Nonu_Stefania_Popa_Raul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Nonu_Stefania_Popa_Raul.Pages.Inchirieri
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Proiect_Nonu_Stefania_Popa_Raul.Data.Proiect_Nonu_Stefania_Popa_RaulContext _context;

        public EditModel(Proiect_Nonu_Stefania_Popa_Raul.Data.Proiect_Nonu_Stefania_Popa_RaulContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inchiriere Inchiriere { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inchiriere =  await _context.Inchiriere.FirstOrDefaultAsync(m => m.ID == id);
            if (inchiriere == null)
            {
                return NotFound();
            }
            Inchiriere = inchiriere;
           ViewData["MasinaID"] = new SelectList(_context.Set<Masina>(), "ID", "Model");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Inchiriere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InchiriereExists(Inchiriere.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InchiriereExists(int id)
        {
            return _context.Inchiriere.Any(e => e.ID == id);
        }
    }
}
