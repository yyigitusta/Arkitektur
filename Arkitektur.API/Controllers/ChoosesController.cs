using Artitektur.Business.DTOs.ChoosseDtos;
using Artitektur.Business.Services.ChooseServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoosesController(IChooseService chooseService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ResultChoosseDto>>> GetAll()
        {
            var result = await chooseService.GetAllAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultChoosseDto>> GetById(int id)
        {
            var result = await chooseService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateChoosseDto chooseDto)
        {
            var result = await chooseService.CrateAsync(chooseDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateChoosseDto chooseDto)
        {
            var result = await chooseService.UpdateAsync(chooseDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await chooseService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
