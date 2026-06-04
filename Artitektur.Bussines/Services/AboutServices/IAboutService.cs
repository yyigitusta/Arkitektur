using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.AboutDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.AboutServices
{
    public interface IAboutService
    {
    
        Task<BaseResult<ResultAboutDto>> GetByIdAsync(int id);
        Task<BaseResult<List<ResultAboutDto>>> GetAllAsync();
        Task <BaseResult<object>> CrateAsync(CreateAboutDto AboutDto);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> UpdateAsync(UpdateAboutDto AboutDto);
    }
}
