using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class StarshipCharacter
    {
        public int StarshipId { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public Starship Starship { get; set; }
    }
}
