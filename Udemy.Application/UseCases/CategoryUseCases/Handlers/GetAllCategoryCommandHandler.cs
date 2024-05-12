using AutoService.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.CategoryUseCases.Queries;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.CategoryUseCases.Handlers
{
    public class GetAllCategoryCommandHandler:IRequestHandler<GetAllCategoryCommandQuery,List<CategoryModel>>
    {
        private readonly IAppDbContext _appDbContext;
        public GetAllCategoryCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<CategoryModel>> Handle(GetAllCategoryCommandQuery request, CancellationToken cancellationToken)
        {
            var categorylist= await _appDbContext.categories.ToListAsync();
            return categorylist;
        }
    }
}
