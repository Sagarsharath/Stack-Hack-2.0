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
        public DbSet<Role> Role { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendance { get; set; }
        public DbSet<EmployeeFinances> Finances { get; set; }
        public DbSet<FinanceTypes> FinanceTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>()//   .HasKey(user => user.UserId)
                .HasMany<EmployeeFinances>(e => e.EmployeeFinances);
                
            modelBuilder.Entity<UserInfo>().HasOne(User_Info.);
        }

    }
}
