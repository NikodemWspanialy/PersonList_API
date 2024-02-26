using AutoMapper;
using MediatR;
using PersonList.Application.Person.Dtos;
using PersonList.Domain.Interfaces;

namespace PersonList.Application.Person.Queries.GetPersons
{
    internal class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, IEnumerable<PersonDto>>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public GetPersonsQueryHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public Task<IEnumerable<PersonDto>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            var persons = repository.GetAllPersons();
            var personsDto = mapper.Map<IEnumerable<PersonDto>>(persons);
            return Task.FromResult(personsDto);
        }
    }
}
