using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.UseCases.LessonUseCases.Commands;
using Udemy.Application.UseCases.LessonUseCases.Queries;
using Udemy.Domain.MODELS;

namespace Udemy.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LessonController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponceModel> CreateLesson(CreateLessonCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpGet]
        public async Task<List<LessonModel>> GetAllLessons()
        {
            return await _mediator.Send(new GetAllLessonCommandQuery ());
        }
        [HttpPut]
        public async Task<ResponceModel> UpdateLesson(UpdateLessonCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<ResponceModel> DeleteLesson(DeleteLessonCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
