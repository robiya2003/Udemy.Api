using AutoMapper;
using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.RegisterUserCases.Commands;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.RegisterUserCases.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,ResponceModel>
    {
        private readonly IMapper _mapper;
        private readonly IAppDbContext _appDbContext;
        public CreateUserCommandHandler(IAppDbContext appDbContext,
            IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

       

        

        public async Task<ResponceModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserModel>(request);
            await _appDbContext.users.AddAsync(user);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return new ResponceModel
            {
                Message = "User Created",
                StatusCode = 0,
                IsSuccess = true,
            };
        }
    }
}
