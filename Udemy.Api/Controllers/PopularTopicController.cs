using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.UseCases.PopularTopicUseCases.Commands;
using Udemy.Application.UseCases.PopularTopicUseCases.Queries;
using Udemy.Domain.DTOS;
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
        public async Task<ResponceModel> CreatePopularTopic(PopularTopicDTO topicDTO)
        {
            var fileName = Path.GetFileName(topicDTO.imagefile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\populartopics", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await topicDTO.imagefile.CopyToAsync(fileStream);
            }
            CreatePopularTopicCommand command = new CreatePopularTopicCommand()
            {
                Name=topicDTO.Name,
                Description=topicDTO.Description,
                PopularTopicPhotoPath=filePath,
                TopicId=topicDTO.TopicId,
            };
            return await _mediator.Send(command);
        }
        [HttpGet]
        public async Task<List<PopularTopicModel>> GetAllPopularTopic()
        {
            return await _mediator.Send(new GetAllPopularTopicCommandQuery());
        }
        [HttpPut]
        public async Task<ResponceModel> UpdatePopularTopic(PopularTopicUDTO topicUDTO)
        {
            var fileName = Path.GetFileName(topicUDTO.imagefile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\categories", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await topicUDTO.imagefile.CopyToAsync(fileStream);
            }
            UpdatePopularTopicCommand command = new UpdatePopularTopicCommand()
            {
                PopularTopicPhotoPath = filePath,
                TopicId=topicUDTO.TopicId,
                Name=topicUDTO.Name,
                Description=topicUDTO.Description,
                Id=topicUDTO.Id
            };
            return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<ResponceModel> DeletePopularTopic(DeletePopularTopicCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
