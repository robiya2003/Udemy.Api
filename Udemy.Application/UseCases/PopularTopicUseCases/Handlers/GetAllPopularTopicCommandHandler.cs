using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.PopularTopicUseCases.Queries;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.PopularTopicUseCases.Handlers
{
    public class GetAllPopularTopicCommandHandler:IRequestHandler<GetAllPopularTopicCommandQuery,List<PopularTopicModel>>
    {
        private readonly IAppDbContext _appDbContext;
        public GetAllPopularTopicCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<PopularTopicModel>> Handle(GetAllPopularTopicCommandQuery request, CancellationToken cancellationToken)
        {
            var tops= await _appDbContext.popularTopics.ToListAsync();
            return tops;
        }
    }
}
