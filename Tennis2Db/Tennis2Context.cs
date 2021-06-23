using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis2Db
{
    public class Tennis2Context : DbContext
    {

        public Tennis2Context(DbContextOptions<Tennis2Context> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = @"server=(LocalDB)\mssqllocaldb;attachdbfilename=C:\Users\loren\OneDrive\Schule\4_Klasse\POS_WEB\createWebApiProject\Tennis2\Tennis2Db\Tennis2.mdf;database=Tennis2;integrated security=True";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }

}
