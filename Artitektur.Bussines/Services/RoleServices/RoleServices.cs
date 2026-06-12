using Arkitektur.DataAccess.Repositories;
using Arkitektur.Entity.Entities;
using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.RoleDtos;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.RoleServices
{
    public class RoleServices(RoleManager<AppRole> roleManager ) : IRoleServices
    {
        public async Task<BaseResult<object>> CreateRole(CreateRoleDto RoleDto)
        {
            var role = RoleDto.Adapt<AppRole>();
            var result = await roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                return BaseResult<object>.Fail("Role oluşturulurken bir hata oluştu.");
            }
            return BaseResult<object>.Success("Role Oluşturuldu");
        }

        public async Task<BaseResult<List<ResultRoleDto>>> GetAllRolesAsync()
        {
            var roles = await roleManager.Roles.ToListAsync();
            var MappedRoles = roles.Adapt<List<ResultRoleDto>>();
           return BaseResult<List<ResultRoleDto>>.Success(MappedRoles);
        }
    }
}
