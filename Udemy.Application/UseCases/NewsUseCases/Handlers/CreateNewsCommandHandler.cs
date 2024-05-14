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
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.NewsUseCases.Handlers
{
    public class CreateNewsCommandHandler:IRequestHandler<CreateNewsCommand,ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        public CreateNewsCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponceModel> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            var newses = new NewsModel()
            {
                Title = request.Title,
                NewsPhotoPath=request.PhotoPath,
                About=request.About,
                popularTopic=_appDbContext.popularTopics.FirstOrDefaultAsync(x=>x.Id == request.PopularTopicId).Result
            };
            await _appDbContext.news.AddAsync(newses);
            await _appDbContext.SaveChangesAsync();
            return new ResponceModel()
            {
                Message="News Created"
            };
        }
    }
}
