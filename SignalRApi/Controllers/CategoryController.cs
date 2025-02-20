using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;

namespace SignalRApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            this.categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var value = _mapper.Map<List<ResultCategoryDto>>(categoryService.TGetListAll());
            return Ok(value);
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = categoryService.TGetById(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            categoryService.TAdd(new SignalR.EntityLayer.Entities.Category()
            {
                CategoryName = createCategoryDto.CategoryName,
                Status = createCategoryDto.Status
            });

            return Ok("Kategori Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
           var value =  categoryService.TGetById(id);
            categoryService.TDelete(value);
            return Ok("Kategori silindi");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            categoryService.TUpdate(new SignalR.EntityLayer.Entities.Category()
            {
                CategoryName = updateCategoryDto.CategoryName,
                CategoryID = updateCategoryDto.CategoryID,
                Status = updateCategoryDto.Status
            });

            return Ok("Başarıyla güncellendi");
        }
    }
}
