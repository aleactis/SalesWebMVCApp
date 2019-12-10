using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebMvcApp.Migrations
{
    public partial class OtherEntities2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "Seller",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "baseSalary",
                table: "Seller",
                newName: "BaseSalary");

            migrationBuilder.RenameColumn(
                name: "biirthDate",
                table: "Seller",
                newName: "BirthDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Seller",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "BaseSalary",
                table: "Seller",
                newName: "baseSalary");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Seller",
                newName: "biirthDate");
        }
    }
}
