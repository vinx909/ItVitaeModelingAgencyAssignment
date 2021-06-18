using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service
{
    public interface IModelData
    {
        public IEnumerable<Model> GetAll();
        public IEnumerable<Model> GetFromSeachQuiry(Func<Model, bool> searchQuiry);
        public Model Get(int modelId);
        public void Create(Model modelToAdd);
        public void Edit(Model modelToUpdate);
        public void Delete(int modelToDeleteId);
    }
}
