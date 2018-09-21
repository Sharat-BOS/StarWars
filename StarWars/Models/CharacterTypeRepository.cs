using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class CharacterTypeRepository : ICharacterTypeRepository
    {
        private readonly AppDbContext _appDbContext;
        public CharacterTypeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<IList<CharacterType>> GetCharacterType()
        {
            return await Task.FromResult<IList<CharacterType>>(_appDbContext.CharacterTypes.ToList());
        }

        public async Task<CharacterType> GetCharacterType(int Id)
        {
            return await Task.FromResult(_appDbContext.CharacterTypes.FirstOrDefault(c => c.Id == Id));
        }
    }
}
