using Arkitektur.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.DTOs.AppointmentDtos
{
    public class CreateAppointmentDto
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ServiceName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Message { get; set; }
        public AppointmentStatus Status = 0;
    }
}
