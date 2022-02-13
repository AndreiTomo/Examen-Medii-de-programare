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
    public class DetailsModel : PageModel
    {
        private readonly Examen_Medii_de_programare.Data.Examen_Medii_de_programareContext _context;

        public DetailsModel(Examen_Medii_de_programare.Data.Examen_Medii_de_programareContext context)
        {
            _context = context;
        }

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
    }
}
