using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;

namespace SignalRApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController : Controller
    {
        private readonly IDiscountService discountService;
        private readonly IMapper _mapper;

        public DiscountController(IMapper mapper, IDiscountService discountService)
        {
            _mapper = mapper;
            this.discountService = discountService;
        }
        [HttpGet]
        public IActionResult DiscountList()
        {
            var value = _mapper.Map<List<ResultDiscountDto>>(discountService.TGetListAll());
            return Ok(value);
        }

        [HttpGet("GetDiscount")]
        public IActionResult GetContact(int id)
        {
            var value = discountService.TGetById(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            discountService.TAdd(new SignalR.EntityLayer.Entities.Discount()
            {
                
                Amount = createDiscountDto.Amount,
                Description = createDiscountDto.Description,   
                ImageUrl = createDiscountDto.ImageUrl,
                Title = createDiscountDto.Title,
            });

            return Ok("İndirim  Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {
            var value = discountService.TGetById(id);
            discountService.TDelete(value);
            return Ok("Başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateDiscountDto updateDiscountDto)
        {
            discountService.TUpdate(new SignalR.EntityLayer.Entities.Discount()
            {
                DiscountId = updateDiscountDto.DiscountId,
                Amount = updateDiscountDto.Amount,
                Description = updateDiscountDto.Description,
                ImageUrl = updateDiscountDto.ImageUrl,
                Title = updateDiscountDto.Title,
            });

            return Ok("Başarıyla güncellendi");
        }
    }
}
