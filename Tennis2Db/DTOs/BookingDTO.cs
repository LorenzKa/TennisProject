using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis2Db
{
    public class BookingDTO
    {
        [Range(1, 52)]
        public int Week { get; set; }
        [Range(1, 7)]
        public int DayOfWeek { get; set; }
        [Range(8, 22)]
        public int Hour { get; set; }
        public int PersonId { get; set; }

        
    }
}
