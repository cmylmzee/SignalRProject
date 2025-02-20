using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;

namespace SignalRApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            this.productService = productService;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(productService.TGetListAll());
            return Ok(value);
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = productService.TGetById(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            productService.TAdd(new SignalR.EntityLayer.Entities.Product()
            {

               Description = createProductDto.Description,
               ImagUrl = createProductDto.ImagUrl,
               Price = createProductDto.Price,
               ProductName = createProductDto.ProductName,
               ProductStatus    = createProductDto.ProductStatus,

            });

            return Ok("Ürün Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = productService.TGetById(id);
            productService.TDelete(value);
            return Ok("Başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            productService.TUpdate(new SignalR.EntityLayer.Entities.Product()
            {
                ProductId = updateProductDto.ProductId,
                Description = updateProductDto.Description,
                ImagUrl = updateProductDto.ImagUrl,
                Price = updateProductDto.Price,
                ProductName = updateProductDto.ProductName,
                ProductStatus = updateProductDto.ProductStatus,
            });

            return Ok("Başarıyla güncellendi");
        }
    }
}
