using HRM.Rest.Services.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRM.Rest.Services.Util;

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
            modelBuilder.Entity<UserInfo>().HasKey(user => user.UserId);
                //.HasMany<EmployeeFinances>(e => e.EmployeeFinances);
                

            modelBuilder.Entity<Role>().HasKey(r => r.RoleId);
            modelBuilder.Entity<Department>().HasKey(d => d.DepartmentId);
            modelBuilder.Entity<Address>().HasKey(addr => addr.Id);
            modelBuilder.Entity<EmployeeAttendance>().HasKey(att => att.Id);
            modelBuilder.Entity<EmployeeFinances>().HasKey(fin => fin.Id);
            modelBuilder.Entity<FinanceTypes>().HasKey(ft => ft.FinanceTypeId);


            // seed master data
            modelBuilder.Entity<Role>().HasData(GetRoles());
            modelBuilder.Entity<Department>().HasData(GetDepartments());
            modelBuilder.Entity<FinanceTypes>().HasData(GetFinanceTypes());
        }

        private List<Role> GetRoles()
        {
            List<Role> roles = new List<Role>();
            roles.Add(new Role() { RoleId = (int)HRMEnums.Roles.Admin, RoleName = Constants.Admin });
            roles.Add(new Role() { RoleId = (int)HRMEnums.Roles.Employee, RoleName = Constants.Employee });
            return roles;
        }

        private List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();
            departments.Add(new Department() {DepartmentId = (int)HRMEnums.Departments.HumanResources, DepartmentName = Constants.HumanResources });
            departments.Add(new Department() {DepartmentId = (int)HRMEnums.Departments.Devops, DepartmentName = Constants.Devops });
            departments.Add(new Department() {DepartmentId = (int)HRMEnums.Departments.CustomerSupport, DepartmentName = Constants.CustomerSupport });
            return departments;
        }
        private List<FinanceTypes> GetFinanceTypes()
        {
            List<FinanceTypes> financeTypes = new List<FinanceTypes>();
            financeTypes.Add(new FinanceTypes() { FinanceTypeId = (int)HRMEnums.FinanceTypes.AdvanceSalary, FinanceTypName = Constants.AdvanceSalary });
            financeTypes.Add(new FinanceTypes() { FinanceTypeId = (int)HRMEnums.FinanceTypes.Bonus, FinanceTypName = Constants.Bonus });
            financeTypes.Add(new FinanceTypes() { FinanceTypeId = (int)HRMEnums.FinanceTypes.Loan, FinanceTypName = Constants.Loan });
            return financeTypes;
        }

    }
}
