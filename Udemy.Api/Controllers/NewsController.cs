using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.UseCases.NewsUseCases.Commands;
using Udemy.Application.UseCases.NewsUseCases.Queries;
using Udemy.Domain.MODELS;

namespace Udemy.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NewsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponceModel> CreateNews(CreateNewsCommand command)
        {
            return  await _mediator.Send(command);
        }
        [HttpGet]
        public async Task<List<NewsModel>> GetAllNews()
        {
            return await _mediator.Send(new GetAllNewsCommandQuery());
        }
        [HttpPut]
        public async Task<ResponceModel> UpdateNews(UpdateNewsCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<ResponceModel> DeleteNews(DeleteNewsCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
