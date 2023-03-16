using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Libs.Models
{
    public  class Person
    {
        public int IdPerson { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
