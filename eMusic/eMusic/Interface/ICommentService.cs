using eMusic.Model;
using eMusic.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Interface
{
    public interface ICommentService
    {
        Task<List<MComment>> Get(CommentSearchRequest search);
        Task<MComment> GetById(int ID);
        Task<MComment> Insert(CommentUpsertRequest request);
        Task<MComment> Update(int ID, CommentUpsertRequest request);
        Task<bool> Delete(int ID);
    }
}
