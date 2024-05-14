using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.NewsUseCases.Commands;

namespace Udemy.Application.UseCases.NewsUseCases.Handlers
{
    public class UpdateNewsCommandHandler:IRequestHandler<UpdateNewsCommand,ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        public UpdateNewsCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponceModel> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            var newes=_appDbContext.news.FirstOrDefaultAsync(x=>x.Id == request.Id).Result;
            newes.Title = request.Title;
            newes.About = request.About;
            newes.NewsPhotoPath = request.PhotoPath;
            newes.popularTopic = _appDbContext.popularTopics.FirstOrDefaultAsync(x => x.Id == request.PopularTopicId).Result;
            _appDbContext.news.Update(newes);
            _appDbContext.SaveChangesAsync();

            return new ResponceModel()
            {
                Message="News update"
            };
        }
    }
}
