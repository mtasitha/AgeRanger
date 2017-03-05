using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeRanger.Web.Models
{
    public class AgeRangerRepository : IRepository
    {
        private AgeRangerDbContext _db;

        public AgeRangerRepository(AgeRangerDbContext db)
        {
            _db = db;
        }
        public AgeRangerRepository()
        {
            _db = new AgeRangerDbContext();   
        }

        // General
        public bool SaveAll()
        {
            try
            {
                return _db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Person
        public IQueryable<Person> GetPersons()
        {
            return _db.Persons.AsQueryable();
        }
        public IQueryable<Person> GetPersons(string SearchText)
        {
            return _db.Persons.Where(p => p.FirstName.ToLower().Contains(SearchText.ToLower()) || p.LastName.Contains(SearchText.ToLower()) || string.IsNullOrEmpty(SearchText) || SearchText.ToLower() == "null").AsQueryable();
        }
        public Person GetPerson(int id)
        {
            return _db.Persons.Where(p => p.Id == id).FirstOrDefault();
        }
        public bool AddPerson(Person person)
        {
            if (person == null)
                return false;

            try
            {
                Person _person = _db.Persons.Where(u => u.Id == person.Id).FirstOrDefault();
                if (_person != null)
                {
                    _person.FirstName = person.FirstName;
                    _person.LastName = person.LastName;
                    _person.Age = person.Age;
                }
                else
                {
                    _db.Persons.Add(person);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // AgeGroup
        public IEnumerable<AgeGroup> GetAgeGroups()
        {
            return _db.AgeGroups.AsQueryable();
        }
        public AgeGroup GetAgeGroup(int id)
        {
            return _db.AgeGroups.Where(p => p.Id == id).FirstOrDefault();
        }
        
    }
}
