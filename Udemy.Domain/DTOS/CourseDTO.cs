using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Domain.DTOS
{
    public class CourseDTO
    {
        public string name { get; set; }
        public string description { get; set; }
        
        public int AutherId { get; set; }
        public int PopularTopicId { get; set; }
        public IFormFile imagefile { get; set; }
    }
}
