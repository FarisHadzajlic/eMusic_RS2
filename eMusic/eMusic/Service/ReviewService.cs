using AutoMapper;
using eMusic.Database;
using eMusic.Interface;
using eMusic.Model;
using eMusic.Model.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Service
{
    public class ReviewService : IReviewService
    {
        private readonly eMusicContext _context;
        private readonly IMapper _mapper;
        public ReviewService(eMusicContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<MTrackReview>> Get(ReviewSearchRequest search)
        {
            var query = _context.UserTrackReviews.AsQueryable();

            if (search.UserID != 0)
            {
                query = query.Where(i => i.UserID == search.UserID);
            }

            if (search.TrackID != 0)
            {
                query = query.Where(i => i.TrackID == search.TrackID);
            }

            if (search.Rating != 0)
            {
                query = query.Where(i => i.Rating == search.Rating);
            }

            var list = await query.ToListAsync();
            return _mapper.Map<List<MTrackReview>>(list);
        }
        public async Task<MTrackReview> GetById(int ID)
        {
            var entity = await _context.UserTrackReviews
                .Include(i => i.Track)
                .Where(i => i.UserID == ID)
                .SingleOrDefaultAsync();

            return _mapper.Map<MTrackReview>(entity);
        }
        public async Task<MTrackReview> Insert(ReviewUpsertRequest request)
        {
            var entity = _mapper.Map<UserTrackReview>(request);
            _context.Set<UserTrackReview>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MTrackReview>(entity);
        }
        public async Task<MTrackReview> Update(int ID, ReviewUpsertRequest request)
        {
            var entity = _context.Set<UserTrackReview>().Find(ID);
            _context.Set<UserTrackReview>().Attach(entity);
            _context.Set<UserTrackReview>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<MTrackReview>(entity);
        }
        public async Task<bool> Delete(int ID)
        {
            var review = await _context.UserTrackReviews.Where(i => i.UserID == ID).Include(i => i.TrackID).FirstOrDefaultAsync();
            if (review != null)
            {
                _context.UserTrackReviews.Remove(review);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
