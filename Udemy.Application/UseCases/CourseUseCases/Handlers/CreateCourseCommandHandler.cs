using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.CategoryUseCases.Commands;
using Udemy.Application.UseCases.CourseUseCases.Commands;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.CourseUseCases.Handlers
{
    public class CreateCourseCommandHandler:IRequestHandler<CreateCourseCommand,ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        public CreateCourseCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponceModel> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            CourseModel course=new CourseModel()
            {
                name=request.name,
                description=request.description,
                CoursePhotoPath=request.PhotoPath,
                auther=_appDbContext.authers.FirstOrDefaultAsync(x=>x.id==request.AutherId).Result,
                popularTopic=_appDbContext.popularTopics.FirstOrDefaultAsync(x=>x.Id==request.PopularTopicId).Result
                
            };
            _appDbContext.courses.Add(course);
            _appDbContext.SaveChangesAsync();
            return new ResponceModel()
            {
                Message="Course yaratildi"
            };
        }
    }
}
