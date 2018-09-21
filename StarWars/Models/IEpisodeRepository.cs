using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public interface IEpisodeRepository
    {
        Task<IList<Episode>> GetEpisode();
        Task<Episode> GetEpisode(int Id);
        Task<Episode> AddEpisode(Episode episode);
        Task<Episode> UpdateEpisode(int episodeId, Episode episode);
        Task<string> DeleteEpisode(int episodeId);
        Task<Episode> Associate_Character_With_Episode(int episodeId, int characterID);
        Task<Episode> Remove_Character_From_Episode(int episodeId, int characterID);
    }
}
