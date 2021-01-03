using AutoMapper;
using eMusic.Database;
using eMusic.Model;
using eMusic.Model.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Service
{
    public class BuyAlbumService : CRUDService<MBuyAlbum, BuyAlbumSearchRequest, BuyAlbum, BuyAlbumRequest, BuyAlbumRequest>
    {
        private readonly eMusicContext _context;
        private readonly IMapper _mapper;
        public BuyAlbumService(eMusicContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<List<MBuyAlbum>> Get(BuyAlbumSearchRequest request)
        {
            var query = _context.BuyAlbums.AsQueryable();

            if (request.From != null)
            {
                query = query.Where(i => i.DateOfBuying >= request.From);
            }
            if (request.To != null)
            {
                query = query.Where(i => i.DateOfBuying <= request.To);
            }

            var list = await query.ToListAsync();

            return _mapper.Map<List<MBuyAlbum>>(query);
        }
    }
}
