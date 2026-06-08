using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.ChoosseDtos;
using Artitektur.Business.DTOs.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.ContactServices
{
    public interface IContactService
    {
        Task<BaseResult<ResultContactDto>> GetByIdAsync(int id);
        Task<BaseResult<List<ResultContactDto>>> GetAllAsync();
        Task<BaseResult<object>> CrateAsync(CreateContactDto contactDto);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> UpdateAsync(UpdateContactDto contactDto);
    }
}
