using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRM.Rest.Services.Migrations
{
    public partial class initialv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADDRESS_INFO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESS_INFO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENTS",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENTS", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "FINANCE_TYPES",
                columns: table => new
                {
                    FinanceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinanceTypName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FINANCE_TYPES", x => x.FinanceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "USER_INFO",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Compensation = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    SecondaryAddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_INFO", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_USER_INFO_ADDRESS_INFO_AddressId",
                        column: x => x.AddressId,
                        principalTable: "ADDRESS_INFO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_INFO_ADDRESS_INFO_SecondaryAddressId",
                        column: x => x.SecondaryAddressId,
                        principalTable: "ADDRESS_INFO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_INFO_DEPARTMENTS_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DEPARTMENTS",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_INFO_ROLES_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ROLES",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE_ATTENDANCE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClockIn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClockOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isEmployeeOnLeave = table.Column<bool>(type: "bit", nullable: false),
                    isApproved = table.Column<bool>(type: "bit", nullable: false),
                    UserInfoUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE_ATTENDANCE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_ATTENDANCE_USER_INFO_UserInfoUserId",
                        column: x => x.UserInfoUserId,
                        principalTable: "USER_INFO",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE_FINANCE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountSanctioned = table.Column<int>(type: "int", nullable: false),
                    Tenure = table.Column<int>(type: "int", nullable: true),
                    InterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSanctioned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    UserInfoUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE_FINANCE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_FINANCE_USER_INFO_UserInfoUserId",
                        column: x => x.UserInfoUserId,
                        principalTable: "USER_INFO",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DEPARTMENTS",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Human Resources" },
                    { 2, "Devops Engineering" },
                    { 3, "Customer Support" }
                });

            migrationBuilder.InsertData(
                table: "FINANCE_TYPES",
                columns: new[] { "FinanceTypeId", "FinanceTypName" },
                values: new object[,]
                {
                    { 1, "Advance Salary" },
                    { 2, "Bonus" },
                    { 3, "Loan" }
                });

            migrationBuilder.InsertData(
                table: "ROLES",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Employee" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_ATTENDANCE_UserInfoUserId",
                table: "EMPLOYEE_ATTENDANCE",
                column: "UserInfoUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_FINANCE_UserInfoUserId",
                table: "EMPLOYEE_FINANCE",
                column: "UserInfoUserId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_INFO_AddressId",
                table: "USER_INFO",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_INFO_DepartmentId",
                table: "USER_INFO",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_INFO_RoleId",
                table: "USER_INFO",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_INFO_SecondaryAddressId",
                table: "USER_INFO",
                column: "SecondaryAddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMPLOYEE_ATTENDANCE");

            migrationBuilder.DropTable(
                name: "EMPLOYEE_FINANCE");

            migrationBuilder.DropTable(
                name: "FINANCE_TYPES");

            migrationBuilder.DropTable(
                name: "USER_INFO");

            migrationBuilder.DropTable(
                name: "ADDRESS_INFO");

            migrationBuilder.DropTable(
                name: "DEPARTMENTS");

            migrationBuilder.DropTable(
                name: "ROLES");
        }
    }
}
