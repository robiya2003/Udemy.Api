using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Domain.MODELS
{
    public class AutherModel
    {
        public int id {  get; set; }
        public string FullName { get; set; }
        public string Exprince {  get; set; }
        public string About { get; set; }
        public string Gmail { get; set; }
        public string AutherPhotoPath { get; set; }
        public virtual List<CourseModel> Courses { get; set; }
    }
}
