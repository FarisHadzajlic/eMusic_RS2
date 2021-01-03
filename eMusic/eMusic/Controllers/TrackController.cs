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
    public class TrackController : CRUDController<MTrack, TrackSearchRequest, TrackUpsertRequest, TrackUpsertRequest>
    {
        public TrackController(ICRUDService<MTrack, TrackSearchRequest, TrackUpsertRequest, TrackUpsertRequest> service) : base(service)
        {
        }
    }
}
