﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eMusic.Model.Request
{
    public class TrackSearchRequest
    {
        public int? GenreID { get; set; }
        public string Name { get; set; }
    }
}
