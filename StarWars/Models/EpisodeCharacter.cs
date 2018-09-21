using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class EpisodeCharacter
    {
        public int EpisodeId { get; set; }
        public int CharacterId { get; set; }
        public Episode Episode { get; set; }
        public Character Character { get; set; }
    }
}
