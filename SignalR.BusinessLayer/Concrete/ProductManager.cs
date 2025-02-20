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
    public class ProductManager : IProductService
    {

        private readonly IProductDal productDal;

        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        public void TAdd(Product entity)
        {
            productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
           productDal.Delete(entity);
        }

        public Product TGetById(int id)
        {
            return productDal.GetById(id);  
        }

        public List<Product> TGetListAll()
        {
            return productDal.GetListAll();
        }

        public List<Product> TGetProductsWithCategories()
        {
            return productDal.GetProductsWithCategories();
        }

        public void TUpdate(Product entity)
        {
          productDal.Update(entity);
        }
    }
}
