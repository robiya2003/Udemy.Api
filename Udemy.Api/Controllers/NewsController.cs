using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.UseCases.NewsUseCases.Commands;
using Udemy.Application.UseCases.NewsUseCases.Queries;
using Udemy.Domain.DTOS;
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
        public async Task<ResponceModel> CreateNews(NewsDTO news)
        {
            var fileName = Path.GetFileName(news.imagefile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\news", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await news.imagefile.CopyToAsync(fileStream);
            }
            CreateNewsCommand command = new CreateNewsCommand()
            {
                PhotoPath = filePath,
                PopularTopicId=news.PopularTopicId,
                Title=news.Title,
                About=news.About,
            };
            return  await _mediator.Send(command);
        }
        [HttpGet]
        public async Task<List<NewsModel>> GetAllNews()
        {
            return await _mediator.Send(new GetAllNewsCommandQuery());
        }
        [HttpPut]
        public async Task<ResponceModel> UpdateNews(NewsUDTO news)
        {
            var fileName = Path.GetFileName(news.imagefile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\news", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await news.imagefile.CopyToAsync(fileStream);
            }
            UpdateNewsCommand command = new UpdateNewsCommand()
            {
                Id = news.Id,
                About = news.About,
                Title = news.Title,
                PopularTopicId = news.PopularTopicId,
                PhotoPath = filePath,

            };
            return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<ResponceModel> DeleteNews(DeleteNewsCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
