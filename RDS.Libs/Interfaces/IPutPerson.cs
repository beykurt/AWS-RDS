using RDS.Libs.Data;
using RDS.Libs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Libs.Interfaces
{
    public interface IPutPerson
    {
        Task PutPersons( Person person, RDSContext context);
    }
}
