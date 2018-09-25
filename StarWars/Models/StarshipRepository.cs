using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class StarshipRepository : IStarshipRepository
    {
        private readonly AppDbContext _appDbContext;
        public StarshipRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Starship> AddStarship(Starship starship)
        {
            _appDbContext.Starships.Add(starship);
            _appDbContext.SaveChanges();
            return await Task.FromResult(starship);
        }


        public async Task<Starship> UpdateStarship(int starshipId, Starship starship)
        {
            if (starship.Id == 0 && starshipId != 0)
                starship.Id = starshipId;
            //Update method updates all values if you want to set only specific use Attach
            _appDbContext.Starships.Update(starship);
            _appDbContext.SaveChanges();
            return await Task.FromResult(starship);
        }


        public async Task<Starship> Associate_Character_With_Starship(int starshipId, int characterID)
        {
            var starship = _appDbContext.Starships.FirstOrDefault(f => f.Id == starshipId);
            var character = _appDbContext.Characters.FirstOrDefault(c => c.Id == characterID);
            var starshipCharacter = new StarshipCharacter
            {
                StarshipId = starshipId,
                CharacterId = characterID,
                Starship = starship,
                Character = character
            };
            starship.Characters.Add(starshipCharacter);
            _appDbContext.SaveChanges();
            return await Task.FromResult(starship);
        }
        public async Task<Starship> Remove_Character_From_Starship(int starshipId, int characterID)
        {

            var starship = _appDbContext.Starships.FirstOrDefault(f => f.Id == starshipId);
            var starshipCharacter = _appDbContext.StarshipCharacter.FirstOrDefault(c => c.StarshipId == starshipId && c.CharacterId == characterID);
            starship.Characters.Remove(starshipCharacter);
            _appDbContext.SaveChanges();
            return await Task.FromResult(starship);
        }

        public async Task<string> DeleteStarship(int Id)
        {
            var starship = _appDbContext.Starships.FirstOrDefault(f => f.Id == Id);
            if (starship != null)
            {
                _appDbContext.Starships.Remove(starship);
                _appDbContext.SaveChanges();
                return await Task.FromResult("Deleted Successfully");
            }
            else {
                return await Task.FromResult("Record Not Found");
            }            

        }

        public async Task<IList<Starship>> GetStarship()
        {
            return await Task.FromResult<IList<Starship>>(_appDbContext.Starships.ToList());
        }

        public async Task<Starship> GetStarship(int Id)
        {
            return await Task.FromResult(_appDbContext.Starships.FirstOrDefault(s => s.Id == Id));
        }

        public async Task<IList<Starship>> GetStarshipsByCharacterId(int Id)
        {
            // return list of episodes ID where Character ID  appears
            var ListofStarships = _appDbContext.StarshipCharacter.Where(s => s.CharacterId == Id).Select(r => r.StarshipId);
            var Starships = _appDbContext.Starships.Where(e => ListofStarships.Contains(e.Id));
            return await Task.FromResult(Starships.ToList());
        }
    }
}
