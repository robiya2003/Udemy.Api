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
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.LessonUseCases.Handlers
{
    public class CreateLessonCommandHandler:IRequestHandler<CreateLessonCommand,ResponceModel>
    {
      private readonly IAppDbContext _appDbContext;
     
        public CreateLessonCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponceModel> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
           LessonModel lessonModel = new LessonModel()
           {
               Courses=_appDbContext.courses.FirstOrDefaultAsync(x=>x.id == request.CourseId).Result,
               name=request.name,
               description=request.description,
               LessonPhotoPath=request.PhotoPath,
               VideoPath=request.VideoPath,
           };
            _appDbContext.lessons.Add(lessonModel);
            _appDbContext.SaveChangesAsync();
            return new ResponceModel() 
            {
                Message="Lesson created"
            };

        }
    }
}
