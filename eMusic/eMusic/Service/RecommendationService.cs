using AutoMapper;
using eMusic.Database;
using eMusic.Interface;
using eMusic.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Service
{
    public class RecommendationService : IRecommendationService
    {
        private readonly eMusicContext _context;
        private readonly IMapper _mapper;
        public RecommendationService(eMusicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<MTrack>> GetRecommandedTracks(int UserID)
        {
            try
            {
                if(UserID == 0)
                {
                    throw new Exception();
                }
                List<UserTrackReview> userReviews = await _context.UserTrackReviews.Where(x => x.UserID == UserID)
                    .Include(x => x.User)
                    .Include(x => x.Track)
                    .Include(x => x.Track.Grene)
                    .ToListAsync();

                List<UserTrackReview> bestUserReviews = userReviews
                    .Where(x => x.Rating >= 3)
                    .ToList();
                
                if (bestUserReviews.Count > 0)
                {
                    List<Genre> genres = new List<Genre>();
                                       
                    foreach(var genre in bestUserReviews)
                    {
                        var trackGenre = await _context.Tracks.Where(m => m.GenreID == genre.Track.GenreID)
                           .Select(g => g.Grene)
                           .ToListAsync();                       

                        foreach(var x in trackGenre)
                        {
                            bool add = true;
                            for (int i = 0; i < genres.Count; i++) 
                            {
                                if(x.Name == genres[i].Name)
                                {
                                    add = false;
                                }
                            }
                            if (add)
                            {
                                genres.Add(x);
                            }
                        }
                    }
                    List<Track> final = new List<Track>();
                    foreach(var item in genres)
                    {
                        var genreTracks = await _context.Tracks
                            .Where(g => g.GenreID == item.GenreID)
                            .Include(i => i.Artist)
                            .ToListAsync();

                        foreach(var track in genreTracks)
                        {
                            bool add = true;
                            for (int i = 0; i < final.Count; i++) 
                            {
                                if(track.Name == final[i].Name)
                                {
                                    add = false;
                                }
                            }
                            foreach(var rate in userReviews)
                            {
                                if(track.Name == rate.Track.Name)
                                {
                                    add = false;
                                }
                            }
                            if (add)
                            {
                                final.Add(track);
                            }
                        }
                    }
                    final = final.OrderBy(x => Guid.NewGuid()).Take(6).ToList();

                    return _mapper.Map<List<MTrack>>(final);
                }
                throw new Exception();
            }
            catch
            {
                return _mapper.Map<List<MTrack>>(null);
            }
        }
    }
}
