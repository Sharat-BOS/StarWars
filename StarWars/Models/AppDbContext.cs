using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace StarWars.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

         public DbSet<Pie> Pies { get; set; }

        public DbSet<Faction> Factions { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterType> CharacterTypes { get; set; }
        public DbSet<CharacterGroup> CharacterGroups { get; set; }
        public DbSet<Starship> Starships { get; set; }

    }
}
