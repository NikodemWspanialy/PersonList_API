﻿using Microsoft.EntityFrameworkCore;
using PersonList.Domain.Entities;
using PersonList.Domain.Interfaces;
using PersonList.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonList.Infrastructure.Repositories
{
    internal class Repository : IRepository
    {
        private readonly ApplicationDbContext dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddPerson(Person p)
        {
             var result = await dbContext.AddAsync(p);
             await dbContext.SaveChangesAsync();
            if(result.Entity != null)
            {
                return result.Entity.id;
            }
            throw new Exception("Cant Add new Person to database");
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return dbContext.persons;
        }

        public async Task<Person> GetPersonById(int id)
        {
            var person = await dbContext.persons.FirstOrDefaultAsync(person => person.id == id);
            if (person == null)
            {
                throw new Exception("person witch that id was not found");
            }
            return person;
        }
    }
}
