using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;

namespace SignalRApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly IContactService contactService;
        private readonly IMapper _mapper;

        public ContactController(IMapper mapper, IContactService contactService)
        {
            _mapper = mapper;
            this.contactService = contactService;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var value = _mapper.Map<List<ResultContactDto>>(contactService.TGetListAll());
            return Ok(value);
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = contactService.TGetById(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            contactService.TAdd(new SignalR.EntityLayer.Entities.Contact()
            {
               FooterDescription = createContactDto.FooterDescription,
               Location = createContactDto.Location,
               Mail = createContactDto.Mail,
               Phone = createContactDto.Phone,  
            });

            return Ok("İletişim Bilgisi Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = contactService.TGetById(id);
            contactService.TDelete(value);
            return Ok("Başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            contactService.TUpdate(new SignalR.EntityLayer.Entities.Contact()
            {
                FooterDescription = updateContactDto.FooterDescription,
                Location = updateContactDto.Location,
                Mail = updateContactDto.Mail,
                Phone = updateContactDto.Phone,
            });

            return Ok("Başarıyla güncellendi");
        }
    }
}
