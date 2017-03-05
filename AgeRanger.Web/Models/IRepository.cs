using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeRanger.Web.Models
{
    public interface IRepository
    {
        // General
        bool SaveAll();

        // Person
        IQueryable<Person> GetPersons();
        IQueryable<Person> GetPersons(string SearchText);
        Person GetPerson(int id);
        bool AddPerson(Person person);

        // AgeGroup
        IEnumerable<AgeGroup> GetAgeGroups();
        AgeGroup GetAgeGroup(int id);
    }
}
