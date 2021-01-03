using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMusic.Interface;
using eMusic.Model;
using eMusic.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace eMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _service;
        public ReviewController(IReviewService service) 
        {
            _service = service;
        }
        [HttpGet]
        public async Task<List<MTrackReview>> Get([FromQuery] ReviewSearchRequest search)
        {
            return await _service.Get(search);
        }
        [HttpGet("{ID}")]
        public async Task<MTrackReview> GetById(int ID)
        {
            return await _service.GetById(ID);
        }
        [HttpPost]
        public async Task<MTrackReview> Insert(ReviewUpsertRequest request)
        {
            return await _service.Insert(request);
        }
        [HttpPut("{ID}")]
        public async Task<MTrackReview> Update(int ID, ReviewUpsertRequest request)
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
