using AutoMapper;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class AboutMapping:Profile
    {

        public AboutMapping() {



            CreateMap<About, SignalR.DtoLayer.AboutDto.ResultAboutDto>().ReverseMap(); // Reverse Map burada about resultaboutdto ile eşleştirilebilir hem de tam tersini sağlamak için
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, GetAboutDto>().ReverseMap();

        }

    }
}
