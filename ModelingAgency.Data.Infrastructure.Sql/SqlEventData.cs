using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service.Infrastructure.Sql
{
    class SqlEventData : IEventData
    {
        private readonly ModelingAgencyContext dbContext;

        public SqlEventData(ModelingAgencyContext modelingAgencyContext)
        {
            dbContext = modelingAgencyContext;
        }

        public void Create(Event eventToCreate)
        {
            dbContext.Add(eventToCreate);
            dbContext.SaveChanges();
        }

        public void Delete(int eventToDeleteId)
        {
            dbContext.Remove(Get(eventToDeleteId));
            dbContext.SaveChanges();
        }

        public void Edit(Event eventToEdit)
        {
            dbContext.Update(eventToEdit);
            dbContext.SaveChanges();
        }

        public IEnumerable<Event> Get(Func<Event, bool> searchQuiry)
        {
            return dbContext.Events.Where(searchQuiry);
        }

        public Event Get(int eventId)
        {
            return dbContext.Find<Event>(eventId);
        }

        public IEnumerable<Event> GetAll()
        {
            return dbContext.Events;
        }
    }
}
