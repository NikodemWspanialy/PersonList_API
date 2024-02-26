using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonList.Domain.Interfaces;
using PersonList.Infrastructure.Persistance;
using PersonList.Infrastructure.Repositories;
using PersonList.Infrastructure.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonList.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("server")));
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<PersonSeeder>();
        }
    }
}
