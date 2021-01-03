using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Database
{
    public class UserRole
    {
        public int UserRoleID { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }
    }
}
