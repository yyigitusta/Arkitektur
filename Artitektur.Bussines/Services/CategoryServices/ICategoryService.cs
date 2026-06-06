using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<BaseResult<ResultCategoryDto>> GetByIdAsync(int id);
        Task<BaseResult<List<ResultCategoryDto>>> GetAllAsync();
        Task<BaseResult<object>> CrateAsync(CreateCategoryDto CategoryDto);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> UpdateAsync(UpdateCategoryDto CategoryDto);
    }
}
