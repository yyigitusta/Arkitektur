using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.AboutDtos;
using Artitektur.Business.DTOs.AppointmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.AppointmentServices
{
    public interface IAppointmentService
    {
        Task<BaseResult<ResultAppointmentDto>> GetByIdAsync(int id);
        Task<BaseResult<List<ResultAppointmentDto>>> GetAllAsync();
        Task<BaseResult<object>> CrateAsync(CreateAppointmentDto appointmentDto);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> UpdateAsync(UpdateAppointmentDto appointmentDto);
    }
}
