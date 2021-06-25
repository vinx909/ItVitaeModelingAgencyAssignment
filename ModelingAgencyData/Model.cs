using System;
using System.Collections.Generic;

namespace ModelingAgency.Data
{
    public class Model//TODO: probably inherite from a person class but related to identify framework
    {
        public int Id { get; set; }
        //NAW-gegevens (Naam, adres, woonplaats)
        public string Name { get; set; }
        public int AddressNumber { get; set; }
        public string Postalcode { get; set; }
        public string City { get; set; }
        public Int16 Age { get; set; }
        //lichaams maten
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public int Length { get; set; }
        public int ClothingSize { get; set; }

        public ICollection<Image> images { get; set; }
        public int TelephoneNumber { get; set; }
        public string EMailAdress { get; set; }
        public string Description { get; set; }
        public Model EditOf { get; set; }
        public bool Aproved { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
