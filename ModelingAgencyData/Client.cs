using System.Collections.Generic;

namespace ModelingAgency.Data
{
    public class Client//TODO: probably inherite from a person class but related to identify framework
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        //TODO: NAW-gegevens
        //TODO: logo
        public int KVKNumber { get; set; }
        public int BTWNumber { get; set; }
        public Client EditOf { get; set; }
        public bool Aproved { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
