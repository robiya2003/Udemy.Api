using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Domain.MODELS
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public virtual CourseModel Course { get; set; }
    }
}
