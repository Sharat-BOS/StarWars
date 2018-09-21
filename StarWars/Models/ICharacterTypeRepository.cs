using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public interface ICharacterTypeRepository
    {
        Task<IList<CharacterType>> GetCharacterType();
        Task<CharacterType> GetCharacterType(int Id);
    }
}
