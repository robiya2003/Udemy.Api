using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Application.UseCases.CategoryUseCases.Commands
{
    public class CreateCategoryCommand:IRequest<ResponceModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryPhotoPath { get; set; }
    }
}
