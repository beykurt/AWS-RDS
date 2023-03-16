using RDS.Libs.Data;
using RDS.Libs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Libs.Interfaces
{
    public interface IGetPerson
    {
        Task<List<Person>> GetPersons(RDSContext context);
        Task<Person> GetPersonById(int? id, RDSContext context);
    }
}
