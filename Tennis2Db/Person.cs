using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis2Db
{
    public class Person
    {
        public int Id { get; set; }
        [MinLength(3)]
        public string Firstname { get; set; }
        [MinLength(3)]
        public string Lastname { get; set; }
        [Range(10,90)]
        public int Age { get; set; }
    }
}
