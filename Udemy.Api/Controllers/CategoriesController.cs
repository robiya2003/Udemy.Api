using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.UseCases.CategoryUseCases.Commands;
using Udemy.Application.UseCases.CategoryUseCases.Queries;
using Udemy.Domain.MODELS;

namespace Udemy.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponceModel> CreateCategory(CreateCategoryCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpGet]
        public async Task<List<CategoryModel>> GetAllCategory()
        {
            return await _mediator.Send(new GetAllCategoryCommandQuery ());
        }
        [HttpPut]
        public async Task<ResponceModel> UpdateCategory(UpdateCategoryCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<ResponceModel> DeleteCateory(DeleteCategoryCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
