using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class DbInitializer
    {
        //in previous versions of ASP.NET core we usually call this seed method from Startup.cs file. But Microsoft now recommends to call this from Program.cs class which is now best practice
        public static void Seed(AppDbContext context)
        {
            if (!context.Pies.Any())
            {
                context.AddRange(
                    new Pie { Name = "Apple Pie", Price = 12.95, ShortDescription = "short pie", LongDescription = "", ImageUrl = "" },
                    new Pie { Name = "Blueberry Pie", Price = 11.95, ShortDescription = "", LongDescription = "", ImageUrl = "" },
                    new Pie { Name = "Cheese Cake", Price = 15.95, ShortDescription = "", LongDescription = "", ImageUrl = "" },
                    new Pie { Name = "Cherry Pie", Price = 10.95, ShortDescription = "", LongDescription = "", ImageUrl = "" }
                );
                context.SaveChanges();
            }

            if (!context.Factions.Any())
            {
                context.AddRange(
                    new Faction { FactionName = "Empire" },
                    new Faction { FactionName = "Repbels" },
                    new Faction { FactionName = "Sith" },
                    new Faction { FactionName = "Jedi" }
                );
                context.SaveChanges();
            }

            if (!context.Episodes.Any())
            {
                context.AddRange(
                    new Episode { EpisodeName = "Episode I - The Phantom Menace (1999)" },
                    new Episode { EpisodeName = "Episode II - Attack of the Clones (2002)" },
                    new Episode { EpisodeName = "Episode II - Attack of the Clones (2002)" },
                    new Episode { EpisodeName = "Episode IV - Star Wars: A New Hope (1977)" },
                    new Episode { EpisodeName = "Episode V - The Empire Strikes Back (1980)" },
                    new Episode { EpisodeName = "Episode VI - Return of the Jedi (1983)" },
                    new Episode { EpisodeName = "Episode VII - The Force Awakens (2015)" },
                    new Episode { EpisodeName = "Episode VIII - The Last Jedi (2017)" }
                );
                context.SaveChanges();
            }

           

            if (!context.CharacterTypes.Any())
            {
                context.AddRange(
                    new CharacterType { CharacterTypeName = "Hero" },
                    new CharacterType { CharacterTypeName = "Villan" },
                    new CharacterType { CharacterTypeName = "Side Kick" },
                    new CharacterType { CharacterTypeName = "Extra" }
                );
                context.SaveChanges();
            }
            if (!context.CharacterGroups.Any())
            {
                context.AddRange(
                    new CharacterGroup { GroupName = "Human" },
                    new CharacterGroup { GroupName = "Droid" },
                    new CharacterGroup { GroupName = "Alien" },
                    new CharacterGroup { GroupName = "Human Clone" }
                );
                context.SaveChanges();
            }
            if (!context.Starships.Any())
            {
                context.AddRange(
                    new Starship { StarshipName = "Death Star", ImageUrl = "" },
                    new Starship { StarshipName = "Tyranus's solar sailer" },
                    new Starship { StarshipName = "Imperial Landing Craft" },
                    new Starship { StarshipName = "Millennium Falcon" },
                    new Starship { StarshipName = "Naboo Royal Cruiser" },
                    new Starship { StarshipName = "Republic Assault Ship" },
                    new Starship { StarshipName = "Republic Assault Ship" },
                    new Starship { StarshipName = "TIE interceptor" },
                     new Starship { StarshipName = "Jedi starfighter(Delta - 7)", ImageUrl = "https://starwarsblog.starwars.com/wp-content/uploads/sites/6/2013/09/jedi-starfighter-delta-7-400x266.jpg" }

                );
                context.SaveChanges();
            }

            if (!context.Characters.Any())
            {
                context.AddRange(
                    new Character { CharacterName = "Jango Fett", CharacterGroupID = 4, CharacterTypeID = 2, FactionID = 1, HomePlanet = "Kamino Cloning Facility", ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2018/06/rs-218677-43-jango-fett-48836392-a75d-46cd-9fa5-0e6927eae162.jpg?crop=1260:720&width=1260" },
                    new Character { CharacterName = "Padmé Amidala", CharacterGroupID = 1, CharacterTypeID = 1, FactionID = 2, HomePlanet = "Nabu", ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2018/06/rs-218676-42-Padme-Amidala.jpg?crop=1260:720&width=1260" },
                    new Character { CharacterName = "Q’ira", CharacterGroupID = 4, CharacterTypeID = 1, FactionID = 2, HomePlanet = "Game Of Thrones", ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2018/06/emilia-clarke-solo-a-star-wars-story-85c0e6d8-9f9d-49c1-8d31-9df375f1b904.jpg" },
                   new Character { CharacterName = "Yoda", CharacterGroupID = 3, CharacterTypeID = 1, FactionID = 4, HomePlanet = "", ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2018/06/rs-218589-4-yoda-6a430ef2-4be5-43d5-8614-e743ca7b2f69.jpg?crop=1260:720&width=1260" },
                   new Character { CharacterName = "Darth Vader", CharacterGroupID = 2, CharacterTypeID = 2, FactionID = 1, HomePlanet = "Tatoine", ImageUrl = "https://www.rollingstone.com/wp-content/uploads/2018/06/rs-218586-2-vader-f6cdf838-912c-4bfa-8a12-f43521fbd99c.jpg?crop=1260:720&width=1260" }
                );
                context.SaveChanges();
            }           
        }
    }
}
