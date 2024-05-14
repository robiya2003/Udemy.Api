using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Domain.DTOS
{
    public class PopularTopicDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TopicId { get; set; }
        public IFormFile imagefile { get; set; }
    }
}
