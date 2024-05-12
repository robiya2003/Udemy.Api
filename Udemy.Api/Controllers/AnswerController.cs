using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.UseCases.AnswerUseCases.Commands;
using Udemy.Application.UseCases.AnswerUseCases.Queries;
using Udemy.Domain.MODELS;

namespace Udemy.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AnswerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponceModel> CreateAnswer(CreateAnswerCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpGet]
        public async Task<List<AnswerModel>> GetAllAnswer()
        {
            return await _mediator.Send(new GetAllAnswerCommandQuery());
        }
        [HttpPut]
        public async Task<ResponceModel> UpdateAnswer(UpdateAnswerCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<ResponceModel> DeleteAnswer(DeleteAnswerCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
