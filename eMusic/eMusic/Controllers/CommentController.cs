using eMusic.Interface;
using eMusic.Model;
using eMusic.Model.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;
        public CommentController(ICommentService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<List<MComment>> Get([FromQuery] CommentSearchRequest search)
        {
            return await _service.Get(search);
        }
        [HttpGet("{ID}")]
        public async Task<MComment> GetById(int ID)
        {
            return await _service.GetById(ID);
        }
        [HttpPost]
        public async Task<MComment> Insert(CommentUpsertRequest request)
        {
            return await _service.Insert(request);
        }
        [HttpPut("{ID}")]
        public async Task<MComment> Update(int ID, CommentUpsertRequest request)
        {
            return await _service.Update(ID, request);
        }
        [HttpDelete("{ID}")]
        public async Task<bool> Delete(int ID)
        {
            return await _service.Delete(ID);
        }
    }
}
