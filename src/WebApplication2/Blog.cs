﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Blog
    {
     
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
