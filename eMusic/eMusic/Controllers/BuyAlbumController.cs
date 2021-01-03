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
    public class BuyAlbumController : CRUDController<MBuyAlbum, BuyAlbumSearchRequest, BuyAlbumRequest, BuyAlbumRequest>
    {
        public BuyAlbumController(ICRUDService<MBuyAlbum, BuyAlbumSearchRequest, BuyAlbumRequest, BuyAlbumRequest> service) : base(service)
        {
        }
    }
}
