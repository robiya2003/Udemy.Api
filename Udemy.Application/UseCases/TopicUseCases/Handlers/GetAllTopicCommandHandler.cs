using AutoService.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.TopicUseCases.Queries;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.TopicUseCases.Handlers
{
    public class GetAllTopicCommandHandler : IRequestHandler<GetAllTopicCommandQuery, List<TopicModel>>
    {
        private readonly IAppDbContext _appDbContext;
        public GetAllTopicCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<TopicModel>> Handle(GetAllTopicCommandQuery request, CancellationToken cancellationToken)
        {
            return await _appDbContext.topic.ToListAsync(cancellationToken);
        }
    }
}
