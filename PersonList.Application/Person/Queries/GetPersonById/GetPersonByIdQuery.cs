using MediatR;
using PersonList.Application.Person.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonList.Application.Person.Queries.GetPersonById
{
    public class GetPersonByIdQuery : IRequest<PersonDto>
    {
        public int id { get; set; }

        public GetPersonByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
