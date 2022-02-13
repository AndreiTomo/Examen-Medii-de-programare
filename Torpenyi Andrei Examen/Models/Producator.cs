using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_Medii_de_programare.Torpenyi_Andrei_Examen.Models
{
    public class Producator
    {
        public int ID { get; set; }
        public string NumeProducator { get; set; }
        public ICollection<Toy> Toys { get; set; }
    }
}
