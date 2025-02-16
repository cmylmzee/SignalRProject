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
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            this.featureDal = featureDal;
        }

        public void TAdd(Feature entity)
        {
           featureDal.Add(entity);
        }

        public void TDelete(Feature entity)
        {
            featureDal.Delete(entity);
        }

        public Feature TGetById(int id)
        {
            return featureDal.GetById(id);
        }

        public List<Feature> TGetListAll()
        {
            return featureDal.GetListAll();
        }

        public void TUpdate(Feature entity)
        {
           featureDal.Update(entity);   
        }
    }
}
