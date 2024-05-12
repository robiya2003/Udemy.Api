﻿using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Application.UseCases.RegisterUserCases.Commands
{
    public class CreateUserCommand:IRequest<ResponceModel> 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset ModifiedDate { get; set; }
        public DateTimeOffset DeletedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
