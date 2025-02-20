using AutoMapper;
using SignalR.DtoLayer.BookingDto;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {

            CreateMap<Category, ResultCategoryDto>().ReverseMap(); // Reverse Map burada about resultaboutdto ile eşleştirilebilir hem de tam tersini sağlamak için
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();

        }

    }
}
