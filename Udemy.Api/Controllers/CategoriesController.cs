using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Application.UseCases.CategoryUseCases.Commands;
using Udemy.Application.UseCases.CategoryUseCases.Queries;
using Udemy.Domain.DTOS;
using Udemy.Domain.MODELS;

namespace Udemy.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
   
        public CategoriesController(IMediator mediator, ILogger<CategoriesController> logger)
        {
            _mediator = mediator;
            
        }
        [HttpPost]
        public async Task<ResponceModel> CreateCategory(CategoryDTO categoryDTO)
        {
            var fileName = Path.GetFileName(categoryDTO.imagefile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\categories", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await categoryDTO.imagefile.CopyToAsync(fileStream);
            }
            CreateCategoryCommand command = new CreateCategoryCommand()
            {
                Name = categoryDTO.Name,
                Description = categoryDTO.Description,
                CategoryPhotoPath=filePath
            };
            return await _mediator.Send(command);
        }
        [HttpGet]
        public async Task<List<CategoryModel>> GetAllCategory()
        {
            
            return await _mediator.Send(new GetAllCategoryCommandQuery ());
        }
        [HttpPut]
        public async Task<ResponceModel> UpdateCategory(CategoryUDTO category)
        {
            var fileName = Path.GetFileName(category.imagefile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\categories", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await category.imagefile.CopyToAsync(fileStream);
            }
            UpdateCategoryCommand command = new UpdateCategoryCommand
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                CategoryPhotoPath=filePath
            };
            return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<ResponceModel> DeleteCateory(DeleteCategoryCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
