using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Application.UseCases.NewsUseCases.Commands
{
    public class CreateNewsCommand:IRequest<ResponceModel>
    {
        public int PopularTopicId { get; set; }
        public string Title { get; set; }
        public string PhotoPath { get; set; }
        public string About { get; set; }
    }
}
