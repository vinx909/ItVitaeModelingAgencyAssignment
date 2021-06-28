using System.Collections.Generic;

namespace ModelingAgency.Data
{
    public class Client : Person
    {

        public int AddressNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public int KVKNumber { get; set; }
        public int BTWNumber { get; set; }
        public Client EditOf { get; set; }
        public bool Aproved { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
