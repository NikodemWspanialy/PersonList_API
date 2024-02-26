using PersonList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonList.Domain.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Person> GetAllPersons();
        Task<Person> GetPersonById(int id);
        Task<int> AddPerson(Person p);
    }
}
