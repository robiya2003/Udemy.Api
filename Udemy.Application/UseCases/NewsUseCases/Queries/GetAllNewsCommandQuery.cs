using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.NewsUseCases.Queries
{
    public class GetAllNewsCommandQuery:IRequest<List<NewsModel>>
    {
    }
}
