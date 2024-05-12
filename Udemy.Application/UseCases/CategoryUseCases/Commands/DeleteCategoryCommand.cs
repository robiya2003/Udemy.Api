using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Application.UseCases.CategoryUseCases.Commands
{
    public class DeleteCategoryCommand:IRequest<ResponceModel>
    {
        public int Id { get; set; }
    }
}
