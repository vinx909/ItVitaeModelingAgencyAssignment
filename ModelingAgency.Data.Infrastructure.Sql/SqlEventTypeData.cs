using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service.Infrastructure.Sql
{
    public class SqlEventTypeData : IEventTypeData
    {
        private readonly ModelingAgencyContext dbContext;

        public SqlEventTypeData(ModelingAgencyContext modelingAgencyContext)
        {
            dbContext = modelingAgencyContext;
        }

        public void Create(EventType eventTypeToAdd)
        {
            dbContext.Add(eventTypeToAdd);
            dbContext.SaveChanges();
        }

        public void Delete(int clientToDeleteId)
        {
            dbContext.Remove(Get(clientToDeleteId));
            dbContext.SaveChanges();
        }

        public void Edit(EventType eventTypeToUpdate)
        {
            dbContext.Update(eventTypeToUpdate);
            dbContext.SaveChanges();
        }

        public EventType Get(int eventTypeId)
        {
            return dbContext.Find<EventType>(eventTypeId);
        }

        public IEnumerable<EventType> GetAll()
        {
            return dbContext.EventTypes;
        }
    }
}
