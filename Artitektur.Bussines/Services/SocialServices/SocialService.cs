using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.SocialDtos;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.SocialServices
{
    public class SocialService(IGenericRepository<Social> repository , IUnitOfWork unitOfWork) : ISocialService
    {
        public async Task<BaseResult<object>> CrateAsync(CreateSocialDto socialDto)
        {
           var social = socialDto.Adapt<Social>();
            await repository.CreateAsync(social);
            var result=await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(result);
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var social=await repository.GetByIdAsync(id);
            repository.Delete(social);
            var result = await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(result);
        }

        public async Task<BaseResult<List<ResultSocialDto>>> GetAllAsync()
        {
            var socials=await repository.GetAllAsync();
            var mappedSocials=socials.Adapt<List<ResultSocialDto>>();
            return BaseResult<List<ResultSocialDto>>.Success(mappedSocials);
        }

        public async Task<BaseResult<ResultSocialDto>> GetByIdAsync(int id)
        {
            var social = await repository.GetByIdAsync(id);
            var mappedSocial=social.Adapt<ResultSocialDto>();
            return BaseResult<ResultSocialDto>.Success(mappedSocial);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateSocialDto socialDto)
        {
            var social=socialDto.Adapt<Social>();
            repository.Update(social);
            var result = await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(result);
        }
    }
}
