
using Microsoft.Extensions.DependencyInjection;
using PersonList.Application.Mapper;
using PersonList.Application.Person.Queries.GetPersons;
using MediatR;
using FluentValidation.AspNetCore;
using PersonList.Application.Person.Commands.CreatePerson;
using FluentValidation;

namespace PersonList.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AplicationMapper));
            services.AddMediatR(typeof(GetPersonsQueryHandler));
            services.AddValidatorsFromAssemblyContaining<CreatePersonValidator>()
                .AddFluentValidationAutoValidation();
        }
    }
}
