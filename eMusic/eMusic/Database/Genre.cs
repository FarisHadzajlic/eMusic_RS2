using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eMusic.Database
{
    public class Genre
    {       
        [Key]
        public int GenreID { get; set; }
        public string Name { get; set; }
    }
}
