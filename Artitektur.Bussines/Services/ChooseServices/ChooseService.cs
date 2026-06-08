using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.ChoosseDtos;
using Artitektur.Business.DTOs.ProjectDtos;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.ChooseServices
{
    public class ChooseService(IGenericRepository<Choose> repository, IUnitOfWork unitOfWork) : IChooseService
    {
        public async Task<BaseResult<object>> CrateAsync(CreateChoosseDto choosseDto)
        {
           var mappedChoose=choosseDto.Adapt<Choose>();
            await repository.CreateAsync(mappedChoose);
           var result= await unitOfWork.SaveChangesAsync();
           return BaseResult<object>.Success(result);
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var choose=await repository.GetByIdAsync(id);
            repository.Delete(choose);
            var result= await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(result);
        }

        public async Task<BaseResult<List<ResultChoosseDto>>> GetAllAsync()
        {
            var chooses = await repository.GetAllAsync();
            var mappedChooses = chooses.Adapt<List<ResultChoosseDto>>();
            return BaseResult<List<ResultChoosseDto>>.Success(mappedChooses);
        }

        public async Task<BaseResult<ResultChoosseDto>> GetByIdAsync(int id)
        {
            var choose = await repository.GetByIdAsync(id);
            var mappedChoose = choose.Adapt<ResultChoosseDto>();
            return BaseResult<ResultChoosseDto>.Success(mappedChoose);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateChoosseDto choosseDto)
        {
            var mappedChoose = choosseDto.Adapt<Choose>();
            repository.Update(mappedChoose);    
            var result = await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(result);
        }
    }
}
