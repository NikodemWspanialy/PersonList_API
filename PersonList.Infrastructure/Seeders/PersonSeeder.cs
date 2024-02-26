using Microsoft.EntityFrameworkCore;
using PersonList.Domain.Entities;
using PersonList.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonList.Infrastructure.Seeders
{
    public class PersonSeeder
    {
        private readonly ApplicationDbContext dbContext;

        public PersonSeeder(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task Seed()
        {
            if (!(await dbContext.Database.CanConnectAsync()))
            {
                throw new Exception("Can not connect to database");
            }
            if (!dbContext.persons.Any())
            {
                //some action for seed
                var person = new Person()
                {
                    firstName = "Nikodem",
                    lastname = "Nazwisko",
                    age = 21,
                    contact = new Contact()
                    {
                        adress = "ulica 123",
                        email = "exapmle@gmail.com",
                        phoneNumber = "1234567890",
                    }
                };
                await dbContext.persons.AddAsync(person);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
