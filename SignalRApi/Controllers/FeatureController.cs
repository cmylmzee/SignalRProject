using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.FeatureDto;

namespace SignalRApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService featureService;
        private readonly IMapper _mapper;

        public FeatureController(IMapper mapper, IFeatureService featureService)
        {
            _mapper = mapper;
            this.featureService = featureService;
        }
        [HttpGet]
        public IActionResult FeatureList()
        {
            var value = _mapper.Map<List<ResultFeatureDto>>(featureService.TGetListAll());
            return Ok(value);
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var value = featureService.TGetById(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            featureService.TAdd(new SignalR.EntityLayer.Entities.Feature()
            {
         
                Description1 = createFeatureDto.Description1,
                Description2 = createFeatureDto.Description2,
                Description3 = createFeatureDto.Description3,
                Title1 = createFeatureDto.Title1,
                Title2 = createFeatureDto.Title2,
                Title3 = createFeatureDto.Title3,
            });

            return Ok("Gelecek Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = featureService.TGetById(id);
            featureService.TDelete(value);
            return Ok("Başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            featureService.TUpdate(new SignalR.EntityLayer.Entities.Feature()
            {
                FeatureId = updateFeatureDto.FeatureId,
                Description1 = updateFeatureDto.Description1,
                Description2 = updateFeatureDto.Description2,
                Description3 = updateFeatureDto.Description3,
                Title1 = updateFeatureDto.Title1,
                Title2 = updateFeatureDto.Title2,
                Title3 = updateFeatureDto.Title3,
            });

            return Ok("Başarıyla güncellendi");
        }
    }
}
