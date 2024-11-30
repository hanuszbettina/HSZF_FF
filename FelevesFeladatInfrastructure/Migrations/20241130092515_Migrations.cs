using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FelevesFeladatInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeesDb",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BirthYear = table.Column<int>(type: "int", nullable: false),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    CompletedProjects = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Retired = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Job = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Level = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Commission = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManagersDb",
                columns: table => new
                {
                    ManagerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BirthYear = table.Column<int>(type: "int", nullable: false),
                    StartOfEmployment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HasMBA = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagersDb", x => x.ManagerId);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentsDb",
                columns: table => new
                {
                    DepartmentCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HeadOfDepartment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmployeeconId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentsDb", x => x.DepartmentCode);
                    table.ForeignKey(
                        name: "FK_DepartmentsDb_EmployeesDb_EmployeeconId",
                        column: x => x.EmployeeconId,
                        principalTable: "EmployeesDb",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepartmentsDb_ManagersDb_Name",
                        column: x => x.Name,
                        principalTable: "ManagersDb",
                        principalColumn: "ManagerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsDb_EmployeeconId",
                table: "DepartmentsDb",
                column: "EmployeeconId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsDb_Name",
                table: "DepartmentsDb",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentsDb");

            migrationBuilder.DropTable(
                name: "EmployeesDb");

            migrationBuilder.DropTable(
                name: "ManagersDb");
        }
    }
}
