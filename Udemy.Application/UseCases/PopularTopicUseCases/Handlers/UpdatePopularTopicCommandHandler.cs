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

namespace Udemy.Application.UseCases.PopularTopicUseCases.Handlers
{
    public class UpdatePopularTopicCommandHandler : IRequestHandler<UpdatePopularTopicCommand, ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        public UpdatePopularTopicCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ResponceModel> Handle(UpdatePopularTopicCommand request, CancellationToken cancellationToken)
        {
            var poptop=_appDbContext.popularTopics.FirstOrDefaultAsync(x=> x.Id == request.Id).Result;
            poptop.Name= request.Name;
            poptop.Description= request.Description;
            poptop.Topic = _appDbContext.topic.FirstOrDefaultAsync(x => x.Id == request.TopicId).Result;
            poptop.PopularTopicPhotoPath = request.PopularTopicPhotoPath;
            _appDbContext.popularTopics.Update(poptop);
            _appDbContext.SaveChangesAsync();
            return new ResponceModel()
            {
                Message="Update boldi"
            };
        }
    }
}
