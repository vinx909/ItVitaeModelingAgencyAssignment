using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service.Infrastructure.Sql
{
    public class SqlPersonData : IPersonData
    {
        private readonly ModelingAgencyContext dbContext;

        public SqlPersonData(ModelingAgencyContext modelingAgencyContext)
        {
            dbContext = modelingAgencyContext;
        }

        public void Create(Person personToAdd)
        {
            dbContext.Add(personToAdd);
            dbContext.SaveChanges();
        }

        public void Delete(int personToDeleteId)
        {
            dbContext.Remove(Get(personToDeleteId));
            dbContext.SaveChanges();
        }

        public void Edit(Person personToUpdate)
        {
            dbContext.Update(personToUpdate);
            dbContext.SaveChanges();
        }

        public Person Get(int personId)
        {
            return dbContext.Find<Person>(personId);
        }

        public Person Get(string personName)
        {
            return dbContext.People.FirstOrDefault(p => p.Name.Equals(personName));
        }

        public IEnumerable<Person> GetAll()
        {
            return dbContext.People;
        }

        public bool NameFree(string name)
        {
            return dbContext.People.Where(p=>p.Name.Equals(name)).FirstOrDefault()==null;
        }
    }
}
