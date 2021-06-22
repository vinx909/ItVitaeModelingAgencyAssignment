using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service
{
    public interface IImageData
    {
        public IEnumerable<Image> GetAll();
        public IEnumerable<Image> GetAllOfModel(int modelId);
        public Image Get(int imageId);
        public void Create(Image imageToAdd);
        public void Edit(Image imageToUpdate);
        public void Delete(int imageToDeleteId);
    }
}
