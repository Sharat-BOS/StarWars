using Microsoft.EntityFrameworkCore;
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
            await _appDbContext.SaveChangesAsync(); ;
            var record = new Faction()
            {
                Id = faction.Id,
                FactionName = faction.FactionName
            };
            return await Task.FromResult(record);
        }

        public async Task<IList<Faction>> GetFaction()
        {
            return await Task.FromResult<IList<Faction>>(_appDbContext.Factions.Include(b=>b.Characters).ToList());
        }

        public async Task<Faction> GetFaction(int? Id)
        {
            return await Task.FromResult(_appDbContext.Factions.Include(b => b.Characters).FirstOrDefault(f => f.Id.Equals(Id)));
        }

        public async Task<string> DeleteFaction(int factionId)
        {
            var faction = _appDbContext.Factions.FirstOrDefault(f => f.Id == factionId);
            if (faction != null)
            {
                _appDbContext.Factions.Remove(faction);
                _appDbContext.SaveChanges();
                return await Task.FromResult("Deleted Successfully");
            }
            else {
                return await Task.FromResult("Record Not Found");
            }
        }

        public async Task<Faction> UpdateFaction(int factionId, Faction faction)
        {
            if (faction.Id == 0 && factionId != 0)
                faction.Id = factionId;
            /*_appDbContext.Factions.Update(factionDb);  */ //Update method updates all values if you want to set only specific use Attach
            _appDbContext.Factions.Update(faction);
            _appDbContext.Entry(faction).State = EntityState.Detached;  //Disable entity framework tracking.
            //Attach(faction).Property(p => p.FactionName).IsModified = true;
            await _appDbContext.SaveChangesAsync();
            return await Task.FromResult(faction);
        }

        public async Task<Faction> Associate_Character_To_Faction(int factionId, int characterId)
        {
            var faction = _appDbContext.Factions.Include(b => b.Characters).FirstOrDefault(f => f.Id == factionId);
            var character = _appDbContext.Characters.FirstOrDefault(c => c.Id == characterId);
            if (faction.Characters.Contains(character) != true) {
                faction.Characters.Add(character);
            }            
            character.FactionID = faction.Id;            
            await _appDbContext.SaveChangesAsync(); ;
            return await Task.FromResult(faction);
        }
        public async Task<Faction> Remove_Character_From_Faction(int factionId, int characterId)
        {
            var faction = _appDbContext.Factions.Include(b => b.Characters).FirstOrDefault(f => f.Id == factionId);
            var character = _appDbContext.Characters.FirstOrDefault(c => c.Id == characterId);
            faction.Characters.Remove(character);
            character.FactionID = null;
            await _appDbContext.SaveChangesAsync(); ;
            return await Task.FromResult(faction);
        }
    }
}
