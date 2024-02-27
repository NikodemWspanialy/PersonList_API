using MediatR;
using PersonList.Application.Person.Dtos;
using PersonList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonList.Application.Person.Commands.EditPerson
{
    public class EditPersonCommand : PersonDto,IRequest<int>
    {

    }

}
