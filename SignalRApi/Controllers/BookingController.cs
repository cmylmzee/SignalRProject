using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.Mapping;

namespace SignalRApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult BookingList()
        {
            var value = _mapper.Map<List<ResultBookingDto>>(_bookingService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult BookingCreate(CreateBookingDto createBookingDto)
        {
            _bookingService.TAdd(
                new SignalR.EntityLayer.Entities.Booking()
                {

                    Date = createBookingDto.Date,
                    Mail = createBookingDto.Mail,
                    Name = createBookingDto.Name,
                    PersonCount = createBookingDto.PersonCount,
                    Phone = createBookingDto.Phone,
                }
                 );
            return Ok("Başarılı şekilde rezervasyon eklendi");
        }

        [HttpDelete]
        public IActionResult BookingDelete(int id)
        {
            var value  = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Başarıyla rezervasyon silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                BookingId = updateBookingDto.BookingId,
                Date = updateBookingDto.Date,
                Mail = updateBookingDto.Mail,
                Name = updateBookingDto.Name,
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone
            };

            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon başarıyla güncellendi");


        }
    }
}
