using Microsoft.EntityFrameworkCore;
using ModelingAgency.Data.Service.Infrastructure.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service
{
    public class EventData : IEventTypeData
    {
        private readonly ModelingAgencyContext db;

        public EventData(ModelingAgencyContext db)
        {
            this.db = db;
        }

        public void Create(Event eventToAdd)
        {
            db.Events.Add(eventToAdd);
        }

        public void Delete(int eventToDeleteId)
        {
            var selectedEvent = db.Events.FirstOrDefault(e => e.Id == eventToDeleteId);
        }

        public void Edit(Event eventToUpdate)
        {
            db.Entry(eventToUpdate).State = EntityState.Modified;
        }

        public Event Get(int eventId)
        {
            return db.Events.FirstOrDefault(e => e.Id == eventId);
        }

        public ICollection<Event> Get(string searchQuiry)
        {
            return db.Events.Where(e => e.Name == searchQuiry).ToList();
        }

        public ICollection<Event> GetAll()
        {
            return db.Events.ToList();
        }
    }
}
