using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service
{
    public interface ITypeEventData
    {
        public ICollection<EventType> GetAll();
        public EventType Get(int eventTypeId);
        public ICollection<EventType> Get(string searchQuiry);
        public void Create(EventType eventTypeToAdd);
        public void Edit(EventType eventTypeToUpdate);
        public void Delete(int eventTypeToDeleteId);
        public bool SaveChanges();
    }
}
