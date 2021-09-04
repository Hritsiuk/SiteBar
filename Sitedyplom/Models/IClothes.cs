using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sitedyplom.Models
{
    interface IClothes
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public string brand { get; set; }
        public string img { get; set; }
        public Category category { get; set; }
    }
}
