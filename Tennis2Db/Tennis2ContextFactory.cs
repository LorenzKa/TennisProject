using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis2Db
{
    class Tennis2ContextFactory : IDesignTimeDbContextFactory<Tennis2Context>
    {
        public Tennis2Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Tennis2Context>();
            var connectionString = @"server=(LocalDB)\mssqllocaldb;attachdbfilename=C:\Users\loren\OneDrive\Schule\4_Klasse\POS_WEB\createWebApiProject\Tennis2\Tennis2Db\Tennis2.mdf;database=Tennis2;integrated security=True";
            optionsBuilder.UseSqlServer(connectionString);
            return new Tennis2Context(optionsBuilder.Options);
        }

    }
}
