using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.UseCases.AutherUseCases.Commands;
using Udemy.Application.UseCases.AutherUseCases.Queries;
using Udemy.Domain.MODELS;

namespace Udemy.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AutherController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AutherController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponceModel> CreateAuther(CreateAutherCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpGet]
        public async Task<List<AutherModel>> GetAllAuther()
        {
            return await _mediator.Send(new GetAllAutherCommandQuery());
        }
        [HttpPut]
        public async Task<ResponceModel> UpdateAuther(UpdateAutherCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<ResponceModel> DeleteAuther(DeleteAutherCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
