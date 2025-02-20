using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.DtoLayer.TestimonialDto;

namespace SignalRApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestimonialController : Controller
    {
       
        private readonly ITestimonialService testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(IMapper mapper, ITestimonialService testimonialService)
        {
            _mapper = mapper;
            this.testimonialService = testimonialService;
        }
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(testimonialService.TGetListAll());
            return Ok(value);
        }

        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = testimonialService.TGetById(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateTestimonialDto createTestimonialDto)
        {
            testimonialService.TAdd(new SignalR.EntityLayer.Entities.Testimonial()
            {

               Comment = createTestimonialDto.Comment,
               ImageUrl = createTestimonialDto.ImageUrl,
               Name = createTestimonialDto.Name,
               Status = createTestimonialDto.Status,
               Title = createTestimonialDto.Title,

            });

            return Ok(" Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = testimonialService.TGetById(id);
            testimonialService.TDelete(value);
            return Ok("Başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            testimonialService.TUpdate(new SignalR.EntityLayer.Entities.Testimonial()
            {
                TestimonialId = updateTestimonialDto.TestimonialId,
                Comment = updateTestimonialDto.Comment,
                ImageUrl = updateTestimonialDto.ImageUrl,
                Name = updateTestimonialDto.Name,
                Status = updateTestimonialDto.Status,
                Title = updateTestimonialDto.Title,
            });

            return Ok("Başarıyla güncellendi");
        }
    }
}
