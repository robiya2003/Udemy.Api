using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Application.UseCases.CourseUseCases.Commands
{
    public class UpdateCourseCommand:IRequest<ResponceModel>
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string PhotoPath { get; set; }
        public int AutherId { get; set; }
        public int PopularTopicId { get; set; }
    }
}
