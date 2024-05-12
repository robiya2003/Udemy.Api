using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.AnswerUseCases.Commands;

namespace Udemy.Application.UseCases.AnswerUseCases.Handlers
{
    public class DeleteAnswerCommandHandler:IRequestHandler<DeleteAnswerCommand,ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        public DeleteAnswerCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponceModel> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
        {
           var answer=_appDbContext.answers.FirstOrDefaultAsync(x=>x.Id == request.Id).Result;
            _appDbContext.answers.Remove(answer);
            _appDbContext.SaveChangesAsync();
            return new ResponceModel()
            {
                Message="Answer delete"
            };

        }
    }
}
