using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_Medii_de_programare.Torpenyi_Andrei_Examen.Models
{
    public class ToyCategory
    {
        public int ID { get; set; }
        public int ToyID { get; set; }

        public Toy Toy { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
