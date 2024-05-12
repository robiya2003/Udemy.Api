using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.CategoryUseCases.Commands;

namespace Udemy.Application.UseCases.CategoryUseCases.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        public DeleteCategoryCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ResponceModel> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
           var category=_appDbContext.categories.FirstOrDefaultAsync(x => x.Id == request.Id).Result;
            _appDbContext.categories.Remove(category);
            _appDbContext.SaveChangesAsync();
            return new ResponceModel()
            {
                Message="Category o'chirildi"
            };
        }
    }
}
