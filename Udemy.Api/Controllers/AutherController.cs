using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.UseCases.AutherUseCases.Commands;
using Udemy.Application.UseCases.AutherUseCases.Queries;
using Udemy.Domain.DTOS;
using Udemy.Domain.MODELS;

namespace Udemy.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AutherController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AutherController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponceModel> CreateAuther(AutherDTO auther)
        {
            var fileName = Path.GetFileName(auther.imagefile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\authers", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await auther.imagefile.CopyToAsync(fileStream);
            }
            CreateAutherCommand command = new CreateAutherCommand()
            {
                FullName = auther.FullName,
                Gmail = auther.Gmail,
                About = auther.About,
                Exprince = auther.Exprince,
                AutherPhotoPath=filePath
            };
            return await _mediator.Send(command);
        }
        [HttpGet]
        public async Task<List<AutherModel>> GetAllAuther()
        {
            return await _mediator.Send(new GetAllAutherCommandQuery());
        }
        [HttpPut]
        public async Task<ResponceModel> UpdateAuther(AutherUDTO auther)
        {
            var fileName = Path.GetFileName(auther.imagefile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\authers", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await auther.imagefile.CopyToAsync(fileStream);
            }
            UpdateAutherCommand command = new UpdateAutherCommand()
            {
                FullName = auther.FullName,
                Exprince = auther.Exprince,
                About = auther.About,
                Gmail = auther.Gmail,
                AutherPhotoPath = filePath
            };
            return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<ResponceModel> DeleteAuther(DeleteAutherCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
