using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennis2.Interfaces;
using Tennis2Db;

namespace Tennis2
{
    public class PersonsService : IPersonService
    {
        private readonly Tennis2Context db;

        public PersonsService(Tennis2Context db)
        {
            this.db = db;
        }
        public IEnumerable<Person> GetAll()
        {
            return db.Persons.AsEnumerable();
        }
        public Person GetSingle(int id)
        {
            return db.Persons.Where(x => x.Id == id).FirstOrDefault();
        }
        public Person Insert(Person persons)
        {
            db.Persons.Add(persons);
            db.SaveChanges();
            return persons;
        }
        public Person Update(int id, Person persons)
        {
            Person toChange = db.Persons.Where(x => x.Id == id).FirstOrDefault();
            toChange.Firstname = persons.Firstname;
            toChange.Lastname = persons.Lastname;
            toChange.Age = persons.Age;
            db.SaveChanges();
            return toChange;
        }
        public Person Delete(int id)
        {
            Person deleted = db.Persons.Where(x => x.Id == id).FirstOrDefault();
            db.Persons.Remove(deleted);
            db.SaveChanges();
            return deleted;
        }
    }
}
