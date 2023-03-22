using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pojisteni_FULL.Data.Migrations
{
    public partial class _0934 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurance_InsuredPerson_InsuredPersonId",
                table: "Insurance");

            migrationBuilder.DropColumn(
                name: "InsuranceId",
                table: "InsuredPerson");

            migrationBuilder.AlterColumn<int>(
                name: "InsuredPersonId",
                table: "Insurance",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Insurance_InsuredPerson_InsuredPersonId",
                table: "Insurance",
                column: "InsuredPersonId",
                principalTable: "InsuredPerson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurance_InsuredPerson_InsuredPersonId",
                table: "Insurance");

            migrationBuilder.AddColumn<string>(
                name: "InsuranceId",
                table: "InsuredPerson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "InsuredPersonId",
                table: "Insurance",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Insurance_InsuredPerson_InsuredPersonId",
                table: "Insurance",
                column: "InsuredPersonId",
                principalTable: "InsuredPerson",
                principalColumn: "Id");
        }
    }
}
