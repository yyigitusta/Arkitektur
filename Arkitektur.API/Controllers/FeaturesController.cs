using Artitektur.Business.DTOs.FeatureDtos;
using Artitektur.Business.Services.FeatureServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController(IFeatureServices featureServices) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ResultFeatureDto>>> GetAll()
        {
            var result = await featureServices.GetAllAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultFeatureDto>> GetById(int id)
        {
            var result = await featureServices.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureDto featureDto)
        {
            var result = await featureServices.CrateAsync(featureDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFeatureDto featureDto)
        {
            var result = await featureServices.UpdateAsync(featureDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await featureServices.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}