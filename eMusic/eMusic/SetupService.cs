using eMusic.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic
{
    public class SetupService
    { 
        public static void Init(eMusicContext context)
        {
            context.Database.Migrate();
        }
    }
}
