using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class DLchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Universities_Country_CountryId",
                table: "Universities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "Krs",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Nip",
                table: "Universities");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.RenameColumn(
                name: "Www",
                table: "Universities",
                newName: "Website");

            migrationBuilder.RenameColumn(
                name: "Voivodeship",
                table: "Universities",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "UniversityName",
                table: "Universities",
                newName: "TaxId");

            migrationBuilder.RenameColumn(
                name: "Typ",
                table: "Universities",
                newName: "JudgeRegisterId");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Universities",
                newName: "BuildingNumber");

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Voivodeships",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Universities",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "VoivodeshipId",
                table: "Universities",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Voivodeships_CountryId",
                table: "Voivodeships",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_VoivodeshipId",
                table: "Universities",
                column: "VoivodeshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_Countries_CountryId",
                table: "Universities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_Voivodeships_VoivodeshipId",
                table: "Universities",
                column: "VoivodeshipId",
                principalTable: "Voivodeships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voivodeships_Countries_CountryId",
                table: "Voivodeships",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Universities_Countries_CountryId",
                table: "Universities");

            migrationBuilder.DropForeignKey(
                name: "FK_Universities_Voivodeships_VoivodeshipId",
                table: "Universities");

            migrationBuilder.DropForeignKey(
                name: "FK_Voivodeships_Countries_CountryId",
                table: "Voivodeships");

            migrationBuilder.DropIndex(
                name: "IX_Voivodeships_CountryId",
                table: "Voivodeships");

            migrationBuilder.DropIndex(
                name: "IX_Universities_VoivodeshipId",
                table: "Universities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Voivodeships");

            migrationBuilder.DropColumn(
                name: "VoivodeshipId",
                table: "Universities");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Website",
                table: "Universities",
                newName: "Www");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Universities",
                newName: "Voivodeship");

            migrationBuilder.RenameColumn(
                name: "TaxId",
                table: "Universities",
                newName: "UniversityName");

            migrationBuilder.RenameColumn(
                name: "JudgeRegisterId",
                table: "Universities",
                newName: "Typ");

            migrationBuilder.RenameColumn(
                name: "BuildingNumber",
                table: "Universities",
                newName: "Number");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedDate",
                table: "Universities",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "Krs",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nip",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_Country_CountryId",
                table: "Universities",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
