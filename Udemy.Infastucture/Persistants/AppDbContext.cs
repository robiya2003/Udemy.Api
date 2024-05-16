
using AutoService.Application.Abstractions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Domain.MODELS;

namespace Udemy.Infastucture.Persistants
{
    public class AppDbContext : IdentityDbContext<UserModel>,IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<AnswerModel> answers { get ; set ; }
        public DbSet<AutherModel> authers { get ; set; }
        public DbSet<CategoryModel> categories { get ; set ; }
        public DbSet<CourseModel> courses { get ; set ; }
        public DbSet<LessonModel> lessons { get ; set; }
        public DbSet<NewsModel> news { get; set ; }
        public DbSet<PopularTopicModel> popularTopics { get ; set; }
        public DbSet<TopicModel> topic { get ; set ; }
    }
}
