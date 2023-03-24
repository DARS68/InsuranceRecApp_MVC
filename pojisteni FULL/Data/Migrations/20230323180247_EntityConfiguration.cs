using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pojisteni_FULL.Migrations
{
    public partial class EntityConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurance_InsuredPerson_InsuredPersonId",
                table: "Insurance");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "InsuredPerson",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "ZipCode",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StreetAndNumber",
                table: "InsuredPerson",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                comment: "StreetAndNumber",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "InsuredPerson",
                type: "int",
                nullable: false,
                comment: "PhoneNumber",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "InsuredPerson",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "LastName",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "InsuredPerson",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "FirstName",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "InsuredPerson",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "Email",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "InsuredPerson",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "City",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InsuredPersonID",
                table: "InsuredPerson",
                type: "int",
                nullable: false,
                comment: "InsuredPersonID",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidTo",
                table: "Insurance",
                type: "datetime",
                nullable: false,
                comment: "ValidTo",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidFrom",
                table: "Insurance",
                type: "datetime",
                nullable: false,
                comment: "ValidFrom",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectOfInsurance",
                table: "Insurance",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                comment: "SubjectOfInsurance",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InsuredPersonId",
                table: "Insurance",
                type: "int",
                nullable: false,
                comment: "InsuredPersonId",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "InsuranceName",
                table: "Insurance",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                comment: "InsuranceName",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InsuranceDescription",
                table: "Insurance",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                comment: "InsuranceDescription",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceAmount",
                table: "Insurance",
                type: "int",
                nullable: false,
                comment: "InsuranceAmount",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceID",
                table: "Insurance",
                type: "int",
                nullable: false,
                comment: "InsuranceID",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuredPerson_Insurance",
                table: "Insurance",
                column: "InsuredPersonId",
                principalTable: "InsuredPerson",
                principalColumn: "InsuredPersonID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuredPerson_Insurance",
                table: "Insurance");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "InsuredPerson",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "ZipCode");

            migrationBuilder.AlterColumn<string>(
                name: "StreetAndNumber",
                table: "InsuredPerson",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true,
                oldComment: "StreetAndNumber");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "InsuredPerson",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "PhoneNumber");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "InsuredPerson",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "LastName");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "InsuredPerson",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "InsuredPerson",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldComment: "Email");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "InsuredPerson",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "City");

            migrationBuilder.AlterColumn<int>(
                name: "InsuredPersonID",
                table: "InsuredPerson",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "InsuredPersonID")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidTo",
                table: "Insurance",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldComment: "ValidTo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidFrom",
                table: "Insurance",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldComment: "ValidFrom");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectOfInsurance",
                table: "Insurance",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true,
                oldComment: "SubjectOfInsurance");

            migrationBuilder.AlterColumn<int>(
                name: "InsuredPersonId",
                table: "Insurance",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "InsuredPersonId");

            migrationBuilder.AlterColumn<string>(
                name: "InsuranceName",
                table: "Insurance",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true,
                oldComment: "InsuranceName");

            migrationBuilder.AlterColumn<string>(
                name: "InsuranceDescription",
                table: "Insurance",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true,
                oldComment: "InsuranceDescription");

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceAmount",
                table: "Insurance",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "InsuranceAmount");

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceID",
                table: "Insurance",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "InsuranceID")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Insurance_InsuredPerson_InsuredPersonId",
                table: "Insurance",
                column: "InsuredPersonId",
                principalTable: "InsuredPerson",
                principalColumn: "InsuredPersonID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
