using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        IBookingDal booking;

        public BookingManager(IBookingDal booking)
        {
            this.booking = booking;
        }

        public void TAdd(Booking entity)
        {
            booking.Add(entity);
        }

        public void TDelete(Booking entity)
        {
            booking.Delete(entity); 
        }

        public Booking TGetById(int id)
        {
            return booking.GetById(id);    
        }

        public List<Booking> TGetListAll()
        {
           return booking.GetListAll();

        }

        public void TUpdate(Booking entity)
        {
           booking.Update(entity);
        }
    }
}
