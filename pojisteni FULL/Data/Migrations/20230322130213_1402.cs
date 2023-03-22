using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pojisteni_FULL.Data.Migrations
{
    public partial class _1402 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurance_InsuredPersonInsuranceViewModel_InsuredPersonInsuranceViewModelId",
                table: "Insurance");

            migrationBuilder.DropTable(
                name: "InsuredPersonInsuranceViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Insurance_InsuredPersonInsuranceViewModelId",
                table: "Insurance");

            migrationBuilder.DropColumn(
                name: "InsuredPersonInsuranceViewModelId",
                table: "Insurance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InsuredPersonInsuranceViewModelId",
                table: "Insurance",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InsuredPersonInsuranceViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuredPersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuredPersonInsuranceViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuredPersonInsuranceViewModel_InsuredPerson_InsuredPersonId",
                        column: x => x.InsuredPersonId,
                        principalTable: "InsuredPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Insurance_InsuredPersonInsuranceViewModelId",
                table: "Insurance",
                column: "InsuredPersonInsuranceViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuredPersonInsuranceViewModel_InsuredPersonId",
                table: "InsuredPersonInsuranceViewModel",
                column: "InsuredPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Insurance_InsuredPersonInsuranceViewModel_InsuredPersonInsuranceViewModelId",
                table: "Insurance",
                column: "InsuredPersonInsuranceViewModelId",
                principalTable: "InsuredPersonInsuranceViewModel",
                principalColumn: "Id");
        }
    }
}
