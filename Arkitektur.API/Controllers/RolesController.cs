using Artitektur.Business.DTOs.RoleDtos;
using Artitektur.Business.Services.RoleServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(IRoleServices roleServices) : ControllerBase
    {
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleDto roleDto)
        {
            var result = await roleServices.CreateRole(roleDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("GetAllRoles")]
        public async Task<ActionResult<List<ResultRoleDto>>> GetAllRoles()
        {
            var result = await roleServices.GetAllRolesAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
