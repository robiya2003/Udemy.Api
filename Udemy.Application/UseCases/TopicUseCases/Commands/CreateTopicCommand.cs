﻿using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Application.UseCases.TopicUseCases.Commands
{
    public class CreateTopicCommand:IRequest<ResponceModel>
    {
        public int CategoryId {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
