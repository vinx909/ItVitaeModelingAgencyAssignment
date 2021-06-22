using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service.Infrastructure.Sql
{
    public class SqlModelData : IModelData
    {
        private readonly ModelingAgencyContext dbContext;

        public SqlModelData(ModelingAgencyContext modelingAgencyContext)
        {
            dbContext = modelingAgencyContext;
        }

        public void Create(Model modelToAdd)
        {
            dbContext.Add(modelToAdd);
            dbContext.SaveChanges();
        }

        public void Delete(int modelToDeleteId)
        {
            dbContext.Remove(Get(modelToDeleteId));
            dbContext.SaveChanges();
        }

        public void Edit(Model modelToUpdate)
        {
            dbContext.Update(modelToUpdate);
            dbContext.SaveChanges();
        }

        public Model Get(int modelId)
        {
            return dbContext.Find<Model>(modelId);
        }

        public IEnumerable<Model> GetAll()
        {
            return dbContext.Models;
        }

        public IEnumerable<Model> GetFromSeachQuiry(Func<Model, bool> searchQuiry)
        {
            return dbContext.Models.Where(searchQuiry);
        }
    }
}
