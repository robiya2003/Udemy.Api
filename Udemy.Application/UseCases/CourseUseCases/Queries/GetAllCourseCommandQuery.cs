using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.CourseUseCases.Queries
{
    public class GetAllCourseCommandQuery:IRequest<List<CourseModel>>
    {
    }
}
