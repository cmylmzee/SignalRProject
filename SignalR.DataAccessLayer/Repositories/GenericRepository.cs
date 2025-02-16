using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class // Cloud işlemlerini tekrar etmemizi sağlayacak
    {
        private readonly SignalRContext context;
        public GenericRepository(SignalRContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
            context.SaveChanges();  
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);

        }

        public List<T> GetListAll()
        {
            return context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            context.Update(entity); 
            context.SaveChanges();
        }
    }
}
