using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sitedyplom.Models
{
    public class Structure
    {
        public Guid id { get; set; }
        public Guid caategory_id { get; set; }
        public Guid category_parent_id { get; set; }
    }
}
