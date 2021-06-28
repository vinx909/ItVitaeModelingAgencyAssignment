using Microsoft.EntityFrameworkCore;
using ModelingAgency.Data.Service.Infrastructure.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service.Repositories
{
    public class ClientData : IClientData
    {
        private readonly ModelingAgencyContext db;

        public ClientData(ModelingAgencyContext db)
        {
            this.db = db;
        }

        public void Create(Client clientToAdd)
        {
            db.Clients.Add(clientToAdd);
        }

        public void Delete(int clientToDeleteId)
        {
            var clientDelete = db.Clients.FirstOrDefault(c => c.Id == clientToDeleteId);
            if(clientDelete != null)
            {
                db.Clients.Remove(clientDelete);
            }
        }

        public void Edit(Client clientToUpdate)
        {
            db.Entry(clientToUpdate).State = EntityState.Modified;
        }

        public Client Get(int clientId)
        {
            return db.Clients.FirstOrDefault(c => c.Id == clientId);
        }

        public Client Get(Func<Model, bool> searchQuiry)
        {
            //TODO: Get(Func<Model, bool> searchQuiry) afmaken
            //    ~ Ik snap niet helemaal wat deze functe hoort te doen
            //  ? ~ Moet deze met een search input via vergelijking met de naam een ding ophalen?
            throw new NotImplementedException();
        }

        public List<Client> GetAll()
        {
            return db.Clients.ToList();
        }

        public bool SaveChanges()
        {
            return db.SaveChanges() > 0;
        }
    }
}
