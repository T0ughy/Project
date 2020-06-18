using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Server.Migrations
{
    public partial class addProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "People",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfArrival",
                table: "People",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                table: "People",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastTimeEdited",
                table: "People",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SocialSecurityNumber",
                table: "People",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Symptom",
                table: "People",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "People");

            migrationBuilder.DropColumn(
                name: "DateOfArrival",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Diagnosis",
                table: "People");

            migrationBuilder.DropColumn(
                name: "LastTimeEdited",
                table: "People");

            migrationBuilder.DropColumn(
                name: "SocialSecurityNumber",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Symptom",
                table: "People");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "People",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
