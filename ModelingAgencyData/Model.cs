using System;
using System.Collections.Generic;

namespace ModelingAgency.Data
{
    public class Model//TODO: probably inherite from a person class but related to identify framework
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        //TODO: NAW-gegevens
        public Int16 Age { get; set; }
        //lichaams maten
        public ICollection<Image> images { get; set; }
        public int TelephoneNumber { get; set; }
        public string EMailAdress { get; set; }
        public string Description { get; set; }
        public Model EditOf { get; set; }
        public bool Aproved { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
