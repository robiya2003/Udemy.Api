using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Domain.DTOS
{
    public class LessonDTO
    {
        public int CourseId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        
        public string VideoPath { get; set; }
        public IFormFile imagefile { get; set; }
    }
}
