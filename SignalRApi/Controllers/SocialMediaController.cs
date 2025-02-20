using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.SocialMediaDto;

namespace SignalRApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(IMapper mapper, ISocialMediaService socialMediaService)
        {
            _mapper = mapper;
            this.socialMediaService = socialMediaService;
        }
        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var value = _mapper.Map<List<ResultSocialMediaDto>>(socialMediaService.TGetListAll());
            return Ok(value);
        }

        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = socialMediaService.TGetById(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            socialMediaService.TAdd(new SignalR.EntityLayer.Entities.SocialMedia()
            {

               Title = createSocialMediaDto.Title,
               Icon = createSocialMediaDto.Icon,
               Url = createSocialMediaDto.Url,

            });

            return Ok("Ürün Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = socialMediaService.TGetById(id);
            socialMediaService.TDelete(value);
            return Ok("Başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            socialMediaService.TUpdate(new SignalR.EntityLayer.Entities.SocialMedia()
            {
                SocialMediaId = updateSocialMediaDto.SocialMediaId,
                Title = updateSocialMediaDto.Title,
                Icon = updateSocialMediaDto.Icon,
                Url = updateSocialMediaDto.Url,
            });

            return Ok("Başarıyla güncellendi");
        }
    }
}
