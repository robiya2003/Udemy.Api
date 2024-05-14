using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Udemy.Domain.MODELS
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryPhotoPath { get; set; }
        public virtual List<TopicModel> Topics { get; set; }
    
    }
}
