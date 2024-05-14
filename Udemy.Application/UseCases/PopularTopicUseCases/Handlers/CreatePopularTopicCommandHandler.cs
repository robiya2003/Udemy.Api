using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.PopularTopicUseCases.Commands;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.PopularTopicUseCases.Handlers
{
    public class CreatePopularTopicCommandHandler : IRequestHandler<CreatePopularTopicCommand, ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        public CreatePopularTopicCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ResponceModel> Handle(CreatePopularTopicCommand request, CancellationToken cancellationToken)
        {
            var poptop = new PopularTopicModel()
            {
                Name = request.Name,
                Description = request.Description,
                Topic =  _appDbContext.topic.FirstOrDefaultAsync(x=>x.Id==request.TopicId).Result,
                PopularTopicPhotoPath=request.PopularTopicPhotoPath
            };
            _appDbContext.popularTopics.Add(poptop);
            _appDbContext.SaveChangesAsync();
            return new ResponceModel()
            {
                Message="Popular Topic Created"
            };
        }
    }
}
