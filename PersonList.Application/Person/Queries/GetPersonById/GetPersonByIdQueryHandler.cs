using AutoMapper;
using MediatR;
using PersonList.Application.Person.Dtos;
using PersonList.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonList.Application.Person.Queries.GetPersonById
{
    internal class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonDto>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public GetPersonByIdQueryHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<PersonDto> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var person = await repository.GetPersonById(request.id);
                return mapper.Map<PersonDto>(person);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
