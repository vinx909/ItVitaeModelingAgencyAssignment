using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data
{
    public class Person
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }
    }
}
