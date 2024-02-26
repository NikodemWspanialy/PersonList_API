using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonList.Domain.Entities;

namespace PersonList.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> persons { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>(p =>
            {
                p.OwnsOne(p => p.contact);
            });
            
        }
    }
}
