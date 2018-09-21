using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public interface ICharacterGroupRepository
    {
        Task<IList<CharacterGroup>> GetCharacterGroup();
        Task<CharacterGroup> GetCharacterGroup(int Id);
    }
}
