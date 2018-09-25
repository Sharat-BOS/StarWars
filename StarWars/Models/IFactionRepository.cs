using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public interface IFactionRepository
    {
        Task<Faction> GetFaction(int? factionId);
        Task<IList<Faction>> GetFaction();
        Task<Faction> UpdateFaction(int factionId, Faction faction);
        Task<Faction> AddFaction(Faction faction);
        Task<string> DeleteFaction(int factionId);
        Task<Faction> Associate_Character_To_Faction(int factionId, int characterId);
        Task<Faction> Remove_Character_From_Faction(int factionId, int characterId);        
    }
}
