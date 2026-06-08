using Artitektur.Business.DTOs.ContactDtos;
using Artitektur.Business.Services.ContactServices;
using Artitektur.Business.Services.ContactServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IContactService contactService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ResultContactDto>>> GetAll()
        {
            var result = await contactService.GetAllAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultContactDto>> GetById(int id)
        {
            var result = await contactService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDto ContactDto)
        {
            var result = await contactService.CrateAsync(ContactDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactDto ContactDto)
        {
            var result = await contactService.UpdateAsync(ContactDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await contactService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
