using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class FactionInputType : InputObjectGraphType
    {
        public FactionInputType()
        {
            Name = "FactionInput";
            Field<NonNullGraphType<StringGraphType>>("FactionName");
            Field<ListGraphType<CharacterQLType>>("Characters", "Faction Characters");
            Field<NonNullGraphType<StringGraphType>>("ImageUrl");
        }
    }

    public class EpisodeInputType : InputObjectGraphType
    {
        public EpisodeInputType()
        {
            Name = "EpisodeInput";
            Field<NonNullGraphType<StringGraphType>>("EpisodeName");
            Field<ListGraphType<EpisodeCharacterInputType>>("Cast", "Episode Cast");
            Field<NonNullGraphType<StringGraphType>>("Summary");
            Field<NonNullGraphType<StringGraphType>>("ImageUrl");
        }
    }

    public class EpisodeCharacterInputType : InputObjectGraphType
    {
        public EpisodeCharacterInputType()
        {
            Name = "EpisodeCharacterInputType";           
            Field<IntGraphType>("EpisodeId");
            Field<IntGraphType>("CharacterId");           
        }
    }
    public class StarshipCharacterInputType : InputObjectGraphType
    {
        public StarshipCharacterInputType()
        {
            Name = "StarshipCharacterInputType";
            Field<IntGraphType>("StarshipId");
            Field<IntGraphType>("CharacterId");
        }
    }

    public class CharacterInputType : InputObjectGraphType
    {
        public CharacterInputType()
        {
            Name = "CharacterInput";
            Field<NonNullGraphType<StringGraphType>>("CharacterName");
            Field<IntGraphType>("CharacterTypeID");
            Field<IntGraphType>("CharacterGroupID");
            Field<NonNullGraphType<StringGraphType>>("CharacterGroupID");
            Field<ListGraphType<EpisodeCharacterInputType>>("AppersIn_Episodes", "Appers In Episodes");
            Field<ListGraphType<StarshipCharacterInputType>>("Starships", "Character Starships");
            Field<StringGraphType>("Purpose", "Character Purpose");
            Field<IntGraphType>("FactionID");
            Field<StringGraphType>("ImageUrl", "Character image url");
        }
    }

    public class CharacterTypeInputType : InputObjectGraphType
    {
        public CharacterTypeInputType()
        {
            Name = "CharacterTypeInput";
            Field<StringGraphType>("CharacterTypeName", "Character Type Name");            
        }
    }

    public class CharacterGroupInputType : InputObjectGraphType
    {
        public CharacterGroupInputType()
        {
            Name = "CharacterGroupInputType";
            Field<StringGraphType>("GroupName", "Character GroupName");
        }
    }

    public class StarshipInputType : InputObjectGraphType
    {
        public StarshipInputType()
        {
            Name = "StarshipInputType";
            Field<NonNullGraphType<StringGraphType>>("StarshipName");
            Field<StringGraphType>("ImageUrl", "Starship image url");
            Field<ListGraphType<StarshipCharacterInputType>>("Characters", "Appers In Episodes");
            Field<ListGraphType<EpisodeInputType>>("AppersIn_Episodes", "Appers In Episodes");
        }
    }
}
