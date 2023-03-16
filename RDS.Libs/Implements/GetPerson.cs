using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RDS.Libs.Data;
using RDS.Libs.Interfaces;
using RDS.Libs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Libs.Implements
{
    public class GetPerson : IGetPerson
    {
        public GetPerson()
        {
        }

        public async Task<List<Person>> GetPersons(RDSContext context)
        {
            var persons = await context.Persons.ToListAsync();
            return persons;
        }

        public async Task<Person> GetPersonById(int? id, RDSContext context)
        {
            var person = await context.Persons.FindAsync(id);
            return person;
        }
    }
}
