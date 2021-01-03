using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eMusic.Model.Request
{
    public class ArtistUpsertRequest
    {
        [Required]
        public string Name { get; set; }
        public string Founded { get; set; }
        public string Origin { get; set; }
        public byte[] Image { get; set; }
    }
}
