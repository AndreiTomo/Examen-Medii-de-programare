using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_Medii_de_programare.Torpenyi_Andrei_Examen.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ToyCategory> ToyCategories { get; set; }
    }
}
