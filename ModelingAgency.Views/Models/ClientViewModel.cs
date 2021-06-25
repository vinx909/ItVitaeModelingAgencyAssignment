using ModelingAgency.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelingAgency.Views.Models
{
    public class ClientViewModel
    {
        //NAW-gegevens (Naam, adres, woonplaats)
        public string Name { get; set; }
        public string City { get; set; }
        //TODO: logo
        public int KVKNumber { get; set; }
        public int BTWNumber { get; set; }
        public Client EditOf { get; set; }
        public bool Aproved { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
