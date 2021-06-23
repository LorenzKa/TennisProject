using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennis2.Interfaces;
using Tennis2Db;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tennis2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService personsService;

        public PersonsController(IPersonService personsService)
        {
            this.personsService = personsService;
        }
        [HttpGet]
        public IEnumerable<PersonReplyDTO> Get()
        {
            Console.WriteLine("GetAll");
            return personsService.GetAll().Select(x => new PersonReplyDTO().CopyPropertiesFrom(x));
        }

        // GET api/<BookingsController>/5
        [HttpGet("{id}")]
        public PersonReplyDTO Get(int id)
        {
            Console.WriteLine($"Get From {id}");
            return new PersonReplyDTO().CopyPropertiesFrom(personsService.GetSingle(id));
        }

        // POST api/<BookingsController>
        [HttpPost]
        public PersonReplyDTO Post([FromForm] PersonDTO value)
        {
            Console.WriteLine($"Post {value}");
            return new PersonReplyDTO().CopyPropertiesFrom(personsService.Insert(new Person().CopyPropertiesFrom(value)));
        }

        // PUT api/<BookingsController>/5
        [HttpPut("{id}")]
        public PersonReplyDTO Put(int id, [FromBody] PersonDTO value)
        {
            Console.WriteLine($"Put {id} For {value}");
            return new PersonReplyDTO().CopyPropertiesFrom(personsService.Update(id, new Person().CopyPropertiesFrom(value)));
        }

        // DELETE api/<BookingsController>/5
        [HttpDelete("{id}")]
        public PersonReplyDTO Delete(int id)
        {
            Console.WriteLine($"Delete {id}");
            return new PersonReplyDTO().CopyPropertiesFrom(personsService.Delete(id));
        }
    }
}
