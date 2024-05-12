using AutoMapper;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.UseCases.TopicUseCases.Commands;
using Udemy.Application.UseCases.TopicUseCases.Handlers;
using Udemy.Application.UseCases.TopicUseCases.Queries;
using Udemy.Domain.MODELS;

namespace Udemy.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TopicController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponceModel> CreateTopic(CreateTopicCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpGet]
        public async Task<List<TopicModel>> GetAllTopics()
        {
            return await _mediator.Send(new GetAllTopicCommandQuery ());
        }
        [HttpPut]
        public async Task<ResponceModel> UpdateTopic(UpdateTopicCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<ResponceModel> DeleteTopic(DeleteTopicCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
