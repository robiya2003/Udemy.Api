using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Application.UseCases.RegisterUserCases.Commands;
using Udemy.Domain.DTOS;
using Udemy.Domain.MODELS;

namespace Udemy.Application.Mappers
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserModel,CreateUserCommand>().ReverseMap();
            CreateMap<UserModel,UpdateUserCommand>().ReverseMap();
        }
    }
}
