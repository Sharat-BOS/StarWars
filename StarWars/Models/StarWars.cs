using GraphQL;
using GraphQL.Types;
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
        public IList<Character> Characters { get; set; }
    }
       
    public interface IFactionRepository
    {
        Task<Faction> GetFaction(int factionId);
        Task<IList<Faction>> GetFaction();
        Task<Faction> UpdateFaction(int factionId, Faction faction);
        Task<Faction> AddFaction(Faction faction);
        Task<string>  DeleteFaction(int factionId);
        Task<Faction> Associate_Character_To_Faction(int factionId,int characterId);
        Task<Faction> Remove_Character_From_Faction(int factionId, int characterId);
    }

    public class FactionRepository : IFactionRepository
    {
        private readonly AppDbContext _appDbContext;
        public FactionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<Faction> AddFaction(Faction faction)
        {

            //if(faction.Characters!=null && faction.Characters.Count > 0){
            //    _appDbContext.AddRange(faction, faction.Characters);

            //}
            //else
            _appDbContext.Factions.Add(faction);
            _appDbContext.SaveChanges();
            return Task.FromResult(faction);
        }

        public Task<IList<Faction>> GetFaction()
        {
            return Task.FromResult<IList<Faction>>(_appDbContext.Factions.ToList());
        }

        public Task<Faction> GetFaction(int Id)
        {
            return Task.FromResult(_appDbContext.Factions.FirstOrDefault(f => f.Id == Id));
        }

        public Task<string> DeleteFaction(int factionId)
        {
            var faction= _appDbContext.Factions. FirstOrDefault(f => f.Id == factionId);
            _appDbContext.Factions.Remove(faction);
            return Task.FromResult("Deleted Successfully");
        }

        public Task<Faction> UpdateFaction(int factionId, Faction faction)
        {
            if (faction.Id == 0 && factionId != 0)
                faction.Id = factionId;
           /*_appDbContext.Factions.Update(factionDb);  */              //Update method updates all values if you want to set only specific use Attach
            _appDbContext.Factions.Attach(faction).Property(p => p.FactionName).IsModified = true;
            _appDbContext.SaveChanges();
            return Task.FromResult(faction);
        }

        public Task<Faction> Associate_Character_To_Faction(int factionId, int characterId)
        {
           var faction= _appDbContext.Factions.FirstOrDefault(f => f.Id == factionId);
           var character= _appDbContext.Characters.FirstOrDefault(c => c.Id == characterId);
            faction.Characters.Add(character);
            _appDbContext.SaveChanges();
            return Task.FromResult(faction);
        }
        public Task<Faction> Remove_Character_From_Faction(int factionId, int characterId)
        {
            var faction = _appDbContext.Factions.FirstOrDefault(f => f.Id == factionId);
            var character = _appDbContext.Characters.FirstOrDefault(c => c.Id == characterId);
            faction.Characters.Remove(character);
            _appDbContext.SaveChanges();
            return Task.FromResult(faction);
        }
    }

    public class Episode
    {
        public int Id { get; set; }
        public string EpisodeName { get; set; }
        public IList<EpisodeCharacter> Cast { get; set; }
        //[NotMapped]
        //public IList<Starship> Starships { get; set; }       
    }

    public interface IEpisodeRepository
    {
         Task<IList<Episode>> GetEpisode();
         Task<Episode> GetEpisode(int Id);
         Task<Episode> AddEpisode(Episode episode);
         Task<Episode> UpdateEpisode(int episodeId, Episode episode);
         Task<string> DeleteEpisode(int episodeId);
         Task<Episode> Associate_Character_With_Episode(int episodeId,int characterID);
         Task<Episode> Remove_Character_From_Episode(int episodeId, int characterID);
    }

    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EpisodeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<Episode> AddEpisode(Episode episode)
        {
            _appDbContext.Episodes.Add(episode);
            _appDbContext.SaveChanges();
            return Task.FromResult(episode);
        }
        public Task<Episode> UpdateEpisode(int episodeId, Episode episode)
        {
            if (episode.Id == 0 && episodeId != 0)
                episode.Id = episodeId;
            //Update method updates all values if you want to set only specific use Attach
            _appDbContext.Episodes.Attach(episode).Property(p => p.EpisodeName).IsModified = true;            
            _appDbContext.SaveChanges();
            return Task.FromResult(episode);
        }
        public Task<Episode> Associate_Character_With_Episode(int episodeId, int characterID)
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
            episode.Cast.Add(episodeCharacter);
            _appDbContext.SaveChanges();
            return Task.FromResult(episode);
        }

        public Task<Episode> Remove_Character_From_Episode(int episodeId, int characterID)
        {
            var episode = _appDbContext.Episodes.FirstOrDefault(f => f.Id == episodeId);
            var episodeCharacter = _appDbContext.EpisodeCharacter.FirstOrDefault(c => c.EpisodeId == episodeId && c.CharacterId == characterID);
            episode.Cast.Remove(episodeCharacter);
            _appDbContext.SaveChanges();
            return Task.FromResult(episode);
        }

        public Task<string> DeleteEpisode(int episodeId)
        {
            var episode = _appDbContext.Episodes.FirstOrDefault(f => f.Id == episodeId);
            _appDbContext.Episodes.Remove(episode);
            return Task.FromResult("Deleted Successfully");
        }
        public Task<Episode> GetEpisode(int Id)
        {
            return Task.FromResult(_appDbContext.Episodes.FirstOrDefault(e => e.Id == Id));
        }
        public Task<IList<Episode>> GetEpisode()
        {
            return Task.FromResult<IList<Episode>>(_appDbContext.Episodes.ToList());
        }

    }

    public class EpisodeCharacter
    {
        public int EpisodeId { get; set; }
        public int CharacterId { get; set; }
        public Episode Episode { get; set; }
        public Character Character { get; set; }            
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
        public IList<EpisodeCharacter> AppersIn_Episodes { get; set; }        
        public IList<StarshipCharacter> Starships { get; set; }
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
        Task<IList<Character>> GetCharacter();
        Task<Character> GetCharacter(int Id);
        Task<IList<Character>> GetCharactersByFactionID(int Id);
        Task<Character> AddCharacter(Character character);
        Task<Character> UpdateCharacter(int characterId, Character character);
        Task<string> DeleteCharacter(int Id);
        Task<Character> Associate_Episode_With_Character(int episodeId, int characterID);
        Task<Character> Remove_Episode_From_Character(int episodeId, int characterID);
    }


    public class CharacterRepository : ICharacterRepository
    {
        private readonly AppDbContext _appDbContext;
        public CharacterRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<IList<Character>> GetCharacter()
        {
            return Task.FromResult<IList<Character>>(_appDbContext.Characters.ToList());
        }

        public Task<Character> GetCharacter(int Id)
        {
            return Task.FromResult(_appDbContext.Characters.FirstOrDefault(c => c.Id == Id));
        }

        public Task<Character> AddCharacter(Character character)
        {
            _appDbContext.Characters.Add(character);
            _appDbContext.SaveChanges();
            return Task.FromResult(character);
        }
        public Task<Character> UpdateCharacter(int characterId, Character character)
        {
            if (character.Id == 0 && characterId != 0)
                character.Id = characterId;
            //Update method updates all values if you want to set only specific use Attach
            _appDbContext.Characters.Update(character);
            _appDbContext.SaveChanges();
            return Task.FromResult(character);
        }
        public Task<Character> Associate_Episode_With_Character(int episodeId, int characterID)
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
            return Task.FromResult(character);
        }

        public Task<Character> Remove_Episode_From_Character(int episodeId, int characterID)
        {
            var character = _appDbContext.Characters.FirstOrDefault(f => f.Id == characterID);
            var episodeCharacter = _appDbContext.EpisodeCharacter.FirstOrDefault(c => c.EpisodeId == episodeId && c.CharacterId == characterID);
            character.AppersIn_Episodes.Remove(episodeCharacter);
            _appDbContext.SaveChanges();
            return Task.FromResult(character);
        }

        public Task<string>  DeleteCharacter(int Id)
        {
            var character = _appDbContext.Characters.FirstOrDefault(f => f.Id == Id);
            _appDbContext.Characters.Remove(character);
            return Task.FromResult("Deleted Successfully");
        }

        public Task<IList<Character>> GetCharactersByFactionID(int Id)
        {
            return Task.FromResult<IList<Character>>(_appDbContext.Characters.Where(c => c.FactionID == Id).ToList());
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
        Task<IList<CharacterType>> GetCharacterType();
        Task<CharacterType> GetCharacterType(int Id);
    }

    public class CharacterTypeRepository : ICharacterTypeRepository
    {
        private readonly AppDbContext _appDbContext;
        public CharacterTypeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public Task<IList<CharacterType>> GetCharacterType()
        {
            return Task.FromResult<IList<CharacterType>>(_appDbContext.CharacterTypes.ToList());
        }

        public Task<CharacterType> GetCharacterType(int Id)
        {
            return Task.FromResult(_appDbContext.CharacterTypes.FirstOrDefault(c => c.Id == Id));
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
        Task<IList<CharacterGroup>> GetCharacterGroup();
        Task<CharacterGroup> GetCharacterGroup(int Id);
    }

    public class CharacterGroupRepository : ICharacterGroupRepository
    {
        private readonly AppDbContext _appDbContext;
        public CharacterGroupRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<IList<CharacterGroup>> GetCharacterGroup()
        {
            return Task.FromResult<IList<CharacterGroup>>(_appDbContext.CharacterGroups.ToList());
        }

        public Task<CharacterGroup> GetCharacterGroup(int Id)
        {
            return Task.FromResult(_appDbContext.CharacterGroups.FirstOrDefault(c => c.Id == Id));
        }
    }
    public class Starship
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string StarshipName { get; set; }       
        //public int CharacterID { get; set; }
        public IList<StarshipCharacter> Characters { get; set; }
        public IList<Episode> AppersIn_Episodes { get; set; }
        public string ImageUrl { get; internal set; }      
    }

    public class StarshipCharacter {
        public int StarshipId { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public Starship Starship { get; set; } 
    }

    public interface IStarshipRepository
    {
        Task<IList<Starship>> GetStarship();
        Task<Starship> GetStarship(int Id);
        Task<Starship> AddStarship(Starship starship);
        Task<Starship> UpdateStarship(int starshipId, Starship starship);
        Task<string> DeleteStarship(int Id);
        Task<Starship> Associate_Character_With_Starship(int starshipId, int characterID);
        Task<Starship> Remove_Character_From_Starship(int starshipId, int characterID);
    }
    
    public class StarshipRepository : IStarshipRepository
    {
        private readonly AppDbContext _appDbContext;
        public StarshipRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<Starship> AddStarship(Starship starship)
        {
            _appDbContext.Starships.Add(starship);
            _appDbContext.SaveChanges();
            return Task.FromResult(starship);
        }
        

        public Task<Starship> UpdateStarship(int starshipId, Starship starship)
        {
            if (starship.Id == 0 && starshipId != 0)
                starship.Id = starshipId;
            //Update method updates all values if you want to set only specific use Attach
            _appDbContext.Starships.Update(starship);
            _appDbContext.SaveChanges();
            return Task.FromResult(starship);
        }


        public Task<Starship> Associate_Character_With_Starship(int starshipId, int characterID)
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
            return Task.FromResult(starship);
        }
        public Task<Starship> Remove_Character_From_Starship(int starshipId, int characterID)
        {

            var starship = _appDbContext.Starships.FirstOrDefault(f => f.Id == starshipId);
            var starshipCharacter = _appDbContext.StarshipCharacter.FirstOrDefault(c => c.StarshipId == starshipId && c.CharacterId == characterID);
            starship.Characters.Remove(starshipCharacter);
            _appDbContext.SaveChanges();
            return Task.FromResult(starship);
        }

        public Task<string>  DeleteStarship(int Id)
        {
            var starship = _appDbContext.Starships.FirstOrDefault(f => f.Id == Id);
            _appDbContext.Starships.Remove(starship);
            return Task.FromResult("Deleted Successfully");
        }

        public Task<IList<Starship>> GetStarship()
        {
            return Task.FromResult<IList<Starship>>(_appDbContext.Starships.ToList());
        }

        public Task<Starship> GetStarship(int Id)
        {
            return Task.FromResult(_appDbContext.Starships.FirstOrDefault(s => s.Id == Id));
        }
              
    }


    #region StarWarsGraphQL Types

    public class FactionQLType : ObjectGraphType<Faction>
    {
        public FactionQLType(IFactionRepository factionRepository, ICharacterRepository characterRepository)
        {
            Field(x => x.Id).Description("Faction id.");
            Field(x => x.FactionName, nullable: false).Description("Faction name.");
            Field<ListGraphType<CharacterQLType>>("Characters","Faction Characters");
        //    (
        //    "Characters",
        //    resolve: context => characterRepository.GetCharactersByFactionID(context.Source.Id).Result.ToList()
        //);
    }
    }
    public class EpisodeQLType : ObjectGraphType<Episode>
    {
        public EpisodeQLType(IFactionRepository factionRepository, ICharacterRepository characterRepository)
        {
            Field(x => x.Id).Description("Episode id.");
            Field(x => x.EpisodeName, nullable: false).Description("Episode name.");
            Field<ListGraphType<EpisodeCharacterQLType>>("EpisodeCharacter", "Episode Characters");            
        }
    }
    public class EpisodeCharacterQLType : ObjectGraphType<EpisodeCharacter>
    {
        public EpisodeCharacterQLType()
        {
            Field(x => x.EpisodeId).Description("Episode id.");
            Field(x => x.CharacterId).Description("Episode id.");
            Field<ObjectGraphType<CharacterQLType>>("Character", "Character Object");
            Field<ObjectGraphType<EpisodeQLType>>("Episode", "Episode Object");
        }
    }

    public class CharacterQLType : ObjectGraphType<Character>
    {
        public CharacterQLType(IFactionRepository factionRepository, ICharacterRepository characterRepository)
        {
            Field(x => x.Id).Description("Character id.");
            Field(x => x.CharacterName, nullable: false).Description("Character name.");
            Field<ObjectGraphType<FactionQLType>>("Faction", "Character Faction");
            Field(x => x.CharacterTypeID, nullable: true).Description("Character Type ID.");
            Field<ObjectGraphType<CharacterTypeQLType>>("CharacterType", "Type of Character");           
            Field(x => x.CharacterGroupID, nullable: false).Description("Character Group ID.");
            Field<ObjectGraphType<CharacterGroupQLType>>("CharacterGroup", "Character Group");
            Field<ObjectGraphType<EpisodeCharacterQLType>>("AppersIn_Episodes", "character appears in following Episodes");
            Field<ObjectGraphType<StarshipCharacterQLType>>("Starships", "character Starships");
            Field(x => x.HomePlanet, nullable: false).Description("Character HomePlanet.");
            Field(x => x.Purpose, nullable: false).Description("Character Purpose.");
            Field(x => x.FactionID, nullable: false).Description("Character FactionID.");
            Field<ObjectGraphType<FactionQLType>>("Faction", "character Faction");
            Field(x => x.ImageUrl, nullable: false).Description("Character ImageUrl.");
        //    (
        //    "Faction",
        //    resolve: context => factionRepository.GetFactionByID(context.Source.).Result.ToList()
        //);
    }
}
    public class CharacterTypeQLType : ObjectGraphType<CharacterType>
    {
        public CharacterTypeQLType()
        {
            Field(x => x.Id).Description("Character id.");
            Field(x => x.CharacterTypeName, nullable: false).Description("Name of character type.");            
        }
    }
    public class CharacterGroupQLType : ObjectGraphType<CharacterGroup>
    {
        public CharacterGroupQLType()
        {
            Field(x => x.Id).Description("Character id.");
            Field(x => x.GroupName, nullable: false).Description("Name of character group.");
        }
    }
    public class StarshipQLType : ObjectGraphType<Starship>
    {
        public StarshipQLType()
        {
            Field(x => x.Id).Description("Starship id.");
            Field(x => x.StarshipName, nullable: false).Description("StarshipName name.");
            Field<ListGraphType<StarshipCharacterQLType>>("Characters", "Characters in side the starship, who own or command or travel in a starship");
            Field<ObjectGraphType<EpisodeQLType>>("AppersIn_Episodes", "Episodes in which starship makes an appearance");
            Field(x => x.ImageUrl, nullable: false).Description("Starship ImageUrl.");
        }
    }
    public class StarshipCharacterQLType : ObjectGraphType<StarshipCharacter>
    {
        public StarshipCharacterQLType()
        {
            Field(x => x.StarshipId).Description("Starship id.");
            Field(x => x.CharacterId).Description("Episode id.");
            Field<ObjectGraphType<CharacterQLType>>("Character", "Character Object");
            Field<ObjectGraphType<StarshipQLType>>("Starship", "Starship Object");
        }
    }


    #endregion




    #region
    public class StarWarsQuery : ObjectGraphType
    {
        public StarWarsQuery(ICharacterRepository characterRepository, IFactionRepository factionRepository, IEpisodeRepository episodeRepository, ICharacterGroupRepository characterGroupRepository, ICharacterTypeRepository characterTypeRepository, IStarshipRepository starshipRepository)
        {
            Field<FactionQLType>(
                "faction",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "faction id" }
                ),
                resolve: context => factionRepository.GetFaction(context.GetArgument<int>("id")).Result
            );

            Field<EpisodeQLType>(
                "episode",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "episode id" }
                ),
                resolve: context => episodeRepository.GetEpisode(context.GetArgument<int>("id")).Result
            );

            Field<CharacterQLType>(
                "character",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "character id" }
                ),
                resolve: context => characterRepository.GetCharacter(context.GetArgument<int>("id")).Result
            );

            Field<StarshipQLType>(
                "starship",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "starship id" }
                ),
                resolve: context => starshipRepository.GetStarship(context.GetArgument<int>("id")).Result
            );
        }
    }

    public class StarWarsSchema : Schema
    {
        //public StarWarsSchema(IDependencyResolver resolver) : base(resolver)
        //{
        //    Query = (StarWarsQuery)resolveType(typeof(StarWarsQuery));
        //    Query = resolver.Resolve<StarWarsQuery>();
        //    Mutation = resolver.Resolve<NHLStatsMutation>();
        //}

        public StarWarsSchema(Func<Type, GraphType> resolveType)
            : base(resolveType)
        {
            Query = (StarWarsQuery)resolveType(typeof(StarWarsQuery));
        }
    }


    public class StarWarsQLQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public string Variables { get; set; }
    }
    #endregion









}
