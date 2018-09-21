using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class FactionRepository : IFactionRepository
    {
        private readonly AppDbContext _appDbContext;
        public FactionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Faction> AddFaction(Faction faction)
        {
            _appDbContext.Factions.Add(faction);
            _appDbContext.SaveChanges();
            return await Task.FromResult(faction);
        }

        public async Task<IList<Faction>> GetFaction()
        {
            return await Task.FromResult<IList<Faction>>(_appDbContext.Factions.ToList());
        }

        public async Task<Faction> GetFaction(int Id)
        {
            return await Task.FromResult(_appDbContext.Factions.FirstOrDefault(f => f.Id.Equals(Id)));
        }

        public async Task<string> DeleteFaction(int factionId)
        {
            var faction = _appDbContext.Factions.FirstOrDefault(f => f.Id == factionId);
            _appDbContext.Factions.Remove(faction);
            return await Task.FromResult("Deleted Successfully");
        }

        public async Task<Faction> UpdateFaction(int factionId, Faction faction)
        {
            if (faction.Id == 0 && factionId != 0)
                faction.Id = factionId;
            /*_appDbContext.Factions.Update(factionDb);  */              //Update method updates all values if you want to set only specific use Attach
            _appDbContext.Factions.Update(faction);
                //Attach(faction).Property(p => p.FactionName).IsModified = true;
            _appDbContext.SaveChanges();
            return await Task.FromResult(faction);
        }

        public async Task<Faction> Associate_Character_To_Faction(int factionId, int characterId)
        {
            var faction = _appDbContext.Factions.FirstOrDefault(f => f.Id == factionId);
            var character = _appDbContext.Characters.FirstOrDefault(c => c.Id == characterId);
            faction.Characters.Add(character);
            _appDbContext.SaveChanges();
            return await Task.FromResult(faction);
        }
        public async Task<Faction> Remove_Character_From_Faction(int factionId, int characterId)
        {
            var faction = _appDbContext.Factions.FirstOrDefault(f => f.Id == factionId);
            var character = _appDbContext.Characters.FirstOrDefault(c => c.Id == characterId);
            faction.Characters.Remove(character);
            _appDbContext.SaveChanges();
            return await Task.FromResult(faction);
        }
    }
}
