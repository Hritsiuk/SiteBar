using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sitedyplom.Models
{
    public class Order
    {
        public Guid id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string country { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string comment { get; set; }
        public string json { get; set; }
        public float total { get; set; }
    }
}
