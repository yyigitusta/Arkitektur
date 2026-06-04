using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.AboutDtos;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.AboutServices
{
    public class AboutService(IGenericRepository<About> aboutRepo , IUnitOfWork unitOfWork) : IAboutService
    {
        public async Task<BaseResult<object>> CrateAsync(CreateAboutDto AboutDto)
        {
            var about = AboutDto.Adapt<About>();
            await aboutRepo.CreateAsync(about);
            var result= await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(about) : BaseResult<object>.Fail("Failed to create about");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var about = await aboutRepo.GetByIdAsync(id);
            if(about is null)
            {
                return BaseResult<object>.Fail("About not found");
            }
            aboutRepo.Delete(about);
            var result = await unitOfWork.SaveChangesAsync();
            return result
                ? BaseResult<object>.Success("Delete process is success")
                : BaseResult<object>.Fail("Failed to detele about");
        }

        public async Task<BaseResult<List<ResultAboutDto>>> GetAllAsync()
        {
            var abouts = await aboutRepo.GetAllAsync();
            var mappedAbouts = abouts.Adapt<List<ResultAboutDto>>();
            return BaseResult<List<ResultAboutDto>>.Success(mappedAbouts);
        }

        public async Task<BaseResult<ResultAboutDto>> GetByIdAsync(int id)
        {
            var about= await GetByIdAsync(id);
            if(about is null)
            {
                return BaseResult<ResultAboutDto>.Fail("About not found");
            }
            var mappedAbout = about.Adapt<ResultAboutDto>();
            return BaseResult<ResultAboutDto>.Success(mappedAbout);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateAboutDto AboutDto)
        {
            var about = AboutDto.Adapt<About>();
            aboutRepo.Update(about);
            var result= await unitOfWork.SaveChangesAsync();
            return result
                ? BaseResult<object>.Success(about)
                : BaseResult<object>.Fail("Failed to update about");
        }
    }
}
