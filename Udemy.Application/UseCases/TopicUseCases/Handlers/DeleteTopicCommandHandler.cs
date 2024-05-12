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
    public class DeleteTopicCommandHandler : IRequestHandler<DeleteTopicCommand, ResponceModel>
    {

        private readonly IAppDbContext _appDbContext;
        public DeleteTopicCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ResponceModel> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
        {
           var top=_appDbContext.topic.FirstOrDefaultAsync(x=>x.Id == request.Id).Result;
            _appDbContext.topic.Remove(top);
            _appDbContext.SaveChangesAsync();
            return new ResponceModel()
            {
                Message = "Topic o'chirildi"
            };
        }
    }
}
