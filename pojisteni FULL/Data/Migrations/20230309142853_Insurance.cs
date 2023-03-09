using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pojisteni_FULL.Data.Migrations
{
    public partial class Insurance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insurance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceAmount = table.Column<int>(type: "int", nullable: false),
                    SubjectOfInsurance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Insurance");
        }
    }
}
