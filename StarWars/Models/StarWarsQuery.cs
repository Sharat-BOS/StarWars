using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class StarWarsQuery : ObjectGraphType
    {
        public StarWarsQuery(ICharacterRepository characterRepository, IFactionRepository factionRepository, IEpisodeRepository episodeRepository, ICharacterGroupRepository characterGroupRepository, ICharacterTypeRepository characterTypeRepository, IStarshipRepository starshipRepository)
        {
            #region Faction
            Field<ListGraphType<FactionQLType>>(
              "factions",
              //arguments: new QueryArguments(
              //    new QueryArgument<IntGraphType> { Name = "id", Description = "faction id" }
              //),
              resolve: context => factionRepository.GetFaction().Result
             );

            Field<FactionQLType>(
                "faction",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "faction id" }
                ),
                resolve: context => factionRepository.GetFaction(context.GetArgument<int>("id")).Result
            );
            #endregion

            #region Episode
            Field<EpisodeQLType>(
                    "episode",
                    arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "episode id" }
                    ),
                    resolve: context => episodeRepository.GetEpisode(context.GetArgument<int>("id")).Result
                );
            Field<ListGraphType<EpisodeQLType>>(
                    "episodes",
                    //arguments: new QueryArguments(
                    //    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "episode id" }
                    //),
                    resolve: context => episodeRepository.GetEpisode().Result
                );
            #endregion

            #region Character
            Field<ListGraphType<CharacterQLType>>(
                   "characters",
                   //arguments: new QueryArguments(
                   //    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "character id" }
                   //),
                   resolve:
                   context => characterRepository.GetCharacter().Result
               );

            Field<CharacterQLType>(
                    "character",
                    arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "character id" }
                    ),
                    resolve:
                    context => characterRepository.GetCharacter(context.GetArgument<int>("id")).Result
                );
            #endregion

            #region Starship
            Field<StarshipQLType>(
                   "starships",
                   //arguments: new QueryArguments(
                   //    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "starship id" }
                   //),
                   resolve: context => starshipRepository.GetStarship().Result
               );

            Field<StarshipQLType>(
                   "starship",
                   arguments: new QueryArguments(
                       new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "starship id" }
                   ),
                   resolve: context => starshipRepository.GetStarship(context.GetArgument<int>("id")).Result
               );
            #endregion

        }
    }
}
