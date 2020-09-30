using Microsoft.EntityFrameworkCore.Migrations;

namespace organProject.Migrations
{
    public partial class changehospID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_Centers_CurrentCenterCenterID",
                table: "Recipients");

            migrationBuilder.DropIndex(
                name: "IX_Recipients_CurrentCenterCenterID",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "CurrentCenterCenterID",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "HospitalID",
                table: "Recipients");

            migrationBuilder.AddColumn<int>(
                name: "CenterID",
                table: "Recipients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_CenterID",
                table: "Recipients",
                column: "CenterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_Centers_CenterID",
                table: "Recipients",
                column: "CenterID",
                principalTable: "Centers",
                principalColumn: "CenterID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_Centers_CenterID",
                table: "Recipients");

            migrationBuilder.DropIndex(
                name: "IX_Recipients_CenterID",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "CenterID",
                table: "Recipients");

            migrationBuilder.AddColumn<int>(
                name: "CurrentCenterCenterID",
                table: "Recipients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HospitalID",
                table: "Recipients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_CurrentCenterCenterID",
                table: "Recipients",
                column: "CurrentCenterCenterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_Centers_CurrentCenterCenterID",
                table: "Recipients",
                column: "CurrentCenterCenterID",
                principalTable: "Centers",
                principalColumn: "CenterID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
