using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace organProject.Migrations
{
    public partial class donorID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_Centers_CurrentCenterCenterName",
                table: "Donors");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_Centers_CurrentCenterCenterName",
                table: "Recipients");

            migrationBuilder.DropIndex(
                name: "IX_Recipients_CurrentCenterCenterName",
                table: "Recipients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Donors",
                table: "Donors");

            migrationBuilder.DropIndex(
                name: "IX_Donors_CurrentCenterCenterName",
                table: "Donors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Centers",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "CurrentCenterCenterName",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "CurrentCenterCenterName",
                table: "Donors");

            migrationBuilder.AddColumn<int>(
                name: "CurrentCenterCenterID",
                table: "Recipients",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Donors",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "DonorID",
                table: "Donors",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "CurrentCenterCenterID",
                table: "Donors",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CenterName",
                table: "Centers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CenterID",
                table: "Centers",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donors",
                table: "Donors",
                column: "DonorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Centers",
                table: "Centers",
                column: "CenterID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_CurrentCenterCenterID",
                table: "Recipients",
                column: "CurrentCenterCenterID");

            migrationBuilder.CreateIndex(
                name: "IX_Donors_CurrentCenterCenterID",
                table: "Donors",
                column: "CurrentCenterCenterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_Centers_CurrentCenterCenterID",
                table: "Donors",
                column: "CurrentCenterCenterID",
                principalTable: "Centers",
                principalColumn: "CenterID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_Centers_CurrentCenterCenterID",
                table: "Recipients",
                column: "CurrentCenterCenterID",
                principalTable: "Centers",
                principalColumn: "CenterID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_Centers_CurrentCenterCenterID",
                table: "Donors");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_Centers_CurrentCenterCenterID",
                table: "Recipients");

            migrationBuilder.DropIndex(
                name: "IX_Recipients_CurrentCenterCenterID",
                table: "Recipients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Donors",
                table: "Donors");

            migrationBuilder.DropIndex(
                name: "IX_Donors_CurrentCenterCenterID",
                table: "Donors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Centers",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "CurrentCenterCenterID",
                table: "Recipients");

            migrationBuilder.DropColumn(
                name: "DonorID",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "CurrentCenterCenterID",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "CenterID",
                table: "Centers");

            migrationBuilder.AddColumn<string>(
                name: "CurrentCenterCenterName",
                table: "Recipients",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Donors",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CurrentCenterCenterName",
                table: "Donors",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CenterName",
                table: "Centers",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donors",
                table: "Donors",
                column: "FirstName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Centers",
                table: "Centers",
                column: "CenterName");

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_CurrentCenterCenterName",
                table: "Recipients",
                column: "CurrentCenterCenterName");

            migrationBuilder.CreateIndex(
                name: "IX_Donors_CurrentCenterCenterName",
                table: "Donors",
                column: "CurrentCenterCenterName");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_Centers_CurrentCenterCenterName",
                table: "Donors",
                column: "CurrentCenterCenterName",
                principalTable: "Centers",
                principalColumn: "CenterName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_Centers_CurrentCenterCenterName",
                table: "Recipients",
                column: "CurrentCenterCenterName",
                principalTable: "Centers",
                principalColumn: "CenterName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
