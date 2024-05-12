using AutoService.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.LessonUseCases.Queries;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.LessonUseCases.Handlers
{
    public class GetAllLessonCommandHandler:IRequestHandler<GetAllLessonCommandQuery,List<LessonModel>>
    {
        private readonly IAppDbContext _appDbContext;
        public GetAllLessonCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<LessonModel>> Handle(GetAllLessonCommandQuery request, CancellationToken cancellationToken)
        {
            return _appDbContext.lessons.ToListAsync().Result;
        }
    }
}
