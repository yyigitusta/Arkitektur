using Arkitektur.Entity.Entities;
using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.RoleAssignDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.RoleAssignServices
{
    public class RoleAssignService(UserManager<AppUser> userManager , RoleManager<AppRole> roleManager) : IRoleAssignService
    {
        public async Task<BaseResult<object>> AssignRoleAsync(List<AssignRoleDto> assignRoleDtos)
        {
            var userId = assignRoleDtos.Select(x => x.UserId).FirstOrDefault();
            var user= await userManager.FindByIdAsync(userId.ToString());
            foreach(var assignRole in assignRoleDtos)
            {
                if (assignRole.RoleExist)
                {
                    await userManager.AddToRoleAsync(user, assignRole.RoleName);
                }
                else { await userManager.RemoveFromRoleAsync(user, assignRole.RoleName); }
            }
            return BaseResult<object>.Success("Rol atama işlemi başarılı");
        }

        public async Task<BaseResult<List<AssignRoleDto>>> GetUserForRoleAssignAsync(int id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            if(user is null)
            {
                return BaseResult<List<AssignRoleDto>>.Fail("Kullanıcı bulunamadı");
            }
            var roles = await roleManager.Roles.ToListAsync();
            var userRoles=await userManager.GetRolesAsync(user);
            var roleAssignments=new List<AssignRoleDto>();
            foreach (var role in roles)
            {
                var assignRole = new AssignRoleDto
                {
                    UserId = user.Id,
                    RoleId = role.Id,
                    RoleName = role.Name,
                    RoleExist = userRoles.Contains(role.Name)
                };
                roleAssignments.Add(assignRole);
            }
            return BaseResult<List<AssignRoleDto>>.Success(roleAssignments); 
        }

    }
}
