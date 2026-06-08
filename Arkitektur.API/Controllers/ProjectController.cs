using Arkitektur.Entity.Entities;
using Artitektur.Business.DTOs.BannerDtos;
using Artitektur.Business.DTOs.ProjectDtos;
using Artitektur.Business.Services.ProjectServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(IProjectService ProjectService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ResultProjectDto>>> GetAll()
        {
            var result = await ProjectService.GetAllAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("{WithCategories}")]
        public async Task<IActionResult> GetProductsWithCategories()
        {
            var result = await ProjectService.GetAllByCategoryIdAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultProjectDto>> GetById(int id)
        {
            var result = await ProjectService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectDto projectDto)
        {
            var result = await ProjectService.CrateAsync(projectDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProjectDto projectDto)
        {
            var result = await ProjectService.UpdateAsync(projectDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await ProjectService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
