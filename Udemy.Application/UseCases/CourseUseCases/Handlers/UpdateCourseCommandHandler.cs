using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.CourseUseCases.Commands;

namespace Udemy.Application.UseCases.CourseUseCases.Handlers
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        public UpdateCourseCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ResponceModel> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = _appDbContext.courses.FirstOrDefaultAsync(x => x.id == request.Id).Result;
            course.name=request.name; 
            course.description=request.description;
            course.CoursePhotoPath = request.PhotoPath;
            course.auther = _appDbContext.authers.FirstOrDefaultAsync(x => x.id == request.Id).Result;
            course.popularTopic = _appDbContext.popularTopics.FirstOrDefaultAsync(x => x.Id == request.Id).Result;
            _appDbContext.courses.Update(course);
            _appDbContext.SaveChangesAsync();
            return new ResponceModel()
            {
                Message="Course uptaded"
            };
        }
    }
}
