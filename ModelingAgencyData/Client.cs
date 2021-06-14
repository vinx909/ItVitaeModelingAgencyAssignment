using System.Collections.Generic;

namespace ModelingAgency.Data
{
    public class Client : Person
    {
        public int KVKNumber { get; set; }
        public int BTWNumber { get; set; }
        public Client EditOf { get; set; }
        public bool Aproved { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
