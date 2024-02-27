using AutoMapper.Configuration.Conventions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonList.Application.Models;
using PersonList.Application.Person.Queries.GetPaged;
using PersonList.Application.Person.Queries.GetPersons;

namespace PersonList.Application.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IMediator mediator;
        private ApiResponse apiResponse;
        const int DEFAULT_COUNT = 5;
        const int DEFAULT_PAGE = 1;

        public PersonsController(IMediator mediator)
        {
            this.mediator = mediator;
            apiResponse = new();
        }

        // <summary>
        // Getter for all Persons in the database
        // </summary>
        // <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetPersonsAsync()
        {
            var items = await mediator.Send(new GetPersonsQuery());
            if (items == null)
            {
                apiResponse.isSuccess = false;
                apiResponse.statusCode = System.Net.HttpStatusCode.NoContent;
                return apiResponse;
            }
            else
            {
                apiResponse.isSuccess = true;
                apiResponse.statusCode = System.Net.HttpStatusCode.OK;
                apiResponse.result = items;
                return apiResponse;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet("paged")]
        public async Task<ActionResult<ApiResponse>> PaginationGet(int? page = DEFAULT_PAGE, int? count = DEFAULT_COUNT)
        {
            
            var pagingModel = new PagingModel { Count = count ?? DEFAULT_COUNT, Page = page ?? DEFAULT_PAGE };
            try
            {
                apiResponse.result = await mediator.Send(new GetPagedQuery(pagingModel));
                 
            }
            catch (Exception ex)
            {
                apiResponse.statusCode = System.Net.HttpStatusCode.NotFound;
                apiResponse.isSuccess = false;
                apiResponse.errorList = new List<string> { ex.Message };
            }
            return apiResponse;
        }
    }
}
