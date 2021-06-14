using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service
{
    public interface IEventData
    {
        public IEnumerable<Event> GetAll();
        public IEnumerable<Event> Get(Func<Event, bool> searchQuiry);
        public Event Get(int eventId);
        public void Create(Event eventToCreate);
        public void Edit(Event eventToEdit);
        public void Delete(int eventToDeleteId);
    }
}
