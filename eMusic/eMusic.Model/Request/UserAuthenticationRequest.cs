using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eMusic.Model.Request
{
    public class UserAuthenticationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
