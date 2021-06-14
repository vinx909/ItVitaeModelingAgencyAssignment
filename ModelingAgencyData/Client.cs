using System.Collections.Generic;

namespace ModelingAgency.Data
{
    public class Client//TODO: probably inherite from a person class but related to identify framework
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        //NAW-gegevens (Naam, adres, woonplaats)
        public string Name { get; set; }
        public int AddressNumber { get; set; }
        public string Postalcode { get; set; }
        public string City { get; set; }
        //TODO: logo
        public int KVKNumber { get; set; }
        public int BTWNumber { get; set; }
        public Client EditOf { get; set; }
        public bool Aproved { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
