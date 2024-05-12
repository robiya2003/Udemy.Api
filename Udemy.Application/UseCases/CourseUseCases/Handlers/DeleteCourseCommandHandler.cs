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
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        public DeleteCourseCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ResponceModel> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = _appDbContext.courses.FirstOrDefaultAsync(x => x.id == request.Id).Result;
            _appDbContext.courses.Remove(course);
            _appDbContext.SaveChangesAsync();
            return new ResponceModel()
            {
                Message = "Course Delete"
            };
        }
    }
}
