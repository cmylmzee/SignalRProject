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
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            this.socialMediaDal = socialMediaDal;
        }

        public void TAdd(SocialMedia entity)
        {
            socialMediaDal.Add(entity);
        }

        public void TDelete(SocialMedia entity)
        {
           socialMediaDal.Delete(entity);
        }

        public SocialMedia TGetById(int id)
        {
            return socialMediaDal.GetById(id);
        }

        public List<SocialMedia> TGetListAll()
        {
            return socialMediaDal.GetListAll();
        }

        public void TUpdate(SocialMedia entity)
        {
           socialMediaDal.Update(entity);
        }
    }
}
