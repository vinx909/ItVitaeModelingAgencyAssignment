using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service.Infrastructure.Sql
{
    public class SqlClientData : IClientData
    {
        private readonly ModelingAgencyContext dbContext;

        public SqlClientData(ModelingAgencyContext modelingAgencyContext)
        {
            dbContext = modelingAgencyContext;
        }

        public void Create(Client clientToAdd)
        {
            dbContext.Add(clientToAdd);
            dbContext.SaveChanges();
        }

        public void Delete(int clientToDeleteId)
        {
            dbContext.Remove(Get(clientToDeleteId));
            dbContext.SaveChanges();
        }

        public void Edit(Client clientToUpdate)
        {
            dbContext.Update(clientToUpdate);
            dbContext.SaveChanges();
        }

        public Client Get(int clientId)
        {
            return dbContext.Find<Client>(clientId);
        }

        public IEnumerable<Client> GetAll()
        {
            return dbContext.Clients;
        }

        public IEnumerable<Client> GetFromSeachQuiry(Func<Client, bool> searchQuiry)
        {
            return dbContext.Clients.Where(searchQuiry);
        }
    }
}
