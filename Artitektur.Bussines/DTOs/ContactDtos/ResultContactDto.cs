using Artitektur.Business.BaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.DTOs.ContactDtos
{
    public class ResultContactDto : BaseDto
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string MapUrl { get; set; }
    }
}
