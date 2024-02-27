using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PersonList.Application.Models;
using PersonList.Application.Person.Commands.CreatePerson;
using PersonList.Application.Person.Commands.DeletePerson;
using PersonList.Application.Person.Commands.EditPerson;
using PersonList.Application.Person.Dtos;
using PersonList.Application.Person.Queries.GetPersonById;
using PersonList.Application.Person.Queries.GetPersons;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace PersonList.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IMediator mediator;
        private readonly IValidator<CreatePersonCommand> createValidator;
        private readonly IValidator<EditPersonCommand> editValidator;
        private ApiResponse apiResponse;
        public PersonController(IMediator mediator, IValidator<CreatePersonCommand> validator, IValidator<EditPersonCommand> editValidator)
        {
            apiResponse = new();
            this.mediator = mediator;
            this.createValidator = validator;
            this.editValidator = editValidator;
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
                    var result = await createValidator.ValidateAsync(person);
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ApiResponse>> EditPerson([FromBody] EditPersonCommand editPersonCommand)
        {
            if (editPersonCommand == null)
            {
                apiResponse.statusCode = System.Net.HttpStatusCode.NoContent;
                return apiResponse;
            }
            var validResult = editValidator.Validate(editPersonCommand);
            if (!validResult.IsValid)
            {
                apiResponse.statusCode = System.Net.HttpStatusCode.BadRequest;
                return apiResponse;
            }
            try
            {
                var result = await mediator.Send(editPersonCommand);
                apiResponse.result = result;
                apiResponse.statusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                apiResponse.errorList = new List<string> { ex.Message };
                apiResponse.isSuccess = false;
            }
            return apiResponse;
        }

        /// <summary>
        /// Delete person witch specified ID
        /// </summary>
        /// <param name="id">person ID</param>
        /// <returns></returns>
        [HttpDelete("{id:int}", Name = "DeletePerson")]
        public async Task<ActionResult<ApiResponse>> Delete(int id)
        {
            try
            {
                var result = await mediator.Send(new deletePersonCommand(id));
                if (result)
                {
                    apiResponse.statusCode = System.Net.HttpStatusCode.OK;
                    apiResponse.isSuccess = true;
                    return apiResponse;
                }
            }catch(Exception ex)
            {
                apiResponse.errorList = new List<string> { ex.Message };
            }
            apiResponse.isSuccess=false;
            apiResponse.statusCode = System.Net.HttpStatusCode.BadRequest;
            return apiResponse;
        }
    }
}

