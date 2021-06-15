using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service
{
    public interface IModelData
    {
        public ICollection<Model> GetAll();
        public Model Get(int modelId);
        public ICollection<Model> Get(string searchQuiry);
        public void Create(Model modelToAdd);
        public void Edit(Model modelToUpdate);
        public void Delete(int modelToDeleteId);
    }
}
