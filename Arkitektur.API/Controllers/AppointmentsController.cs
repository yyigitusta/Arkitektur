using Artitektur.Business.DTOs.AppointmentDtos;
using Artitektur.Business.Services.AppointmentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController(IAppointmentService appointmentService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentDto appointmentDto)
        {
            var response = await appointmentService.CrateAsync(appointmentDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpGet]
        public async Task<ActionResult<List<ResultAppointmentDto>>> GetAll()
        {
            var response = await appointmentService.GetAllAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultAppointmentDto>> GetById(int id)
        {
            var response = await appointmentService.GetByIdAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAppointmentDto appointmentDto)
        {
            var response = await appointmentService.UpdateAsync(appointmentDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await appointmentService.DeleteAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
