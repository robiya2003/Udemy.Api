using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.UseCases.LessonUseCases.Commands;
using Udemy.Application.UseCases.LessonUseCases.Queries;
using Udemy.Domain.DTOS;
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
        public async Task<ResponceModel> CreateLesson(LessonDTO lesson)
        {
            var fileName = Path.GetFileName(lesson.imagefile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\lessons", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await lesson.imagefile.CopyToAsync(fileStream);
            }
            CreateLessonCommand command= new CreateLessonCommand()
            {
                CourseId=lesson.CourseId,
                name=lesson.name,
                description=lesson.description,
                VideoPath=lesson.VideoPath,
                PhotoPath=filePath,
            };
            return await _mediator.Send(command);
        }
        [HttpGet]
        public async Task<List<LessonModel>> GetAllLessons()
        {
            return await _mediator.Send(new GetAllLessonCommandQuery ());
        }
        [HttpPut]
        public async Task<ResponceModel> UpdateLesson(LessonUDTO lesson)
        {
            var fileName = Path.GetFileName(lesson.imagefile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\lessons", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await lesson.imagefile.CopyToAsync(fileStream);
            }
            UpdateLessonCommand command = new UpdateLessonCommand()
            {
                CourseId = lesson.CourseId,
                name = lesson.name,
                description = lesson.description,
                VideoPath = lesson.VideoPath,
                PhotoPath = filePath,
                id=lesson.id
            };
            return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<ResponceModel> DeleteLesson(DeleteLessonCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
