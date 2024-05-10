using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Domain.MODELS;

namespace AutoService.Application.Abstractions
{
    public interface IAppDbContext
    {
        DbSet<UserModel> users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default!);
    }
}
