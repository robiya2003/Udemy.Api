using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.UseCases.RegisterUserCases.Commands;
using Udemy.Application.UseCases.RegisterUserCases.Queries;
using Udemy.Domain.MODELS;

namespace Udemy.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegistratsiyaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RegistratsiyaController(IMediator mediator)
        {
            _mediator = mediator;
        }
       
        [HttpPost]
        public async Task<ResponceModel> Createuser(CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpGet]
        public async Task<List<UserModel>> GetUsers()
        {
            return await _mediator.Send(new GetUsersCommandQuery());
        }
        [HttpGet]
        public async Task<UserModel> GetByid(int id)
        {
            return await _mediator.Send(new GetByIdCommandQuery() { Id=id});
        }
        [HttpDelete]
        public async Task<ResponceModel> DeleteUser(int id)
        {
            return await _mediator.Send(new DeleteUserCommand() { Id=id});
        }
        [HttpPut]
        public async Task<UserModel> UpdateUser(UpdateUserCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
