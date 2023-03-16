using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RDS.Libs.Data;
using RDS.Libs.Interfaces;
using RDS.Libs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Libs.Implements
{
    public class PutPerson : IPutPerson
    {
        public PutPerson()
        {
        }

        public async Task PutPersons(Person person, RDSContext context)
        {
            context.Persons.Add(person);
            await context.SaveChangesAsync();
        }
    }
}
