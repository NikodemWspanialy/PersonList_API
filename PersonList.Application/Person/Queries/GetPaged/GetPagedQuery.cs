using MediatR;
using PersonList.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonList.Application.Person.Queries.GetPaged
{
    public class GetPagedQuery : IRequest<PagingModel>
    {
        public PagingModel PagingModel { get; set; }

        public GetPagedQuery(PagingModel model)
        {
            PagingModel = model;
        }
    }
}
