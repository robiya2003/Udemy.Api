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
    public class DeleteNewsCommandHandler:IRequestHandler<DeleteNewsCommand,ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        public DeleteNewsCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponceModel> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
           NewsModel newes=_appDbContext.news.FirstOrDefaultAsync(x=>x.Id==request.Id).Result;
            _appDbContext.news.Remove(newes);
            _appDbContext.SaveChangesAsync();
            return new ResponceModel()
            {
                Message="Delete news"
            };
        }
    }
}
