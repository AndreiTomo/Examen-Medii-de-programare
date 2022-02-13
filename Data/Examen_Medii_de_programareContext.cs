using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Examen_Medii_de_programare.Torpenyi_Andrei_Examen.Models;

namespace Examen_Medii_de_programare.Data
{
    public class Examen_Medii_de_programareContext : DbContext
    {
        public Examen_Medii_de_programareContext (DbContextOptions<Examen_Medii_de_programareContext> options)
            : base(options)
        {
        }

        public DbSet<Examen_Medii_de_programare.Torpenyi_Andrei_Examen.Models.Toy> Toy { get; set; }

        public DbSet<Examen_Medii_de_programare.Torpenyi_Andrei_Examen.Models.Producator> Producator { get; set; }

        public DbSet<Examen_Medii_de_programare.Torpenyi_Andrei_Examen.Models.Category> Category { get; set; }
    }
}
