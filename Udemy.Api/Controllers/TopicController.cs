using AutoMapper;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.UseCases.TopicUseCases.Commands;
using Udemy.Application.UseCases.TopicUseCases.Handlers;
using Udemy.Application.UseCases.TopicUseCases.Queries;
using Udemy.Domain.DTOS;
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
        public async Task<ResponceModel> CreateTopic(TopicDTO topicDTO)
        {
            var fileName = Path.GetFileName(topicDTO.imagefile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\topics", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await topicDTO.imagefile.CopyToAsync(fileStream);
            }
            CreateTopicCommand command = new CreateTopicCommand()
            {
                CategoryId=topicDTO.CategoryId,
                Name=topicDTO.Name,
                Description=topicDTO.Description,
                TopicPhotoPath=filePath
            };
            return await _mediator.Send(command);
        }
        [HttpGet]
        public async Task<List<TopicModel>> GetAllTopics()
        {
            return await _mediator.Send(new GetAllTopicCommandQuery ());
        }
        [HttpPut]
        public async Task<ResponceModel> UpdateTopic(TopicUDTO topicUDTO)
        {
            var fileName = Path.GetFileName(topicUDTO.imagefile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\topics", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await topicUDTO.imagefile.CopyToAsync(fileStream);
            }
            UpdateTopicCommand command = new UpdateTopicCommand()
            {
                Id = topicUDTO.Id,
                Name = topicUDTO.Name,
                Description = topicUDTO.Description,
                TopicPhotoPath = filePath
            };
            return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<ResponceModel> DeleteTopic(DeleteTopicCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
