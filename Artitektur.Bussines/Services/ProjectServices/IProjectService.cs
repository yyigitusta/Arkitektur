using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.CategoryDtos;
using Artitektur.Business.DTOs.ProjectDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.ProjectServices
{
    public interface IProjectService
    {
        Task<BaseResult<ResultProjectDto>> GetByIdAsync(int id);
        Task<BaseResult<List<ResultProjectDto>>> GetAllByCategoryIdAsync();
        Task<BaseResult<List<ResultProjectDto>>> GetAllAsync();
        Task<BaseResult<object>> CrateAsync(CreateProjectDto ProjectDto);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> UpdateAsync(UpdateProjectDto ProjectDto);
    }
}
