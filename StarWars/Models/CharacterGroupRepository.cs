using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class CharacterGroupRepository : ICharacterGroupRepository
    {
        private readonly AppDbContext _appDbContext;
        public CharacterGroupRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IList<CharacterGroup>> GetCharacterGroup()
        {
            return await Task.FromResult<IList<CharacterGroup>>(_appDbContext.CharacterGroups.ToList());
        }

        public async Task<CharacterGroup> GetCharacterGroup(int Id)
        {
            return await Task.FromResult(_appDbContext.CharacterGroups.FirstOrDefault(c => c.Id == Id));
        }
    }
}
