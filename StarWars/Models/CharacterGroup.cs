using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class CharacterGroup
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string GroupName { get; set; }
    }
}
