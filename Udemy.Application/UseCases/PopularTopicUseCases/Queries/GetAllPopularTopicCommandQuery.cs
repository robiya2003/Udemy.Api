using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.PopularTopicUseCases.Queries
{
    public class GetAllPopularTopicCommandQuery:IRequest<List<PopularTopicModel>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual TopicModel Topic { get; set; }
        public virtual List<CourseModel> courses { get; set; }
        public virtual List<NewsModel> news { get; set; }
    }
}
