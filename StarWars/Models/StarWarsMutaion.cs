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
             # region Faction

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

            Field<StringGraphType>(
                "deleteFaction",
                arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "factionId" }
                ),
                resolve: context =>
                {
                    var factionId = context.GetArgument<int>("factionId");
                    return factionRepository.DeleteFaction(factionId).Result;
                });

            #endregion
            #region Episode
            Name = "Create Episode Mutation";

            Field<EpisodeQLType>(
                "createEpisode",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<EpisodeInputType>> { Name = "episode" }
                ),
                resolve: context =>
                {
                    var episode = context.GetArgument<Episode>("episode");
                    return episodeRepository.AddEpisode(episode).Result;
                });

            Field<EpisodeQLType>(
               "updateEpisode",
               arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "episodeId" },
                   new QueryArgument<NonNullGraphType<EpisodeInputType>> { Name = "episode" }
               ),
               resolve: context =>
               {
                   var episode = context.GetArgument<Episode>("episode");
                   var episodeId= context.GetArgument<int>("episodeId");
                   return episodeRepository.UpdateEpisode(episodeId,episode).Result;
               });

            Field<EpisodeQLType>(
              "associateCharacterToEpisode",
              arguments: new QueryArguments(
                  new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "characterId" },
                  new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "episodeId" }
              ),
              resolve: context =>
              {
                  var episodeId = context.GetArgument<int>("episodeId");
                  var characterId = context.GetArgument<int>("characterId");
                  return episodeRepository.Associate_Character_With_Episode(episodeId, characterId).Result;
              });
            Field<EpisodeQLType>(
              "removeCharacterFromEpisode",
              arguments: new QueryArguments(
                  new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "characterId" },
                  new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "episodeId" }
              ),
              resolve: context =>
              {
                  var episodeId = context.GetArgument<int>("episodeId");
                  var characterId = context.GetArgument<int>("characterId");
                  return episodeRepository.Remove_Character_From_Episode(episodeId, characterId).Result;
              });

            Name = "Delete Episode Mutation";

            Field<StringGraphType>(
                "deleteEpisode",
                arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "episodeId" }
                ),
                resolve: context =>
                {
                    var episodeId = context.GetArgument<int>("episodeId");
                    return episodeRepository.DeleteEpisode(episodeId).Result;
                });

            #endregion
        }
    }
}
