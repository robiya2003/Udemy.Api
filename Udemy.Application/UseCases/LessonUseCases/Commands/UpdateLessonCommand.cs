using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.LessonUseCases.Commands
{
    public class UpdateLessonCommand:IRequest<ResponceModel>
    {
        public int id { get; set; }
        public int CourseId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string PhotoPath { get; set; }
        public string VideoPath { get; set; }
        
    }
}
