using Microsoft.EntityFrameworkCore;
using ModelingAgency.Data.Service.Infrastructure.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service
{
    public class TypeEventData : ITypeEventData
    {
        private readonly ModelingAgencyContext db;

        public TypeEventData(ModelingAgencyContext db)
        {
            this.db = db;
        }

        public void Create(EventType eventTypeToAdd)
        {
            db.EventTypes.Add(eventTypeToAdd);
        }

        public void Delete(int eventTypeToDeleteId)
        {
            var eventType = db.EventTypes.FirstOrDefault(e => e.Id == eventTypeToDeleteId);
        }

        public void Edit(EventType eventTypeToUpdate)
        {
            db.Entry(eventTypeToUpdate).State = EntityState.Modified;
        }

        public EventType Get(int eventTypeId)
        {
            return db.EventTypes.FirstOrDefault(e => e.Id == eventTypeId);
        }

        public ICollection<EventType> Get(string searchQuiry)
        {
            return db.EventTypes.Where(e => e.Name.Contains(searchQuiry)).ToList();
        }

        public ICollection<EventType> GetAll()
        {
            return db.EventTypes.ToList();
        }
    }
}
