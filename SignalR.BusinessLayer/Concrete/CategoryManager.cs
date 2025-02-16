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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public void TAdd(Category entity)
        {
           categoryDal.Add(entity);
        }

        public void TDelete(Category entity)
        {
            categoryDal.Delete(entity); 
        }

        public Category TGetById(int id)
        {
            return categoryDal.GetById(id);    
        }

        public List<Category> TGetListAll()
        {
           return categoryDal.GetListAll();
        }

        public void TUpdate(Category entity)
        {
            categoryDal.Update(entity); 
        }
    }
}
