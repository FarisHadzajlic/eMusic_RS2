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
    public class CommentService : ICommentService
    {
        private readonly eMusicContext _context;
        private readonly IMapper _mapper;
        public CommentService(eMusicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<MComment>> Get(CommentSearchRequest search)
        {
            var query = _context.Comments.AsQueryable();

            var list = await query.ToListAsync();
            return _mapper.Map<List<MComment>>(list);
        }
        public async Task<MComment> GetById(int ID)
        {
            var entity = await _context.Comments
                .Include(i => i.User)
                .Where(i => i.CommentID == ID)
                .SingleOrDefaultAsync();

            return _mapper.Map<MComment>(entity);
        }
        public async Task<MComment> Insert(CommentUpsertRequest request)
        {
            var entity = _mapper.Map<Comment>(request);
            _context.Set<Comment>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MComment>(entity);
        }
        public async Task<MComment> Update(int ID, CommentUpsertRequest request)
        {
            var entity = _context.Set<Comment>().Find(ID);
            _context.Set<Comment>().Attach(entity);
            _context.Set<Comment>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<MComment>(entity);
        }
        public async Task<bool> Delete(int ID)
        {
            var comment = await _context.Comments.Where(i => i.CommentID == ID).FirstOrDefaultAsync();
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
