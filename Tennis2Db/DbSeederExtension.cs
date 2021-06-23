using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis2Db
{
    public static class DbSeederExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Console.WriteLine("seeding data...");
            modelBuilder.Entity<Person>().HasData(new Person
            {
                Id = 1,
                Firstname = "Fabian",
                Lastname = "Graml",
                Age = 12
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                Id = 2,
                Firstname = "Lorenz",
                Lastname = "Kassewalder",
                Age = 18
            });
            modelBuilder.Entity<Booking>().HasData(new Booking
            {
                Id =1,
                PersonId = 1,
                DayOfWeek = 1,
                Hour = 2,
                Week = 1
            });
            
            Console.WriteLine("Seeding done");
        }
    }
}
