using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace organProject.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Centers",
                columns: table => new
                {
                    CenterName = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centers", x => x.CenterName);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    BloodType = table.Column<string>(nullable: false),
                    Rh = table.Column<bool>(nullable: false),
                    Registered = table.Column<bool>(nullable: false),
                    Consent = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    HospitalID = table.Column<int>(nullable: false),
                    CurrentCenterCenterName = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.FirstName);
                    table.ForeignKey(
                        name: "FK_Donors_Centers_CurrentCenterCenterName",
                        column: x => x.CurrentCenterCenterName,
                        principalTable: "Centers",
                        principalColumn: "CenterName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recipients",
                columns: table => new
                {
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    BloodType = table.Column<string>(nullable: false),
                    Rh = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    HospitalID = table.Column<int>(nullable: false),
                    CurrentCenterCenterName = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipients", x => x.FirstName);
                    table.ForeignKey(
                        name: "FK_Recipients_Centers_CurrentCenterCenterName",
                        column: x => x.CurrentCenterCenterName,
                        principalTable: "Centers",
                        principalColumn: "CenterName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donors_CurrentCenterCenterName",
                table: "Donors",
                column: "CurrentCenterCenterName");

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_CurrentCenterCenterName",
                table: "Recipients",
                column: "CurrentCenterCenterName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donors");

            migrationBuilder.DropTable(
                name: "Recipients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Centers");
        }
    }
}
