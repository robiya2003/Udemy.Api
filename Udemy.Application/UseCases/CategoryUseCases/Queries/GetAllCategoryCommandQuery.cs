using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.CategoryUseCases.Queries
{
   public class GetAllCategoryCommandQuery:IRequest<List<CategoryModel>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryPhotoPath { get; set; }
        public virtual List<TopicModel> Topics { get; set; }
    }
}
