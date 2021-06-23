using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennis2Db;

namespace Tennis2.Interfaces
{
    public interface IPersonService
    {
        Person Delete(int id);
        IEnumerable<Person> GetAll();
        Person GetSingle(int id);
        Person Insert(Person person);
        Person Update(int id, Person person);
    }
}
