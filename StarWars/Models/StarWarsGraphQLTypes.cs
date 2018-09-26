using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    #region StarWarsGraphQL Types

    public class FactionQLType : ObjectGraphType<Faction>
    {
        public FactionQLType(IFactionRepository factionRepository, ICharacterRepository characterRepository)
        {
            Field(x => x.Id).Description("Faction id.");
            Field(x => x.FactionName, nullable: false).Description("Faction name.");
            Field<ListGraphType<CharacterQLType>>("Characters", "Faction Characters");
            Field(x => x.ImageUrl, nullable: true).Description("ImageUrl.");
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
            Field<ListGraphType<CharacterQLType>>("Cast", "Episode Characters",
                 resolve: context => characterRepository.GetCharactersByEpisodeId(context.Source.Id)
                );
            Field(x => x.Summary, nullable: true).Description("Summary.");
            Field(x => x.ImageUrl, nullable: true).Description("ImageUrl.");
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
        public CharacterQLType(IFactionRepository factionRepository, ICharacterRepository characterRepository, ICharacterTypeRepository characterTypeRepository, ICharacterGroupRepository characterGroupRepository,IEpisodeRepository  episodeRepository,IStarshipRepository starshipRepository)
        {
            Field(x => x.Id).Description("Character id.");
            Field(x => x.CharacterName, nullable: false).Description("Character name.");
            Field(x => x.CharacterTypeID, nullable: true).Description("Character Type ID.");           
            Field<CharacterTypeQLType>("CharacterType", "Character Type",
                resolve: context => characterTypeRepository.GetCharacterType(context.Source.CharacterTypeID)
                );
            Field(x => x.CharacterGroupID, nullable: false).Description("Character Group ID.");
            Field<CharacterGroupQLType>("CharacterGroup", "Character Group",
                arguments: new QueryArguments( new QueryArgument<IntGraphType>() {
                    Name = "id",
                    Description = "Character Group ID."
                }),
               resolve: context => characterGroupRepository.GetCharacterGroup(context.Source.CharacterGroupID)
               );
            Field<ListGraphType<EpisodeQLType>>("AppersIn_Episodes", "character appears in following Episodes",
                 arguments: new QueryArguments(new QueryArgument<IntGraphType>()
                 {
                     Name = "id",
                     Description = "Character ID."
                 }),
               resolve: context => episodeRepository.GetEpisodeByCharacterId(context.Source.Id)
               );
            Field<ListGraphType<StarshipQLType>>("Starships", "character Starships",
              resolve: context => starshipRepository.GetStarshipsByCharacterId(context.Source.Id)
              );                       
            Field(x => x.HomePlanet, nullable: false).Description("Character HomePlanet.");
            Field(x => x.Purpose, nullable: true).Description("Character Purpose.");
            Field(x => x.FactionID, nullable: true).Description("Character FactionID.");
            Field<FactionQLType>("Faction", "character Faction",
             resolve: context => factionRepository.GetFaction(context.Source.FactionID)
             );           
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
            Field(x => x.Id).Description("Character type id.");
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
}
