using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class Starship
    {
        public Starship()
        {
            Characters = new List<StarshipCharacter>();
            AppersIn_Episodes = new List<Episode>();
        }
        public int Id { get; set; }
        [MaxLength(50)]
        public string StarshipName { get; set; }
        //public int CharacterID { get; set; }
        public IList<StarshipCharacter> Characters { get; set; }
        public IList<Episode> AppersIn_Episodes { get; set; }
        public string ImageUrl { get; internal set; }
    }
}
