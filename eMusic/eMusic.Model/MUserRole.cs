using System;
using System.Collections.Generic;
using System.Text;

namespace eMusic.Model
{
    public class MUserRole
    {
        public int UserRoleID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public MRole Role { get; set; }
    }
}
