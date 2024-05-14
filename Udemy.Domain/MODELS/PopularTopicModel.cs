using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Domain.MODELS
{
    public class PopularTopicModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PopularTopicPhotoPath { get; set; }
        public virtual TopicModel Topic { get; set; }
        public virtual List<CourseModel> courses { get; set; }
        public virtual List<NewsModel> news { get; set; }
    }
}
