using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.AutherUseCases.Commands;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.AutherUseCases.Handlers
{
    public class UpdateAutherCommandHandler : IRequestHandler<UpdateAutherCommand, ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        public UpdateAutherCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ResponceModel> Handle(UpdateAutherCommand request, CancellationToken cancellationToken)
        {
            var auther=_appDbContext.authers.FirstOrDefaultAsync(x=>x.id==request.id).Result;
            auther.Exprince=request.Exprince;
            auther.About=request.About;
            auther.FullName=request.FullName;
            auther.Gmail=request.Gmail;
            auther.AutherPhotoPath=request.AutherPhotoPath;
            _appDbContext.authers.Update(auther);
            _appDbContext.SaveChangesAsync();
            return new ResponceModel()
            {
                Message="Autherupdated"
            };
        }
    }
}
