using AutoService.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.AutherUseCases.Queries;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.AutherUseCases.Handlers
{
    public class GetAllAutherCommandHandler : IRequestHandler<GetAllAutherCommandQuery, List<AutherModel>>
    {
        private readonly IAppDbContext _appDbContext;
        public GetAllAutherCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<AutherModel>> Handle(GetAllAutherCommandQuery request, CancellationToken cancellationToken)
        {
            return await _appDbContext.authers.ToListAsync();
        }
    }
}
