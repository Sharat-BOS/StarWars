using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
namespace StarWars.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        ////Log to see EF command in console
        //public static readonly LoggerFactory loggerFactory = new LoggerFactory(new[] { new ConsoleLoggerProvider((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information, true) });

        protected override void OnModelCreating(ModelBuilder modelBuilder) {


            modelBuilder.Entity<Faction>().HasIndex(f => f.FactionName).IsUnique();
            modelBuilder.Entity<Episode>().HasIndex(e => e.EpisodeName).IsUnique();
            modelBuilder.Entity<Starship>().HasIndex(s => s.StarshipName).IsUnique();
            modelBuilder.Entity<EpisodeCharacter>().HasKey(e => new { e.EpisodeId, e.CharacterId });
            modelBuilder.Entity<StarshipCharacter>().HasKey(e => new { e.StarshipId, e.CharacterId });
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLoggerFactory(loggerFactory);
        //}

        public DbSet<Pie> Pies { get; set; }

        public DbSet<Faction> Factions { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<EpisodeCharacter> EpisodeCharacter { get; set; }
        public DbSet<StarshipCharacter> StarshipCharacter { get; set; }
        public DbSet<CharacterType> CharacterTypes { get; set; }
        public DbSet<CharacterGroup> CharacterGroups { get; set; }
        public DbSet<Starship> Starships { get; set; }

    }
}
