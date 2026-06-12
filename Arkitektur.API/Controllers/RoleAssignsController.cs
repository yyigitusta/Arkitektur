using Artitektur.Business.DTOs.RoleAssignDtos;
using Artitektur.Business.Services.RoleAssignServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleAssignsController(IRoleAssignService roleAssignService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<List<AssignRoleDto>>> GetUserForRoleAssign(int id)
            {
            var result = await roleAssignService.GetUserForRoleAssignAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result); 
            }
            return Ok(result);
            }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> assignRoleDtos)
        {
            var response = await roleAssignService.AssignRoleAsync(assignRoleDtos);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }


}
