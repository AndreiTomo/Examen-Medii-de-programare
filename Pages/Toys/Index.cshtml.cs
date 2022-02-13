using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Examen_Medii_de_programare.Data;
using Examen_Medii_de_programare.Torpenyi_Andrei_Examen.Models;

namespace Examen_Medii_de_programare.Pages.Toys
{
    public class IndexModel : PageModel
    {
        private readonly Examen_Medii_de_programare.Data.Examen_Medii_de_programareContext _context;

        public IndexModel(Examen_Medii_de_programare.Data.Examen_Medii_de_programareContext context)
        {
            _context = context;
        }

        public IList<Toy> Toy { get; set; }
        public ToyData ToyD { get; set; }
        public int ToyID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ToyD = new ToyData();

            ToyD.Toys = await _context.Toy
                .Include(b => b.Producator)
                .Include(b => b.ToyCategories)
                 .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Nume)
                .ToListAsync();
            if (id != null)
            {
                ToyID = id.Value;
                Toy toy = ToyD.Toys
                .Where(i => i.ID == id.Value).Single();
                ToyD.Categories = toy.ToyCategories.Select(s => s.Category);
            }
        }
    }
}

       /* public async Task OnGetAsync()
        {
            Toy = await _context.Toy
                .Include(b=>b.Producator)
                .ToListAsync();
        }
    }
}*/
