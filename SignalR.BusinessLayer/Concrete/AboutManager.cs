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
    public class AboutManager : IAboutService // Business layerdaki concretedeki classlar manager olarak adlandırılıyor.
    {
        private readonly IAboutDal aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            this.aboutDal = aboutDal;
        }
    
        public void TAdd(About entity)
        {
           aboutDal.Add(entity);
        }

        public void TDelete(About entity)
        {
            aboutDal.Delete(entity);
        }

        public About TGetById(int id)
        {
            return aboutDal.GetById(id);
        }

        public List<About> TGetListAll()
        {
           return aboutDal.GetListAll();
        }

        public void TUpdate(About entity)
        {
            aboutDal.Update(entity);
        }
    }
}
