using Microsoft.EntityFrameworkCore;
using ModelingAgency.Data.Service.Infrastructure.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service
{
    public class ModelData : IModelData
    {
        private readonly ModelingAgencyContext db;

        public ModelData(ModelingAgencyContext db)
        {
            this.db = db;
        }

        public void Create(Model modelToAdd)
        {
            db.Models.Add(modelToAdd);
        }

        public void Delete(int modelToDeleteId)
        {
            var model = db.Models.FirstOrDefault(m => m.Id == modelToDeleteId);
            if(model != null)
            {
                db.Models.Remove(model);
            }
        }

        public void Edit(Model modelToUpdate)
        {
            db.Entry(modelToUpdate).State = EntityState.Modified;
        }

        public Model Get(int modelId)
        {
            return db.Models.FirstOrDefault(m => m.Id == modelId);
        }

        public ICollection<Model> Get(string searchQuiry)
        {
            return db.Models.Where(m => m.Name.Contains(searchQuiry)).ToList();
        }

        public ICollection<Model> GetAll()
        {
            return db.Models.ToList();
        }
    }
}
