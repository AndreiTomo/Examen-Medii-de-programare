using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_Medii_de_programare.Torpenyi_Andrei_Examen.Models
{
    public class Toy
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Nume jucarie")]
        public string Nume { get; set;}
        public string Magazin { get; set; }

        public decimal Pret { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Aparitiei")]
        public DateTime DataAparitiei { get; set; }
        [Display(Name = "Nume Producator")]
        public int ProducatorID { get; set; }
        
        public Producator Producator { get; set; }
        [Display(Name = "Categorii")]
        public ICollection<ToyCategory> ToyCategories { get; set; }
    }
}
