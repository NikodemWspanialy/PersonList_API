using MediatR;
using PersonList.Application.Person.Dtos;

namespace PersonList.Application.Person.Queries.GetPersons
{
    public class GetPersonsQuery : IRequest<IEnumerable<PersonDto>>
    {
    }
}
