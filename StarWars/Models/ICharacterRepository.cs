using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public interface ICharacterRepository
    {
        Task<IList<Character>> GetCharacter();
        Task<Character> GetCharacter(int Id);
        Task<IList<Character>> GetCharactersByFactionID(int Id);
        Task<Character> AddCharacter(Character character);
        Task<Character> UpdateCharacter(int characterId, Character character);
        Task<string> DeleteCharacter(int Id);
        Task<Character> Associate_Episode_With_Character(int episodeId, int characterID);
        Task<Character> Remove_Episode_From_Character(int episodeId, int characterID);
    }
}
