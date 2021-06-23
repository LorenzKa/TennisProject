using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennis2.Services;
using Tennis2Db;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tennis2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService bookingsService;

        public BookingsController(IBookingService bookingsService)
        {
            this.bookingsService = bookingsService;
        }

        // GET: api/<BookingsController>
        [HttpGet]
        public IEnumerable<BookingReplyDTO> Get()
        {

            return bookingsService.GetAll().Select(x => new BookingReplyDTO().CopyPropertiesFrom(x));
        }

        // GET api/<BookingsController>/5
        [HttpGet("{id}")]
        public BookingReplyDTO Get(int id)
        {
            return new BookingReplyDTO().CopyPropertiesFrom(bookingsService.GetSingle(id));
        }

        // POST api/<BookingsController>
        [HttpPost]
        public BookingReplyDTO Post([FromForm] BookingDTO value)
        {
            Console.WriteLine(value.PersonId);
            return new BookingReplyDTO().CopyPropertiesFrom(bookingsService.Insert(new Booking().CopyPropertiesFrom(value)));
        }

        // PUT api/<BookingsController>/5
        [HttpPut("{id}")]
        public BookingReplyDTO Put(int id, [FromBody] BookingDTO value)
        {
            return new BookingReplyDTO().CopyPropertiesFrom(bookingsService.Update(id, new Booking().CopyPropertiesFrom(value)));
        }

        // DELETE api/<BookingsController>/5
        [HttpDelete("{id}")]
        public BookingReplyDTO Delete(int id)
        {
            return new BookingReplyDTO().CopyPropertiesFrom(bookingsService.Delete(id));
        }
        [HttpGet("user/{id}")]
        public IEnumerable<BookingReplyDTO> GetForUser(int id)
        {
            return bookingsService.GetForUser(id).Select(x => new BookingReplyDTO().CopyPropertiesFrom(x));
        }
    }

}
