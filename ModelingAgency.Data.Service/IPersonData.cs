using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service
{
    public interface IPersonData
    {
        public IEnumerable<Person> GetAll();
        public Person Get(int personId);
        public Person Get(string personName);
        public void Create(Person personToAdd);
        public void Edit(Person personToUpdate);
        public void Delete(int personToDeleteId);
    }
}
