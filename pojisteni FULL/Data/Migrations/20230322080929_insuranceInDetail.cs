using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pojisteni_FULL.Data.Migrations
{
    public partial class insuranceInDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InsuredPersonId",
                table: "Insurance",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Insurance_InsuredPersonId",
                table: "Insurance",
                column: "InsuredPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Insurance_InsuredPerson_InsuredPersonId",
                table: "Insurance",
                column: "InsuredPersonId",
                principalTable: "InsuredPerson",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurance_InsuredPerson_InsuredPersonId",
                table: "Insurance");

            migrationBuilder.DropIndex(
                name: "IX_Insurance_InsuredPersonId",
                table: "Insurance");
            
            migrationBuilder.DropColumn(
                name: "InsuredPersonId",
                table: "Insurance");
        }
    }
}
