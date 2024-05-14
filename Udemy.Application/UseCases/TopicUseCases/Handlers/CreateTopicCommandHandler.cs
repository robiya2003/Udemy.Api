using AutoMapper;
using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.TopicUseCases.Commands;
using Udemy.Domain.MODELS;

namespace Udemy.Application.UseCases.TopicUseCases.Handlers
{
    public class CreateTopicCommandHandler : IRequestHandler<CreateTopicCommand, ResponceModel>
    {
        private readonly IMapper _mapper;
        private readonly IAppDbContext _appDbContext;
        public CreateTopicCommandHandler(
            IMapper mapper,IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<ResponceModel> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
        {
            var top = new TopicModel() { 

                TopicPhotoPath = request.TopicPhotoPath,
            Name=request.Name,
            Description=request.Description,
            Category=await _appDbContext.categories.FirstOrDefaultAsync(x=>x.Id==request.CategoryId)};
            
            _appDbContext.topic.Add(top);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return new ResponceModel()
            {
                Message = "Created topic",
            };
        }
    }
}
