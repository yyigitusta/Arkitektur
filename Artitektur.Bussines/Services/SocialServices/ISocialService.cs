using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.SocialDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.SocialServices
{
    public interface ISocialService
    {
        Task<BaseResult<ResultSocialDto>> GetByIdAsync(int id);
        Task<BaseResult<List<ResultSocialDto>>> GetAllAsync();
        Task<BaseResult<object>> CrateAsync(CreateSocialDto socialDto);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> UpdateAsync(UpdateSocialDto socialDto);
    }
}
