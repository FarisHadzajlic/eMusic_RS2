using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eMusic.Database
{
    public class Role
    {        
        [Key]
        public int RoleID { get; set; }
        public string Name { get; set; }
    }
}
