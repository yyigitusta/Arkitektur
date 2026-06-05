using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.AboutDtos;
using Artitektur.Business.DTOs.BannerDtos;
using FluentValidation;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.BannerServices
{
    public class BannerService(IGenericRepository<Banner> repository,IUnitOfWork unitOfWork) : IBannerService
    {
        public async Task<BaseResult<object>> CrateAsync(CreateBannerDto bannerDto)
        {
            var mappedResult = bannerDto.Adapt<Banner>();
            await repository.CreateAsync(mappedResult);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(mappedResult);
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = repository.GetByIdAsync(id).Result;
            repository.Delete(response);
            var result=await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(response)
            : BaseResult<object>.Fail("Silme işlemi sırasında bir hata oluştu."); 
        }

        public Task<BaseResult<List<ResultBannerDto>>> GetAllAsync()
        {
            var response = repository.GetAllAsync().Result;
            var mappedResult = response.Adapt<List<ResultBannerDto>>();
            return BaseResult<List<ResultBannerDto>>.Success(mappedResult);
        }

        public async Task<BaseResult<ResultBannerDto>> GetByIdAsync(int id)
        {
            var response = await repository.GetByIdAsync(id);
            var mappedResult = response.Adapt<ResultBannerDto>();
            return BaseResult<ResultBannerDto>.Success(mappedResult);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateBannerDto BannerDto)
        {
            var banner = BannerDto.Adapt<Banner>();
            repository.Update(banner);
            var result = await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(banner)
             : BaseResult<object>.Fail("Güncelleme işlemi sırasında bir hata oluştu.");
        }
    }
}
