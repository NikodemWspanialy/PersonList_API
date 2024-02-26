using AutoMapper;
using MediatR;
using PersonList.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonList.Application.Person.Commands.CreatePerson
{
    internal class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public CreatePersonCommandHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        async Task<int> IRequestHandler<CreatePersonCommand, int>.Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var newPerson = mapper.Map<Domain.Entities.Person>(request);
            return await repository.AddPerson(newPerson);
        }
    }
}
