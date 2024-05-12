
using AutoMapper;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.UseCases.CourseUseCases.Commands;
using Udemy.Application.UseCases.CourseUseCases.Queries;
using Udemy.Domain.MODELS;

namespace Udemy.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponceModel> CreateCourse(CreateCourseCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpGet]
        public async Task<List<CourseModel>> GetAllCouses()
        {
            return await _mediator.Send(new GetAllCourseCommandQuery()); 
        }
        [HttpPut]
        public async Task<ResponceModel> UpdateCourse(UpdateCourseCommand command)
        {
           return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<ResponceModel> DeleteCourse(DeleteCourseCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
