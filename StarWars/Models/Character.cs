using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{

    public class Character
    {
        public Character()
        {
            AppersIn_Episodes = new List<EpisodeCharacter>();
            Starships = new List<StarshipCharacter>();
        }

        public int Id { get; set; }
        [MaxLength(200)]
        public string CharacterName { get; set; }
        public int CharacterTypeID { get; set; }
        public CharacterType CharacterType { get; set; }
        public int CharacterGroupID { get; set; }
        public CharacterGroup CharacterGroup { get; set; }
        public IList<EpisodeCharacter> AppersIn_Episodes { get; set; }
        public IList<StarshipCharacter> Starships { get; set; }
        [MaxLength(200)]
        public string HomePlanet { get; set; }
        [MaxLength(200)]
        public string Purpose { get; set; }
        public int? FactionID { get; set; }
        public virtual Faction Faction { get; set; }
        public string ImageUrl { get; internal set; }

    }
}
