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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            this.testimonialDal = testimonialDal;
        }

        public void TAdd(Testimonial entity)
        {
           testimonialDal.Add(entity);
        }

        public void TDelete(Testimonial entity)
        {
            testimonialDal.Delete(entity);  
        }

        public Testimonial TGetById(int id)
        {
           return testimonialDal.GetById(id); 
        }

        public List<Testimonial> TGetListAll()
        {
           return testimonialDal.GetListAll();
        }

        public void TUpdate(Testimonial entity)
        {
            testimonialDal.Update(entity);
        }
    }
}
