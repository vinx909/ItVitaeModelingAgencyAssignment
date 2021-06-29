using System.Collections.Generic;

namespace ModelingAgency.Data
{
    public class Client
    {
        public int Id { get; set; }
        //NAW-gegevens (Naam, adres, woonplaats)
        public string Name { get; set; }
        public int AddressNumber { get; set; }
        public string Postalcode { get; set; }
        public string City { get; set; }
        public int KVKNumber { get; set; }
        public int BTWNumber { get; set; }
        public Client EditOf { get; set; }
        public bool Aproved { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
