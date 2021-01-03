using eMusic.Model;
using eMusic.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Interface
{
    public interface IReviewService 
    {
        Task<List<MTrackReview>> Get(ReviewSearchRequest search);
        Task<MTrackReview> GetById(int ID);
        Task<MTrackReview> Insert(ReviewUpsertRequest request);
        Task<MTrackReview> Update(int ID, ReviewUpsertRequest request);
        Task<bool> Delete(int ID);
    }
}
