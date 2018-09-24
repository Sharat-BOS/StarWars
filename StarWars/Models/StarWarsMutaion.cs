using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;

namespace StarWars.Models
{
    public class StarWarsMutation : ObjectGraphType
    {
        public StarWarsMutation(ICharacterRepository characterRepository, IFactionRepository factionRepository, IEpisodeRepository episodeRepository, ICharacterGroupRepository characterGroupRepository, ICharacterTypeRepository characterTypeRepository, IStarshipRepository starshipRepository)
        {
            Name = "Create Faction Mutation";

            Field<FactionQLType>(
                "createFaction",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<FactionInputType>> { Name = "faction" }
                ),
                resolve: context =>
                {
                    var faction = context.GetArgument<Faction>("faction");
                    return factionRepository.AddFaction(faction).Result;
                });

            Field<FactionQLType>(
               "updateFaction",
               arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "factionId" },
                   new QueryArgument<NonNullGraphType<FactionInputType>> { Name = "faction" }
               ),
               resolve: context =>
               {
                   var faction = context.GetArgument<Faction>("faction");
                   var factionId= context.GetArgument<int>("factionId");
                   return factionRepository.UpdateFaction(factionId,faction).Result;
               });

            Field<FactionQLType>(
              "associateCharacterToFaction",
              arguments: new QueryArguments(
                  new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "characterId" },
                  new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "factionId" }
              ),
              resolve: context =>
              {
                  var factionId = context.GetArgument<int>("factionId");
                  var characterId = context.GetArgument<int>("characterId");
                  return factionRepository.Associate_Character_To_Faction(factionId, characterId).Result;
              });
            Field<FactionQLType>(
              "removeCharacterFromFaction",
              arguments: new QueryArguments(
                  new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "characterId" },
                  new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "factionId" }
              ),
              resolve: context =>
              {
                  var factionId = context.GetArgument<int>("factionId");
                  var characterId = context.GetArgument<int>("characterId");
                  return factionRepository.Remove_Character_From_Faction(factionId, characterId).Result;
              });

            Name = "Delete Faction Mutation";

            Field<FactionQLType>(
                "deleteFaction",
                arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "factionId" }
                ),
                resolve: context =>
                {
                    var factionId = context.GetArgument<int>("factionId");
                    return factionRepository.DeleteFaction(factionId).Result;
                });


        }
    }
}
