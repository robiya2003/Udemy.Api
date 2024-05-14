using AutoMapper;
using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.AdminUseCases.Commands;
using Udemy.Application.UseCases.CategoryUseCases.Commands;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.CategoryUseCases.Handlers
{
    public class CreateCategoryCommandHandler:IRequestHandler<CreateCategoryCommand,ResponceModel>
    {
        private readonly IMapper _mapper;
        private readonly IAppDbContext _appDbContext;
        public CreateCategoryCommandHandler(
            IMapper mapper,IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<ResponceModel> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var cate=new CategoryModel
            {
                CategoryPhotoPath = request.CategoryPhotoPath,
                Name = request.Name,
                Description = request.Description,  
            };
           await _appDbContext.categories.AddAsync(cate);
            _appDbContext.SaveChangesAsync();
            return new ResponceModel()
            {
                Message="Caategry created",
                StatusCode=201,
                IsSuccess=true,
            };
        }
    }
}
