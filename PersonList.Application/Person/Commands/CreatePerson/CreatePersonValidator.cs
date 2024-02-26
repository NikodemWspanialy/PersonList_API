using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonList.Application.Person.Commands.CreatePerson
{
    public class CreatePersonValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonValidator()
        {
            RuleFor(x => x.firstName).NotNull().MinimumLength(3);
            RuleFor(x => x.lastname).NotNull();
            
        }
    }
}
