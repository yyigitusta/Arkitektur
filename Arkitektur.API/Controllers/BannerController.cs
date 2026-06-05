using Artitektur.Business.DTOs.AppointmentDtos;
using Artitektur.Business.DTOs.BannerDtos;
using Artitektur.Business.Services.AppointmentServices;
using Artitektur.Business.Services.BannerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController(IBannerService bannerService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ResultBannerDto>>> GetAll()
        {
            var result = await bannerService.GetAllAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultBannerDto>> GetById(int id)
        {
            var result = await bannerService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerDto bannerDto)
        {
            var result = await bannerService.CrateAsync(bannerDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBannerDto bannerDto)
        {
            var result = await bannerService.UpdateAsync(bannerDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await bannerService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    } 
}