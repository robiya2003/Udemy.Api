using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Domain.MODELS
{
    public class LessonModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string PhotoPath { get; set; }
        public string VideoPath { get; set; }
        public virtual CourseModel Courses { get; set; }
    }
}
