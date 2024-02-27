using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonList.Application.Person.Commands.DeletePerson
{
    public class deletePersonCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public deletePersonCommand(int id)
        {
            Id = id;
        }
    }
}
