using AutoMapper;
using eMusic.Database;
using eMusic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Service
{
    public class CRUDService<TModel, TSearch, TDatabase, TInsert, TUpdate> : BaseService<TModel,TSearch,TDatabase>, 
        ICRUDService<TModel, TSearch, TInsert, TUpdate> where TDatabase : class
    {
        private readonly eMusicContext _context;
        private readonly IMapper _mapper;
        public CRUDService(eMusicContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }               

        public virtual async Task<TModel> Insert(TInsert request)
        {
            var entity = _mapper.Map<TDatabase>(request);
            _context.Set<TDatabase>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<TModel>(entity);
        }

        public virtual async Task<TModel> Update(int ID, TUpdate request)
        {
            var entity = _context.Set<TDatabase>().Find(ID);
            _context.Set<TDatabase>().Attach(entity);
            _context.Set<TDatabase>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<TModel>(entity);
        }

        public virtual async Task<bool> Delete(int ID)
        {
            var entity = _context.Set<TDatabase>().Find(ID);
            try
            {
                _context.Set<TDatabase>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
