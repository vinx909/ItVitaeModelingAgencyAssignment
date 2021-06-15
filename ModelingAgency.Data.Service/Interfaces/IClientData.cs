using System;
using System.Collections.Generic;

namespace ModelingAgency.Data.Service
{
    public interface IClientData
    {
        public IEnumerable<Client> GetAll();
        public Client Get(int clientId);
        public Client Get(Func<Model, bool> searchQuiry);
        public void Create(Client clientToAdd);
        public void Edit(Client clientToUpdate);
        public void Delete(int clientToDeleteId);
        public bool SaveChanges();
    }
}
