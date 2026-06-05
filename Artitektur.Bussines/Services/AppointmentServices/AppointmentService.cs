using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.AppointmentDtos;
using FluentValidation;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.AppointmentServices
{
    public class AppointmentService(IUnitOfWork unitOfWork 
        , IGenericRepository<Appointment> AppointmentRepository
        , IValidator<Appointment> validator) : IAppointmentService
    {
        public async Task<BaseResult<object>> CrateAsync(CreateAppointmentDto appointmentDto)
        {
            var appointment = appointmentDto.Adapt<Appointment>();
            var validationResult = await validator.ValidateAsync(appointment);
            if(!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BaseResult<object>.Fail(string.Join(", ", errors));
            }
            await AppointmentRepository.CreateAsync(appointment);
            var result = await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(appointment) : BaseResult<object>.Fail("Randevu oluşturulurken bir hata oluştu.");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var appointment = AppointmentRepository.GetByIdAsync(id).Result;
            if(appointment is null) return BaseResult<object>.Fail("Randevu bulunamadı.");
            AppointmentRepository.Delete(appointment);
            var result = await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success("") : BaseResult<object>.Fail("Randevu silinirken bir hata oluştu.");
        }

        public async Task<BaseResult<List<ResultAppointmentDto>>> GetAllAsync()
        {
            var appointments = AppointmentRepository.GetAllAsync();
            var mappedAppointments = appointments.Adapt<List<ResultAppointmentDto>>();
            return BaseResult<List<ResultAppointmentDto>>.Success(mappedAppointments);
        }

        public async Task<BaseResult<ResultAppointmentDto>> GetByIdAsync(int id)
        {
            var appointment = AppointmentRepository.GetByIdAsync(id).Result;
            var mappedAppointment = appointment.Adapt<ResultAppointmentDto>();
            return BaseResult<ResultAppointmentDto>.Success(mappedAppointment);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateAppointmentDto appointmentDto)
        {
            var  appointment = appointmentDto.Adapt<Appointment>();
            var validationResult = await validator.ValidateAsync(appointment);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BaseResult<object>.Fail(string.Join(", ", errors));
            }
            AppointmentRepository.Update(appointment);
            var result = await unitOfWork.SaveChangesAsync();
            return  result ? BaseResult<object>.Success(appointment) : BaseResult<object>.Fail("appointment güncellenirken hata oldu");
        }
    }
}
