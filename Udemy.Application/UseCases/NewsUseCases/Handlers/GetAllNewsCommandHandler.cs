using AutoService.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.NewsUseCases.Queries;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.NewsUseCases.Handlers
{
    public class GetAllNewsCommandHandler : IRequestHandler<GetAllNewsCommandQuery, List<NewsModel>>
    {
        private readonly IAppDbContext _appDbContext;
        public GetAllNewsCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<NewsModel>> Handle(GetAllNewsCommandQuery request, CancellationToken cancellationToken)
        {
            return await _appDbContext.news.ToListAsync();
        }
    }
}
