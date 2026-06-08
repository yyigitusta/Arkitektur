using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.ChoosseDtos;
using Artitektur.Business.DTOs.ProjectDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.ChooseServices
{
    public interface IChooseService
    {
        Task<BaseResult<ResultChoosseDto>> GetByIdAsync(int id);
        Task<BaseResult<List<ResultChoosseDto>>> GetAllAsync();
        Task<BaseResult<object>> CrateAsync(CreateChoosseDto choosseDto);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> UpdateAsync(UpdateChoosseDto choosseDto);
    }
}
