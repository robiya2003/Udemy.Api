using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.LessonUseCases.Commands;

namespace Udemy.Application.UseCases.LessonUseCases.Handlers
{
  public class DeleteLessonCommandHandler:IRequestHandler<DeleteLessonCommand,ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        public DeleteLessonCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponceModel> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = _appDbContext.lessons.FirstOrDefaultAsync(x => x.id == request.Id).Result;
            _appDbContext.lessons.Remove(lesson);
            _appDbContext.SaveChangesAsync();
            return new ResponceModel()
            {
                Message="Lesson delete"
            };

        }
    }
}
