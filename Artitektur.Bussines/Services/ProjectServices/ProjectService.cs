using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.ProjectDtos;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.ProjectServices
{
    public class ProjectService(IGenericRepository<Project> repository , IUnitOfWork unitOfWork) : IProjectService
    {
        public async Task<BaseResult<object>> CrateAsync(CreateProjectDto ProjectDto)
        {
            var projectDto= ProjectDto.Adapt<Project>();
            await repository.CreateAsync(projectDto);
            var result= await unitOfWork.SaveChangesAsync();
            return result  ? BaseResult<object>.Success("Project created successfully") : BaseResult<object>.Fail("Failed to create project");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var projectDto = await repository.GetByIdAsync(id);
            repository.Delete(projectDto);
            var result=await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success("Project deleted successfully") : BaseResult<object>.Fail("Failed to delete project");
        }

        public async Task<BaseResult<List<ResultProjectDto>>> GetAllAsync()
        {
            var projects=await repository.GetAllAsync();
            var mappedprojectsDto=projects.Adapt<List<ResultProjectDto>>();
            return BaseResult<List<ResultProjectDto>>.Success(mappedprojectsDto);

        }

        public async Task<BaseResult<ResultProjectDto>> GetByIdAsync(int id)
        {
           var project= await repository.GetByIdAsync(id);
            var mappedprojectDto=project.Adapt<ResultProjectDto>();
            return BaseResult<ResultProjectDto>.Success(mappedprojectDto);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateProjectDto ProjectDto)
        {
           var project=ProjectDto.Adapt<Project>();
            repository.Update(project);
            var result= await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success("Project updated successfully") : BaseResult<object>.Fail("Failed to update project");
        }
    }
}
