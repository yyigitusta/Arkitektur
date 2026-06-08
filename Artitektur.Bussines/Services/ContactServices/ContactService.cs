using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using Artitektur.Business.BaseDtos;
using Artitektur.Business.DTOs.ContactDtos;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artitektur.Business.Services.ContactServices
{
    public class ContactService(IGenericRepository<Contact> repository , IUnitOfWork unitOfWork) : IContactService
    {
        public async Task<BaseResult<object>> CrateAsync(CreateContactDto contactDto)
        {
            var contact = contactDto.Adapt<Contact>();
            await repository.CreateAsync(contact);
            var result = await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(contact);
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var contact = await repository.GetByIdAsync(id);
            repository.Delete(contact);
            var result= await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(contact);
        }

        public async Task<BaseResult<List<ResultContactDto>>> GetAllAsync()
        {
          var contacts=await repository.GetAllAsync();
            var mappedContacts = contacts.Adapt<List<ResultContactDto>>();
            return BaseResult<List<ResultContactDto>>.Success(mappedContacts);
        }

        public async Task<BaseResult<ResultContactDto>> GetByIdAsync(int id)
        {
            var contact=await repository.GetByIdAsync(id);
            var mappedContact=contact.Adapt<ResultContactDto>();
            return BaseResult<ResultContactDto>.Success(mappedContact);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateContactDto contactDto)
        {
            var mappedContact = contactDto.Adapt<Contact>();
            repository.Update(mappedContact);
            var result = await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(mappedContact);
        }
    }
}
