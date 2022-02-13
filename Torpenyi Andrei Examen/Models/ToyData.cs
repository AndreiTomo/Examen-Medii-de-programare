using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_Medii_de_programare.Torpenyi_Andrei_Examen.Models
{
    public class ToyData
    {
        public IEnumerable<Toy> Toys { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ToyCategory> ToyCategories { get; set; }
    }
}
