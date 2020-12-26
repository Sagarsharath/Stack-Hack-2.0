using HRM.Rest.Services.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Rest.Services.DAL.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext() : base()
        {
            //OnConfiguring()
        }


        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<UserInfo> User_Info { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>().HasKey(user => user.UserId);
        }

    }
}
