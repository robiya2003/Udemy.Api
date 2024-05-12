using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.AutherUseCases.Queries
{
    public class GetAllAutherCommandQuery:IRequest<List<AutherModel>>
    {
    }
}
