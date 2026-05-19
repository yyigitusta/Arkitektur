using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Entity.Entities
{
    public class About : Common.BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int StartYear { get; set; }
        public string ImageUrl { get; set; }
    }
}
