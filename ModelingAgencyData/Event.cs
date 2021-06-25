using System;
using System.Collections.Generic;

namespace ModelingAgency.Data
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Client Client { get; set; }
        public EventType EventType { get; set; }
        public int AddressNumber { get; set; }
        public string Postalcode { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}
