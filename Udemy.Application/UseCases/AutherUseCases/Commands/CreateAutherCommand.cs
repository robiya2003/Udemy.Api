using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Application.UseCases.AutherUseCases.Commands
{
    public class CreateAutherCommand:IRequest<ResponceModel>
    {
        
        public string FullName { get; set; }
        public string Exprince { get; set; }
        public string About { get; set; }
        public string Gmail { get; set; }
        public string AutherPhotoPath { get; set; }
    }
}
