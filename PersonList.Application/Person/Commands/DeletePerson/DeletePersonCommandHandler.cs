using MediatR;
using PersonList.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonList.Application.Person.Commands.DeletePerson
{
    internal class DeletePersonCommandHandler : IRequestHandler<deletePersonCommand, bool>
    {
        private readonly IRepository repository;

        public DeletePersonCommandHandler(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<bool> Handle(deletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await repository.GetPersonById(request.Id);
            if (person == null)
            {
                throw new NullReferenceException($"person with id = {request.Id} does not exist");
            }
            await repository.DeletePersonById(request.Id);
            return true;
        }
    }
}
