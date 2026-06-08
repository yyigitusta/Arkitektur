using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.ContactDtos;
using Artitektur.Business.DTOs.FeatureDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.FeatureServices
{
    public interface IFeatureServices
    {
        Task<BaseResult<ResultFeatureDto>> GetByIdAsync(int id);
        Task<BaseResult<List<ResultFeatureDto>>> GetAllAsync();
        Task<BaseResult<object>> CrateAsync(CreateFeatureDto featureDto);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> UpdateAsync(UpdateFeatureDto featureDto);
    }
}
