using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_Server.Models;
using Project_Server.Repositories;

namespace Project_Server.Controllers
{
    [ApiController]
    [Route("api/person")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            var people = PersonRepository.GetPeople();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public ActionResult<Person> Get(long id)
        {
            var person = PersonRepository.GetPerson(id);

            if(person != null)
            {
                return Ok(person);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Post(Person person)
        {
            PersonRepository.AddPerson(person);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(Person person, long id)
        {
            var dbPerson = PersonRepository.GetPerson(id);

            if (dbPerson != null)
            {
                PersonRepository.UpdatePerson(person);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var person = PersonRepository.GetPerson(id);

            if (person != null)
            {
                PersonRepository.DeletePerson(person);
                return Ok();
            }
            return NotFound();
        }
    }
}
