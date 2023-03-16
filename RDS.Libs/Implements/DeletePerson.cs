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
    public class DeletePerson : IDeletePerson
    {
        private readonly IGetPerson _getPerson;

        public DeletePerson(IGetPerson getPerson)
        {
            _getPerson = getPerson;
        }

        public async Task DeletePersonById(int id, RDSContext context)
        {
            var person = await _getPerson.GetPersonById(id, context);
            context.Persons.Remove(person);
            await context.SaveChangesAsync();
        }
    }
}
