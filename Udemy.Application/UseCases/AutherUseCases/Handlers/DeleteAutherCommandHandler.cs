using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.AutherUseCases.Commands;

namespace Udemy.Application.UseCases.AutherUseCases.Handlers
{
    public class DeleteAutherCommandHandler : IRequestHandler<DeleteAutherCommand, ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        public DeleteAutherCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ResponceModel> Handle(DeleteAutherCommand request, CancellationToken cancellationToken)
        {
            var auther = _appDbContext.authers.FirstOrDefaultAsync(x => x.id == request.Id).Result;
            _appDbContext.authers.Remove(auther);
            _appDbContext.SaveChangesAsync();
            return new ResponceModel() 
            {
                Message="Delete auther"
            };
        }
    }
}
