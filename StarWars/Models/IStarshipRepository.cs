using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public interface IStarshipRepository
    {
        Task<IList<Starship>> GetStarship();
        Task<Starship> GetStarship(int Id);
        Task<Starship> AddStarship(Starship starship);
        Task<Starship> UpdateStarship(int starshipId, Starship starship);
        Task<string> DeleteStarship(int Id);
        Task<Starship> Associate_Character_With_Starship(int starshipId, int characterID);
        Task<Starship> Remove_Character_From_Starship(int starshipId, int characterID);
        Task<IList<Starship>> GetStarshipsByCharacterId(int id);
    }
}
