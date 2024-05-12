using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Application.UseCases.PopularTopicUseCases.Commands
{
    public class DeletePopularTopicCommand:IRequest<ResponceModel>
    {
        public int Id { get; set; }
    }
}
