using eMusic.Interface;
using eMusic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Controllers
{
    public class RoleController : BaseController<MRole, object>
    {
        public RoleController(IBaseService<MRole, object> service) : base(service)
        {
        }
    }
}
