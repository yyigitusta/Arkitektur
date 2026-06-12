using Arkitektur.Entity.Entities;
using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.UserDtos;
using Mapster;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.UserServices
{
    public class UserService(UserManager<AppUser> userManager) : IUserService
    {
        public async Task<BaseResult<object>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = createUserDto.Adapt<AppUser>();
            var result = await userManager.CreateAsync(user, createUserDto.Password);
            if (!result.Succeeded)
            {
                return BaseResult<object>.Fail(result.Errors);
            }
            return BaseResult<object>.Success(user);
        }
    }
}
