﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sitedyplom.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public ICollection<Clothes> clothes { get; set; }
    }
}
