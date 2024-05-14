using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.TopicUseCases.Commands;

namespace Udemy.Application.UseCases.TopicUseCases.Handlers
{
    public class UpdateTopicCommandHandler : IRequestHandler<UpdateTopicCommand, ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        public UpdateTopicCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public  async Task<ResponceModel> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
        {
            var top=_appDbContext.topic.FirstOrDefaultAsync(x=>x.Id==request.Id).Result;
            top.Name = request.Name;
            top.Description = request.Description;
            top.Category=_appDbContext.categories.FirstOrDefaultAsync(x=>x.Id == request.Id).Result;
            top.TopicPhotoPath = request.TopicPhotoPath;
            _appDbContext.topic.Update(top);
            _appDbContext.SaveChangesAsync();
            return new ResponceModel()
            {
                Message="Topic uptaded"
            };

        }
    }
}
