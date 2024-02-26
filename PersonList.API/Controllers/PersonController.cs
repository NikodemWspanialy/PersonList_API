using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PersonList.API.Models;
using PersonList.Application.Person.Commands.CreatePerson;
using PersonList.Application.Person.Dtos;
using PersonList.Application.Person.Queries.GetPersonById;
using PersonList.Application.Person.Queries.GetPersons;
using System.Runtime.CompilerServices;

namespace PersonList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IMediator mediator;
        private readonly IValidator<CreatePersonCommand> validator;
        private ApiResponse apiResponse;
        public PersonController(IMediator mediator, IValidator<CreatePersonCommand> validator)
        {
            apiResponse = new();
            this.mediator = mediator;
            this.validator = validator;
        }

        /// <summary>
        /// Creating new user
        /// </summary>
        /// <param name="person"></param>
        /// <returns>created user's ID</returns>
        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreatePerson([FromBody] CreatePersonCommand person)
        {

            if (person == null)
            {
                apiResponse.statusCode = System.Net.HttpStatusCode.NotFound;
            }
            else
            {

                try
                {
                    var result = await validator.ValidateAsync(person);
                    if (!result.IsValid)
                    {
                        throw new Exception(result.Errors.ToString());
                    }

                    var newPersonId = await mediator.Send(person);
                    apiResponse.isSuccess = true;
                    apiResponse.result = newPersonId;
                    apiResponse.statusCode = System.Net.HttpStatusCode.OK;
                    return apiResponse;
                }
                catch (Exception ex)
                {
                    apiResponse.statusCode = System.Net.HttpStatusCode.BadRequest;
                    apiResponse.errorList = new List<string> { ex.Message };
                }
            }
            apiResponse.isSuccess = false;
            return apiResponse;
        }


        /// <summary>
        /// Getter for all Persons in the database
        /// </summary>
        /// <returns></returns>
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
        /// Getter for person, which specified id 
        /// </summary>
        /// <param name="id">id of person</param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "getPerson")]
        public async Task<ActionResult<ApiResponse>> GetPersonById(int id = 1)
        {
            try
            {
                var person = await mediator.Send(new GetPersonByIdQuery(id));
                apiResponse.isSuccess = true;
                apiResponse.statusCode = System.Net.HttpStatusCode.OK;
                apiResponse.result = person;
                return apiResponse;
            }
            catch (Exception ex)
            {
                apiResponse.errorList = new List<string> { ex.Message };
                apiResponse.isSuccess = false;
                return apiResponse;
            }
        }
    }
}

