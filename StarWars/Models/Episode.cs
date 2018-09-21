using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class Episode
    {
        public Episode()
        {
            Cast = new List<EpisodeCharacter>();
        }
        public int Id { get; set; }
        public string EpisodeName { get; set; }
        public IList<EpisodeCharacter> Cast { get; set; }
        //[NotMapped]
        //public IList<Starship> Starships { get; set; }       
    }
}
