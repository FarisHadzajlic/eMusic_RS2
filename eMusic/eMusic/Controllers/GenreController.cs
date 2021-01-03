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
    public class GenreController : CRUDController<MGenre, GenreSearchRequest, GenreUpsertRequest, GenreUpsertRequest>
    {
        public GenreController(ICRUDService<MGenre, GenreSearchRequest, GenreUpsertRequest, GenreUpsertRequest> service) : base(service)
        {
        }
    }
}
