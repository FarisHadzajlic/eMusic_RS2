using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMusic.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eMusic.Controllers
{  
    public class CRUDController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch>
    {
        private readonly ICRUDService<T, TSearch, TInsert, TUpdate> _service;
        public CRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _service = service;
        }
        [HttpPost]
        [Authorize]
        public async Task<T> Insert(TInsert request)
        {
            return await _service.Insert(request);
        }
        [HttpPut("{ID}")]
        [Authorize]
        public async Task<T> Update(int ID, TUpdate request)
        {
            return await _service.Update(ID, request);
        }
        [HttpDelete("{ID}")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> Delete(int ID)
        {
            return await _service.Delete(ID);
        }
    }
}
