using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.AutherUseCases.Commands;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.AutherUseCases.Handlers
{
    public class CreateAutherCommandHandler : IRequestHandler<CreateAutherCommand, ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        public CreateAutherCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ResponceModel> Handle(CreateAutherCommand request, CancellationToken cancellationToken)
        {
            var auther = new AutherModel
            {
                FullName = request.FullName,
                Exprince = request.Exprince,
                About = request.About,
                Gmail = request.Gmail,
                AutherPhotoPath = request.AutherPhotoPath,
            };
            _appDbContext.authers.Add(auther);
            _appDbContext.SaveChangesAsync();
            return new ResponceModel()
            {
                Message="Create Auther"
            };
        }
    }
}
