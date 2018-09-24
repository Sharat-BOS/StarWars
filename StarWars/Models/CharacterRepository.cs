using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly AppDbContext _appDbContext;
        public CharacterRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IList<Character>> GetCharacter()
        {            
            return await Task.FromResult<IList<Character>>(_appDbContext.Characters.Include(c => c.Faction).Include(c=>c.CharacterGroup).Include(c=>c.CharacterType).ToList());
        }

        public async Task<Character> GetCharacter(int Id)
        {
            return await Task.FromResult(_appDbContext.Characters.Include(c => c.Faction).Include(c => c.CharacterGroup).Include(c => c.CharacterType).FirstOrDefault(c => c.Id == Id));
        }

        public async Task<Character> AddCharacter(Character character)
        {
            _appDbContext.Characters.Add(character);
            _appDbContext.SaveChanges();
            return await Task.FromResult(character);
        }
        public async Task<Character> UpdateCharacter(int characterId, Character character)
        {
            if (character.Id == 0 && characterId != 0)
                character.Id = characterId;
            //Update method updates all values if you want to set only specific use Attach
            _appDbContext.Characters.Update(character);
            _appDbContext.SaveChanges();
            return await Task.FromResult(character);
        }
        public async Task<Character> Associate_Episode_With_Character(int episodeId, int characterID)
        {
            var episode = _appDbContext.Episodes.FirstOrDefault(f => f.Id == episodeId);
            var character = _appDbContext.Characters.FirstOrDefault(c => c.Id == characterID);
            var episodeCharacter = new EpisodeCharacter
            {
                EpisodeId = episodeId,
                CharacterId = characterID,
                Episode = episode,
                Character = character
            };
            character.AppersIn_Episodes.Add(episodeCharacter);
            _appDbContext.SaveChanges();
            return await Task.FromResult(character);
        }

        public async Task<Character> Remove_Episode_From_Character(int episodeId, int characterID)
        {
            var character = _appDbContext.Characters.FirstOrDefault(f => f.Id == characterID);
            var episodeCharacter = _appDbContext.EpisodeCharacter.FirstOrDefault(c => c.EpisodeId == episodeId && c.CharacterId == characterID);
            character.AppersIn_Episodes.Remove(episodeCharacter);
            _appDbContext.SaveChanges();
            return await Task.FromResult(character);
        }

        public async Task<string> DeleteCharacter(int Id)
        {
            var character = _appDbContext.Characters.FirstOrDefault(f => f.Id == Id);
            _appDbContext.Characters.Remove(character);
            return await Task.FromResult("Deleted Successfully");
        }

        public async Task<IList<Character>> GetCharactersByFactionID(int Id)
        {
            return await Task.FromResult<IList<Character>>(_appDbContext.Characters.Where(c => c.FactionID == Id).ToList());
        }
    }
}
