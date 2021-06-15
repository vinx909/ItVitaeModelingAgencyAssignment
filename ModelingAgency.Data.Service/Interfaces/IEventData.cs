using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service
{
    public interface IEventTypeData
    {
        public ICollection<Event> GetAll();
        public Event Get(int eventId);
        public ICollection<Event> Get(string searchQuiry);
        public void Create(Event eventToAdd);
        public void Edit(Event eventToUpdate);
        public void Delete(int eventToDeleteId);
    }
}
