using AutoMapper;
using eMusic.Database;
using eMusic.Interface;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Service
{
    public class BaseService<TModel, TSearch, TDatabase> : IBaseService<TModel, TSearch> where TDatabase : class
    {        
        protected eMusicContext _context;
        protected IMapper _mapper;
        public BaseService(eMusicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public virtual async Task<List<TModel>> Get(TSearch search)
        {
            var list = await _context.Set<TDatabase>().ToListAsync();
            return _mapper.Map<List<TModel>>(list);
        }
        public async virtual Task<TModel> GetById(int ID)
        {
            var entity = await _context.Set<TDatabase>().FindAsync(ID);
            return _mapper.Map<TModel>(entity);
        }
    }
}
