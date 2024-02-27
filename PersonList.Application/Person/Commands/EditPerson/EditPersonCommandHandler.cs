using MediatR;
using PersonList.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonList.Application.Person.Commands.EditPerson
{
    internal class EditPersonCommandHandler : IRequestHandler<EditPersonCommand, int>
    {
        private readonly IRepository repository;

        public EditPersonCommandHandler(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> Handle(EditPersonCommand request, CancellationToken cancellationToken)
        {
            var originalPerson = await repository.GetPersonById(request.id);
            if (originalPerson == null)
            {
                throw new NullReferenceException("Can not find person to edit");
            }
            try
            {
                originalPerson.lastname = request.lastname;
                originalPerson.firstName = request.firstName;
                originalPerson.contact = request.contact;
                originalPerson.age = request.age;
            }
            catch
            {
                throw new Exception("Can not change data");
            }
            await repository.SaveChangesAsync();
            return originalPerson.id;
        }
    }
}
