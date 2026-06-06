using Arkitektur.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.DTOs.CategoryDtos
{
    public class CreateCategoryDto : BaseDtos.BaseDto
    {
        public string CategoryName { get; set; }
        public IList<Project> Projects { get; set; }
    }
}
