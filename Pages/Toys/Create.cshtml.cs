using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Examen_Medii_de_programare.Data;
using Examen_Medii_de_programare.Torpenyi_Andrei_Examen.Models;

namespace Examen_Medii_de_programare.Pages.Toys
{
    public class CreateModel : ToyCategoryPageModel
    {
        private readonly Examen_Medii_de_programare.Data.Examen_Medii_de_programareContext _context;

        public CreateModel(Examen_Medii_de_programare.Data.Examen_Medii_de_programareContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ProducatorID"] = new SelectList(_context.Set<Producator>(), "ID", "NumeProducator");
            var toy = new Toy();
            toy.ToyCategories = new List<ToyCategory>();

            PopulateAssignedCategoryData(_context, toy);
            return Page();
        }

        [BindProperty]
        public Toy Toy { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newToy = new Toy();
            if (selectedCategories != null)
            {
                newToy.ToyCategories = new List<ToyCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ToyCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newToy.ToyCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Toy>(newToy,"Toy",i => i.Nume, i => i.Magazin, i => i.Pret, i => i.DataAparitiei, i => i.ProducatorID))
            {
                _context.Toy.Add(newToy);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newToy);
            return Page();
        }
    }


    }

      /*      // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://aka.ms/RazorPagesCRUD.
            public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Toy.Add(Toy);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
} */
