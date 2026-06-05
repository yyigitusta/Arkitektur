using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.AboutDtos;
using Artitektur.Business.DTOs.BannerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.BannerServices
{
    public interface IBannerService
    {
        Task<BaseResult<ResultBannerDto>> GetByIdAsync(int id);
        Task<BaseResult<List<ResultBannerDto>>> GetAllAsync();
        Task<BaseResult<object>> CrateAsync(CreateBannerDto BannerDto);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> UpdateAsync(UpdateBannerDto BannerDto);
    }
}
