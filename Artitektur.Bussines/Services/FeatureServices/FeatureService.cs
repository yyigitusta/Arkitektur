using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.FeatureDtos;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.FeatureServices
{
    public class FeatureService(IGenericRepository<Feature> repository,IUnitOfWork unitOfWork) : IFeatureServices
    {
        public async Task<BaseResult<object>> CrateAsync(CreateFeatureDto featureDto)
        {
            var feature=featureDto.Adapt<Feature>();
            await repository.CreateAsync(feature);
            var result= await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(feature):BaseResult<object>.Fail("feature create process is failed") ;
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var feauture=await repository.GetByIdAsync(id);
            repository.Delete(feauture);
            var result = await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(feauture) : BaseResult<object>.Fail("feature delete process is failed");
        }

        public async Task<BaseResult<List<ResultFeatureDto>>> GetAllAsync()
        {
            var features = await repository.GetAllAsync();
            var mappedfeatures = features.Adapt<List<ResultFeatureDto>>();
            return BaseResult<List<ResultFeatureDto>>.Success(mappedfeatures);
        }

        public async Task<BaseResult<ResultFeatureDto>> GetByIdAsync(int id)
        {
            var feature = await repository.GetByIdAsync(id);
            var mappedFeature = feature.Adapt<ResultFeatureDto>();
            return BaseResult<ResultFeatureDto>.Success(mappedFeature);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateFeatureDto featureDto)
        {
            var mappedFeature=featureDto.Adapt<Feature>();
            repository.Update(mappedFeature);
            var result = await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(mappedFeature) : BaseResult<object>.Fail("feature update process is failed");
        }
    }
}
