using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.UserServices
{
    public interface IUserService
    {
        Task<BaseResult<object>> CreateUserAsync(CreateUserDto createUserDto);
    }
}
