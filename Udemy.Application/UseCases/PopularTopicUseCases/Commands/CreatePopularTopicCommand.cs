using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Application.UseCases.PopularTopicUseCases.Commands
{
    public class CreatePopularTopicCommand:IRequest<ResponceModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TopicId {  get; set; }
        public string PopularTopicPhotoPath { get; set; }
    }
}
