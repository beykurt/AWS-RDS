using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RDS.Libs.Data;
using RDS.Libs.Implements;
using RDS.Libs.Interfaces;
using RDS.Libs.Models;

namespace RDS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RDSController : ControllerBase
    {
        private readonly IGetPerson _getPerson;
        private readonly IPutPerson _putPerson;
        private readonly IDeletePerson _deletePerson;
        private readonly RDSContext _context;

        public RDSController(RDSContext context, IGetPerson getPerson, IPutPerson putPerson, IDeletePerson deletePerson)
        {
            _context = context;
            _getPerson = getPerson;
            _putPerson = putPerson;
            _deletePerson = deletePerson;
        }

        //ÖRNEK POSTMAN: [GET] https://localhost:7233/RDS/getpersons
        [HttpGet]
        [Route("getpersons")]
        public async Task<IActionResult> GetPersons()
        {
            var response = await _getPerson.GetPersons(_context);
            return Ok(response);
        }

        //ÖRNEK POSTMAN: [GET] https://localhost:7233/RDS/getpersonbyid?id=1
        [HttpGet]
        [Route("getpersonbyid")]
        public async Task<IActionResult> GetPersonById(int id)
        {
            var response = await _getPerson.GetPersonById(id, _context);
            return Ok(response);
        }

        //ÖRNEK POSTMAN: [POST] https://localhost:7233/RDS/insertperson
        //Body:
        //{
        //  "idPerson": 7,
        //  "name": "Arthem ",
        //  "surname": "Tayh",
        //  "mail": "arthemt@gmail.com",
        //  "phone": "75323457"
        //}
        [HttpPost]
        [Route("insertperson")]
        public async Task<IActionResult> PutPersons([FromBody] Person person)
        {
            try
            {
                await _putPerson.PutPersons(person, _context);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }

        //ÖRNEK POSTMAN: [DELETE] https://localhost:7233/RDS/deleteperson?id=7
        [HttpDelete]
        [Route("deleteperson")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            try
            {
                await _deletePerson.DeletePersonById(id, _context);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }
    }
}