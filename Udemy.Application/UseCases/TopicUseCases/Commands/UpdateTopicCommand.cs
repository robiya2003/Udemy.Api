using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Application.UseCases.TopicUseCases.Commands
{
    public class UpdateTopicCommand:IRequest<ResponceModel>
    {
        public int Id { get; set; } 
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TopicPhotoPath { get; set; }
    }
}
