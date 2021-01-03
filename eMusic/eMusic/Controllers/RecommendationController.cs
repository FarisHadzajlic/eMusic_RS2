using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMusic.Interface;
using eMusic.Model;
using Microsoft.AspNetCore.Mvc;

namespace eMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : Controller
    {
        private readonly IRecommendationService _service;
        public RecommendationController(IRecommendationService service)
        {
            _service = service;
        }
        [HttpGet("GetRecommendedTracks")]
        public Task<List<MTrack>> GetRecommandedTracks(int UserID)
        {
            return _service.GetRecommandedTracks(UserID);
        }
    }
}
