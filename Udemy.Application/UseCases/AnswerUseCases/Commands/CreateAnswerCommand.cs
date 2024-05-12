using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Application.UseCases.AnswerUseCases.Commands
{
    public class CreateAnswerCommand:IRequest<ResponceModel>
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
