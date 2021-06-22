using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service.Infrastructure.Sql
{
    public class SqlImageData : IImageData
    {
        private readonly ModelingAgencyContext dbContext;

        public SqlImageData(ModelingAgencyContext modelingAgencyContext)
        {
            dbContext = modelingAgencyContext;
        }

        public void Create(Image imageToAdd)
        {
            dbContext.Add(imageToAdd);
            dbContext.SaveChanges();
        }

        public void Delete(int imageToDeleteId)
        {
            dbContext.Remove(Get(imageToDeleteId));
            dbContext.SaveChanges();
        }

        public void Edit(Image imageToUpdate)
        {
            dbContext.Update(imageToUpdate);
            dbContext.SaveChanges();
        }

        public Image Get(int imageId)
        {
            return dbContext.Find<Image>(imageId);
        }

        public IEnumerable<Image> GetAll()
        {
            return dbContext.Images;
        }

        public IEnumerable<Image> GetAllOfModel(int modelId)
        {
            return dbContext.Images.Where(i => i.Model.Id == modelId);
        }
    }
}
