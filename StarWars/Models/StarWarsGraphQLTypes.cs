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
}
