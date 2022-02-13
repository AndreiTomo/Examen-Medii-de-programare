using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Examen_Medii_de_programare.Data;
using Examen_Medii_de_programare.Torpenyi_Andrei_Examen.Models;

namespace Examen_Medii_de_programare.Pages.Toys
{
    public class EditModel : ToyCategoryPageModel
    {
        private readonly Examen_Medii_de_programare.Data.Examen_Medii_de_programareContext _context;

        public EditModel(Examen_Medii_de_programare.Data.Examen_Medii_de_programareContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Toy Toy { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Toy = await _context.Toy
                .Include(b => b.Producator)
                .Include(b => b.ToyCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Toy == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Toy);
            ViewData["ProducatorID"] = new SelectList(_context.Set<Producator>(), "ID", "NumeProducator");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toyToUpdate = await _context.Toy
 .Include(i => i.Producator)
 .Include(i => i.ToyCategories)
 .ThenInclude(i => i.Category)
 .FirstOrDefaultAsync(s => s.ID == id);
            if (toyToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Toy>(
            toyToUpdate,
            "Toy",
            i => i.Nume, i => i.Magazin,
            i => i.Pret, i => i.DataAparitiei, i => i.Producator))
            {
                UpdateToyCategories(_context, selectedCategories, toyToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateToyCategories(_context, selectedCategories, toyToUpdate);
            PopulateAssignedCategoryData(_context, toyToUpdate);
            return Page();
        }
    }
}

    
/*
        private bool ToyExists(int id)
        {
            return _context.Toy.Any(e => e.ID == id);
        }
    }
}
*/
