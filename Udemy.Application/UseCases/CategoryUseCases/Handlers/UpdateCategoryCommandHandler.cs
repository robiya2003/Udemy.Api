using AutoMapper;
using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.AdminUseCases.Commands;
using Udemy.Application.UseCases.CategoryUseCases.Commands;

namespace Udemy.Application.UseCases.CategoryUseCases.Handlers
{
    public class UpdateCategoryCommandHandler:IRequestHandler<UpdateCategoryCommand,ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        
        public UpdateCategoryCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponceModel> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category=_appDbContext.categories.FirstOrDefaultAsync(x=> x.Id == request.Id).Result;  
            category.Name = request.Name;
            category.Description = request.Description;
            category.CategoryPhotoPath = request.CategoryPhotoPath;
            _appDbContext.categories.Update(category);
            _appDbContext.SaveChangesAsync();
            return new ResponceModel() {
            Message="Category update"};
        }
    }
}
