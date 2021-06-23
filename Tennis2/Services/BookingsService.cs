using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennis2Db;

namespace Tennis2.Services
{
    public class BookingsService : IBookingService
    {
        private readonly Tennis2Context db;

        public BookingsService(Tennis2Context db)
        {
            this.db = db;
        }
        public IEnumerable<Booking> GetAll()
        {
            return db.Bookings.AsEnumerable();
        }
        public Booking GetSingle(int id)
        {
            return db.Bookings.Where(x => x.Id == id).FirstOrDefault();
        }
        public Booking Insert(Booking booking)
        {
            Console.WriteLine(booking.ToString());
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            db.Bookings.Add(booking);
            db.SaveChanges();
            Console.WriteLine(db.Bookings.ToList().Count);
            return booking;
        }
        public Booking Update(int id, Booking booking)
        {
            Booking toChange = db.Bookings.Where(x => x.Id == id).FirstOrDefault();
            
            toChange.PersonId = booking.PersonId;
            toChange.Hour = booking.Hour;
            toChange.DayOfWeek = booking.DayOfWeek;
            toChange.Week = booking.Week;
            db.SaveChanges();
            return toChange;
        }
        public Booking Delete(int id)
        {
            Booking deleted = db.Bookings.Where(x => x.Id == id).FirstOrDefault();
            db.Bookings.Remove(deleted);
            db.SaveChanges();
            return deleted;
        }

        public IEnumerable<Booking> GetForUser(int id)
        {
            return db.Bookings.Where(x => x.PersonId == id).AsEnumerable();
        }
    }
}
