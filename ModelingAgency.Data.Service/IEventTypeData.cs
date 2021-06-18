using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service
{
    public interface IEventTypeData
    {
        public IEnumerable<EventType> GetAll();
        public EventType Get(int eventTypeId);
        public void Create(EventType eventTypeToAdd);
        public void Edit(EventType eventTypeToUpdate);
        public void Delete(int clientToDeleteId);
    }
}
