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
    public class DeletePopularTopicCommandHandler : IRequestHandler<DeletePopularTopicCommand, ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        public DeletePopularTopicCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ResponceModel> Handle(DeletePopularTopicCommand request, CancellationToken cancellationToken)
        {
            var poptop=_appDbContext.popularTopics.FirstOrDefaultAsync(x=>x.Id == request.Id).Result;
            _appDbContext.popularTopics.Remove(poptop); 
            _appDbContext.SaveChangesAsync();
            return new ResponceModel()
            {
                Message="Popular Topic ochirildi"
            };
        }
    }
}
