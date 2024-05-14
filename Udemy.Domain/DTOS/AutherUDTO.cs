using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Domain.DTOS
{
    public class AutherUDTO
    {
        public string FullName { get; set; }
        public string Exprince { get; set; }
        public string About { get; set; }
        public string Gmail { get; set; }

        public IFormFile imagefile { get; set; }
    }
}
