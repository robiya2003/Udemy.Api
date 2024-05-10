using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.RegisterUserCases.Commands;

namespace Udemy.Application.UseCases.RegisterUserCases.Handlers
{
    public class DeleteUserCommandQueryHandler : IRequestHandler<DeleteUserCommand, ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        public DeleteUserCommandQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ResponceModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _appDbContext.users.FirstOrDefaultAsync(x => x.Id == request.Id).Result;
            _appDbContext.users.Remove(user);
           await _appDbContext.SaveChangesAsync(cancellationToken);
            return new ResponceModel()
            {
                Message=$"{request.Id} dagi user ochirildi"
            };
        }
    }
}
