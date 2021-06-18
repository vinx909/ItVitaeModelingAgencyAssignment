using System;
using System.Collections.Generic;

namespace ModelingAgency.Data.Service
{
    public interface IClientData
    {
        public IEnumerable<Client> GetAll();
        public IEnumerable<Client> GetFromSeachQuiry(Func<Client, bool> searchQuiry);
        public Client Get(int clientId);
        public void Create(Client clientToAdd);
        public void Edit(Client clientToUpdate);
        public void Delete(int clientToDeleteId);
    }
}
