using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class AddDemographicAndIdentificationFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BloodGroup",
                table: "PersonalDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complexion",
                table: "PersonalDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateofIssue",
                table: "PersonalDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisabilityDetails",
                table: "PersonalDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DriversLicense",
                table: "PersonalDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "PersonalDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genotype",
                table: "PersonalDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HasDisability",
                table: "PersonalDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "PersonalDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hobbies",
                table: "PersonalDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalID",
                table: "PersonalDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Passport",
                table: "PersonalDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceofIssue",
                table: "PersonalDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "PersonalDetails",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodGroup",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "Complexion",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "DateofIssue",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "DisabilityDetails",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "DriversLicense",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "Genotype",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "HasDisability",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "Hobbies",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "NationalID",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "Passport",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "PlaceofIssue",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "PersonalDetails");
        }
    }
}
