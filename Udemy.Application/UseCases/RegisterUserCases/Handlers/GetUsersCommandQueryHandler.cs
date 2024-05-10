using AutoService.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.RegisterUserCases.Queries;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.RegisterUserCases.Handlers
{
    public class GetUsersCommandQueryHandler : IRequestHandler<GetUsersCommandQuery, List<UserModel>>
    {
        private readonly IAppDbContext _appDbContext;
        public GetUsersCommandQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Task<List<UserModel>> Handle(GetUsersCommandQuery request, CancellationToken cancellationToken)
        {
            var users=_appDbContext.users.ToListAsync();
            return users;
        }
    }
}
