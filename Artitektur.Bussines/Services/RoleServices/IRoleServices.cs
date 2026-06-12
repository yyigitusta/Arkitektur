using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.RoleDtos;

namespace Artitektur.Business.Services.RoleServices
{
    public interface IRoleServices
    {
        Task<BaseResult<object>> CreateRole(CreateRoleDto RoleDto);
        Task<BaseResult<List<ResultRoleDto>>> GetAllRolesAsync();
    }
}
