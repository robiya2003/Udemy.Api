using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Domain.MODELS
{
    public class CourseModel
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string CoursePhotoPath { get; set; }
        public virtual AutherModel auther { get; set; }
        public virtual PopularTopicModel popularTopic { get; set; }

        public virtual List<UserModel> users { get; set; }
        public virtual List<LessonModel> lessons { get; set; }
        public virtual List<AnswerModel> answers { get; set; }
    }
}
