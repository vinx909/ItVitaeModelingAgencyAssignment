using System;
using System.Collections.Generic;

namespace ModelingAgency.Data
{
    public class Model : Person
    {
        //TODO: NAW-gegevens
        public Int16 Age { get; set; }
        //lichaams maten
        public ICollection<Image> Images { get; set; }
        public int TelephoneNumber { get; set; }
        public string EMailAdress { get; set; }
        public string Description { get; set; }
        public Model EditOf { get; set; }
        public bool Aproved { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
