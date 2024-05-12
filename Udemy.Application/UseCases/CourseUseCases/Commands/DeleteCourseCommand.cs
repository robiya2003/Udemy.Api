using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Application.UseCases.CourseUseCases.Commands
{
    public class DeleteCourseCommand:IRequest<ResponceModel>
    {
        public int Id { get; set; } 
    }
}
