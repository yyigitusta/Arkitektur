using Artitektur.Business.DTOs.UserDtos;
using Artitektur.Business.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateUserDto userDto)
        {
            var result = await userService.CreateUserAsync(userDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
