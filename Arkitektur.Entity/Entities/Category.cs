using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Entity.Entities
{
    public class Category : Common.BaseEntity
    {
        public string CategoryName { get; set; }
        public IList<Project> Projects { get; set; }
    }
}
