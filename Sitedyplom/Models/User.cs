﻿using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sitedyplom.Models
{
    public class User : IdentityUser
    {
        public float Balance { get; set; }
        
        public string Position { get; set; }

    }
}
