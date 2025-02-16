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
    public class ContactManager : IContactService
    {
        private readonly IContactDal contactDal;

        public ContactManager(IContactDal contactDal)
        {
             this.contactDal = contactDal;
        }

        public void TAdd(Contact entity)
        {
            contactDal.Add(entity);
        }

        public void TDelete(Contact entity)
        {
            contactDal.Delete(entity);
        }

        public Contact TGetById(int id)
        {
           return contactDal.GetById(id);
        }

        public List<Contact> TGetListAll()
        {
            return contactDal.GetListAll();
        }

        public void TUpdate(Contact entity)
        {
            contactDal.Update(entity);
        }
    }
}
