using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class Faction
    {
        public int Id { get; set; }
        public string FactionName { get; set; }        //Empire or Rebels
    }

    public interface IFactionRepository
    {
        IEnumerable<Faction> GetAllFactions();
        Faction GetFactionByID(int factionId);

    }

    public class FactionRepository : IFactionRepository
    {
        private readonly AppDbContext _appDbContext;
        public FactionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Faction> GetAllFactions()
        {
            return _appDbContext.Factions;
        }

        public Faction GetFactionByID(int factionId)
        {
            return _appDbContext.Factions.FirstOrDefault(f => f.Id == factionId);
        }
    }

    public class Episode
    {
        public int Id { get; set; }
        public string EpisodeName { get; set; }
        public IList<Character> Cast { get; set; }
        //[NotMapped]
        //public IList<Starship> Starships { get; set; }       
    }

    public interface IEpisodeRepository
    {
        IEnumerable<Episode> GetAllEpisodes();
        Episode GetEpisodeByID(int episodeID);

    }

    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EpisodeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Episode> GetAllEpisodes()
        {
            return _appDbContext.Episodes;
        }

        public Episode GetEpisodeByID(int episodeId)
        {
            return _appDbContext.Episodes.FirstOrDefault(e => e.Id == episodeId);
        }
    }

    public class Character
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string CharacterName { get; set; }
        public int CharacterTypeID { get; set; }
        public CharacterType CharacterType { get; set; }
        public int CharacterGroupID { get; set; }
        public CharacterGroup CharacterGroup { get; set; }
        //public IList<Episode> AppersIn_Episodes { get; set; }
        //public IList<Starship> TravelsIn_Starships { get; set; }
        public IList<Starship> Owns_Starships { get; set; }
        [MaxLength(200)]
        public string HomePlanet { get; set; }
        [MaxLength(200)]
        public string Purpose { get; set; }
        public int FactionID { get; set; }
        public Faction Faction { get; set; }
        public string ImageUrl { get; internal set; }
    }


    public interface ICharacterRepository
    {
        IEnumerable<Character> GetAllCharacters();
        Character GetCharacterByID(int characterId);
    }


    public class CharacterRepository : ICharacterRepository
    {
        private readonly AppDbContext _appDbContext;
        public CharacterRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Character> GetAllCharacters()
        {
            return _appDbContext.Characters;
        }

        public Character GetCharacterByID(int characterId)
        {
            return _appDbContext.Characters.FirstOrDefault(c => c.Id == characterId);
        }
    }

    public class CharacterType
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string CharacterTypeName { get; set; }       
    }

    public interface ICharacterTypeRepository
    {
        IEnumerable<CharacterType> GetAllCharacterTypes();
        CharacterType GetCharacterTypeByID(int characterTypeId);
    }

    public class CharacterTypeRepository : ICharacterTypeRepository
    {
        private readonly AppDbContext _appDbContext;

        public IEnumerable<CharacterType> GetAllCharacterTypes()
        {
            return _appDbContext.CharacterTypes;
        }

        public CharacterType GetCharacterTypeByID(int characterTypeId)
        {
            return _appDbContext.CharacterTypes.FirstOrDefault(c => c.Id == characterTypeId);
        }
    }

    public class CharacterGroup
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string GroupName { get; set; }
    }

    public interface ICharacterGroupRepository
    {
        IEnumerable<CharacterGroup> GetAllCharacterGroups();
        CharacterGroup GetCharacterGroupByID(int characterGroupId);
    }

    public class CharacterGroupRepository : ICharacterGroupRepository
    {
        private readonly AppDbContext _appDbContext;
        public IEnumerable<CharacterGroup> GetAllCharacterGroups()
        {
            return _appDbContext.CharacterGroups;
        }

        public CharacterGroup GetCharacterGroupByID(int characterGroupId)
        {
            return _appDbContext.CharacterGroups.FirstOrDefault(c => c.Id == characterGroupId);
        }
    }
    public class Starship
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string StarshipName { get; set; }       
        //public int CharacterID { get; set; }
        public Character Commander { get; set; }
        public IList<Episode> AppersIn_Episodes { get; set; }
        public string ImageUrl { get; internal set; }      
    }

    public interface IStarshipRepository
    {
        IEnumerable<Starship> GetAllStarships();
        Starship GetStarshipByID(int starshipId);
    }

    public class StarshipRepository : IStarshipRepository
    {
        private readonly AppDbContext _appDbContext;
        public IEnumerable<Starship> GetAllStarships()
        {
            return _appDbContext.Starships;
        }

        public Starship GetStarshipByID(int starshipId)
        {
            return _appDbContext.Starships.FirstOrDefault(s => s.Id == starshipId);
        }
    }

}
