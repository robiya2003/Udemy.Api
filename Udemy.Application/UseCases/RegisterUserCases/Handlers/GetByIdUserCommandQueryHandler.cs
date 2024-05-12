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
    public class GetByIdUserCommandQueryHandler : IRequestHandler<GetByIdUserCommandQuery, UserModel>
    {
        private readonly IAppDbContext _appDbContext;
        public GetByIdUserCommandQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<UserModel> Handle(GetByIdUserCommandQuery request, CancellationToken cancellationToken)
        {
            return  _appDbContext.users.FirstOrDefaultAsync(x=>x.Id == request.Id).Result;
        }
    }
}
