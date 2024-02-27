using AutoMapper;
using MediatR;
using PersonList.Application.Models;
using PersonList.Application.Person.Dtos;
using PersonList.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonList.Application.Person.Queries.GetPaged
{
    internal class GetPagedQueryHandler : IRequestHandler<GetPagedQuery, PagingModel>
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public GetPagedQueryHandler(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<PagingModel> Handle(GetPagedQuery request, CancellationToken cancellationToken)
        {
            int counter = request.PagingModel.Count;
            int page = request.PagingModel.Page;
            if (counter <= 0 || page <= 0)
            {
                throw new ArgumentException("No valid arguments list");
            }
            var allPeople = repository.GetAllPersons();
            request.PagingModel.TotalCount = allPeople.Count();
            if (!allPeople.Any()) { throw new Exception("empty database"); }

            int startingIndex = ((page - 1) * counter) + 1;

            if (startingIndex > allPeople.Count()) { throw new Exception("database is to small for this params"); }

            var list = allPeople.OrderBy(x => x.id).Skip(startingIndex - 1).Take(counter).ToList();
            var DtoList = mapper.Map<List<PersonDto>>(list);
            request.PagingModel.Persons = DtoList;
            return request.PagingModel;
        }
    }
}
