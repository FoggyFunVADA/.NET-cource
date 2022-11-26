using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarService.Entities.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeansOfPayment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameOfMeanOfPayment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeansOfPayment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OwnersOfCarServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnersOfCarServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameOfService = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMeanOfPayment = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_MeansOfPayment_IdMeanOfPayment",
                        column: x => x.IdMeanOfPayment,
                        principalTable: "MeansOfPayment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkSchedule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdOwnerOfCarService = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarServices_OwnersOfCarServices_IdOwnerOfCarService",
                        column: x => x.IdOwnerOfCarService,
                        principalTable: "OwnersOfCarServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewsForCarService",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mark = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCarService = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewsForCarService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewsForCarService_CarServices_IdCarService",
                        column: x => x.IdCarService,
                        principalTable: "CarServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewsForCarService_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServicesOfCarService",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    IdCarService = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdService = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesOfCarService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicesOfCarService_CarServices_IdCarService",
                        column: x => x.IdCarService,
                        principalTable: "CarServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicesOfCarService_Services_IdService",
                        column: x => x.IdService,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarServices_IdOwnerOfCarService",
                table: "CarServices",
                column: "IdOwnerOfCarService");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsForCarService_IdCarService",
                table: "ReviewsForCarService",
                column: "IdCarService");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsForCarService_IdUser",
                table: "ReviewsForCarService",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesOfCarService_IdCarService",
                table: "ServicesOfCarService",
                column: "IdCarService");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesOfCarService_IdService",
                table: "ServicesOfCarService",
                column: "IdService");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdMeanOfPayment",
                table: "Users",
                column: "IdMeanOfPayment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewsForCarService");

            migrationBuilder.DropTable(
                name: "ServicesOfCarService");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CarServices");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "MeansOfPayment");

            migrationBuilder.DropTable(
                name: "OwnersOfCarServices");
        }
    }
}
