using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.CategoryDtos;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.CategoryServices
{
    public class CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork) : ICategoryService
    {
        public async Task<BaseResult<object>> CrateAsync(CreateCategoryDto CategoryDto)
        {
            var mappedCategory=CategoryDto.Adapt<Category>();
            await repository.CreateAsync(mappedCategory);
            var result= await  unitOfWork.SaveChangesAsync();
            return result  ? BaseResult<object>.Success(mappedCategory) : BaseResult<object>.Fail("Kayıt işlemi sırasında bir hata oluştu.");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var category = await repository.GetByIdAsync(id);
            repository.Delete(category);
            var result = await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(category) : BaseResult<object>.Fail("Silme işlemi sırasında bir hata oluştu.");
        }

        public async Task<BaseResult<List<ResultCategoryDto>>> GetAllAsync()
        {
            var repo = await repository.GetAllAsync();
            var categories = repo.Adapt<List<ResultCategoryDto>>();
            return BaseResult<List<ResultCategoryDto>>.Success(categories);
        }

        public async Task<BaseResult<ResultCategoryDto>> GetByIdAsync(int id)
        {
            var repo = await repository.GetByIdAsync(id);
            var mappedCategory = repo.Adapt<ResultCategoryDto>();
            return BaseResult<ResultCategoryDto>.Success(mappedCategory);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateCategoryDto CategoryDto)
        {
            var category = CategoryDto.Adapt<Category>();
            repository.Update(category);
            var result = await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(category) : BaseResult<object>.Fail("Güncelleme işlemi sırasında bir hata oluştu.");
        }
    }
}
