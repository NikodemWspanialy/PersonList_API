using Microsoft.EntityFrameworkCore;
using PersonList.Domain.Entities;
using PersonList.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

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
                string filePath = "C:\\PRJs\\ASP.NET_CORE_PRJs\\PRJs\\PersonList\\PersonList.Infrastructure\\Seeders\\people.json";
                var json = File.ReadAllText(filePath);
                var personList = JsonConvert.DeserializeObject<List<Person>>(json);
                if(personList != null && personList.Any())
                foreach(var person in personList)
                {
                        await dbContext.persons.AddAsync(person);
                }
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
