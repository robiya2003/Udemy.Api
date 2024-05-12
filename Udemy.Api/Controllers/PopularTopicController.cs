using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.UseCases.PopularTopicUseCases.Commands;
using Udemy.Application.UseCases.PopularTopicUseCases.Queries;
using Udemy.Domain.MODELS;

namespace Udemy.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PopularTopicController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PopularTopicController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponceModel> CreatePopularTopic(CreatePopularTopicCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpGet]
        public async Task<List<PopularTopicModel>> GetAllPopularTopic()
        {
            return await _mediator.Send(new GetAllPopularTopicCommandQuery());
        }
        [HttpPut]
        public async Task<ResponceModel> UpdatePopularTopic(UpdatePopularTopicCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<ResponceModel> DeletePopularTopic(DeletePopularTopicCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
