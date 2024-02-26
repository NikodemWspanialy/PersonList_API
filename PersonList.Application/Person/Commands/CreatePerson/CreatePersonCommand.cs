using MediatR;
using PersonList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonList.Application.Person.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest<int>
    {
        public string? firstName { get; set; }
        public string? lastname { get; set; }
        public int age { get; set; }
        public Contact contact { get; set; } = new();
    }
}
