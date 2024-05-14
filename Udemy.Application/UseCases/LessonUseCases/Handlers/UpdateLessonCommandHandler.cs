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
    public class UpdateLessonCommandHandler:IRequestHandler<UpdateLessonCommand,ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        public UpdateLessonCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponceModel> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = _appDbContext.lessons.FirstOrDefaultAsync(x => x.id == request.id).Result;
            lesson.name = request.name; 
            lesson.description = request.description;
            lesson.LessonPhotoPath = request.PhotoPath;
            lesson.VideoPath = request.VideoPath;
            lesson.Courses = _appDbContext.courses.FirstOrDefaultAsync(x => x.id == request.CourseId).Result;
            _appDbContext.lessons.Update(lesson);
            _appDbContext.SaveChangesAsync();
            return new ResponceModel()
            {
                Message="Lesson update"
            };
        }
    }
}
