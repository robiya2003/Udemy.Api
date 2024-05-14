using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Domain.DTOS
{
    public class NewsUDTO
    {
        public int PopularTopicId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        
        public string About { get; set; }
        public IFormFile imagefile { get; set; }
    }
}
