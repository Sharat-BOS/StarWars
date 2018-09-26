using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class Faction
    {
        public Faction()
        {
            Characters = new List<Character>();
        }
        public int Id { get; set; }
        public string FactionName { get; set; }        //Empire or Rebels
        public IList<Character> Characters { get; set; }
        public string ImageUrl { get; set; }
    }
}
