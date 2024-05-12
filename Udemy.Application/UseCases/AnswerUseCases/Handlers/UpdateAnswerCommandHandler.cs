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
    public class UpdateAnswerCommandHandler:IRequestHandler<UpdateAnswerCommand,ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        public UpdateAnswerCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async  Task<ResponceModel> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = _appDbContext.answers.FirstOrDefaultAsync(x=>x.Id==request.Id).Result;
            answer.Title = request.Title;
            answer.Body = request.Body;
            answer.Course = _appDbContext.courses.FirstOrDefaultAsync(x => x.id == request.CourseId).Result;
            _appDbContext.answers.Update(answer);
            _appDbContext.SaveChangesAsync();
            return new ResponceModel()
            {
                Message="Answer update"
            };

        }
    }
}
