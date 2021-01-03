using eMusic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Interface
{
    public interface IRecommendationService
    {
        Task<List<MTrack>> GetRecommandedTracks(int ID);
    }
}
