using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Domain.MODELS
{
    public class TopicModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TopicPhotoPath { get; set; }
        public virtual CategoryModel Category { get; set; }
        public virtual List<PopularTopicModel> PopularTopics { get; set; }
    }
}
