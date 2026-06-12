using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.RoleAssignDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.RoleAssignServices
{
    public interface IRoleAssignService
    {
        Task<BaseResult<List<AssignRoleDto>>> GetUserForRoleAssignAsync(int id);
        Task<BaseResult<object>> AssignRoleAsync(List<AssignRoleDto> assignRoleDtos);
    }
}
