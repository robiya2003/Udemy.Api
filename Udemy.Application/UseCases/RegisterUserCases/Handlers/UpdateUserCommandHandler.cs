using AutoMapper;
using AutoService.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.RegisterUserCases.Commands;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.RegisterUserCases.Handlers
{
    public class UpdateUserCommandHandler:IRequestHandler<UpdateUserCommand,UserModel>
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public UpdateUserCommandHandler(IAppDbContext appDbContext,IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<UserModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user= await _appDbContext.users.FirstOrDefaultAsync(x => x.Id == request.Id);
            user.FirstName=request.FirstName;
            user.LastName=request.LastName;
            user.Email=request.Email;
            user.Password=request.Password;
            





            _appDbContext.users.Update(user);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return await _appDbContext.users.FirstOrDefaultAsync(x=>x.Id==request.Id);
        }
    }
}
