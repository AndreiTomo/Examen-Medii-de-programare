using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Examen_Medii_de_programare.Data;
using Examen_Medii_de_programare.Torpenyi_Andrei_Examen.Models;

namespace Examen_Medii_de_programare.Pages.Producatori
{
    public class DeleteModel : PageModel
    {
        private readonly Examen_Medii_de_programare.Data.Examen_Medii_de_programareContext _context;

        public DeleteModel(Examen_Medii_de_programare.Data.Examen_Medii_de_programareContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Producator Producator { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Producator = await _context.Producator.FirstOrDefaultAsync(m => m.ID == id);

            if (Producator == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Producator = await _context.Producator.FindAsync(id);

            if (Producator != null)
            {
                _context.Producator.Remove(Producator);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
