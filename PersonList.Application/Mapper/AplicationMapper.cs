using AutoMapper;
using PersonList.Application.Person.Commands.CreatePerson;
using PersonList.Application.Person.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonList.Application.Mapper
{
    internal class AplicationMapper : Profile
    {
        public AplicationMapper()
        {
            CreateMap<Domain.Entities.Person, PersonDto>();
            CreateMap<Domain.Entities.Person, IEnumerable<PersonDto>>();
            CreateMap<PersonDto, Domain.Entities.Person>();
            CreateMap<CreatePersonCommand, Domain.Entities.Person>();
            CreateMap<PersonDto, CreatePersonCommand>();
        }
    }
}
