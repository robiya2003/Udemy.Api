using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Domain.MODELS
{
    public class NewsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PhotoPath { get; set; }
        public string About { get; set; }
       public virtual PopularTopicModel popularTopic { get; set; }
    }
}
