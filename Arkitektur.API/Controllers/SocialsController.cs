using Artitektur.Business.DTOs.ChoosseDtos;
using Artitektur.Business.DTOs.SocialDtos;
using Artitektur.Business.Services.ChooseServices;
using Artitektur.Business.Services.SocialServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialsController(SocialService socialService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ResultSocialDto>>> GetAll()
        {
            var result = await socialService.GetAllAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultSocialDto>> GetById(int id)
        {
            var result = await socialService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialDto socialDto)
        {
            var result = await socialService.CrateAsync(socialDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSocialDto socialDto)
        {
            var result = await socialService.UpdateAsync(socialDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await socialService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
