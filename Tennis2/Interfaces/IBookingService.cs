using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennis2Db;

namespace Tennis2
{
    public interface IBookingService
    {
        Booking Delete(int id);
        IEnumerable<Booking> GetAll();
        Booking GetSingle(int id);
        Booking Insert(Booking booking);
        Booking Update(int id, Booking booking);
        IEnumerable<Booking> GetForUser(int id);
    }
}
