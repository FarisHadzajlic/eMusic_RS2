using AutoMapper;
using eMusic.Database;
using eMusic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Service
{
    public class RoleService : BaseService<MRole, object, Role>
    {
        public RoleService(eMusicContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
