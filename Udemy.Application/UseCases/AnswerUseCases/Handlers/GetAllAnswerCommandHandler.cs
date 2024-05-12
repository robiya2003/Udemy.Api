using AutoService.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.AnswerUseCases.Queries;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.AnswerUseCases.Handlers
{
    public class GetAllAnswerCommandHandler:IRequestHandler<GetAllAnswerCommandQuery,List<AnswerModel>>
    {
        private readonly IAppDbContext _appDbContext;
        public GetAllAnswerCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<AnswerModel>> Handle(GetAllAnswerCommandQuery request, CancellationToken cancellationToken)
        {
            return await _appDbContext.answers.ToListAsync();
        }
    }
}
