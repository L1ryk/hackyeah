using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedEntitiesRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UniversityStatistics_UniversitiesDetails_UniversityDetailsId",
                table: "UniversityStatistics");

            migrationBuilder.DropTable(
                name: "UniversitiesDetails");

            migrationBuilder.DropIndex(
                name: "IX_UniversityStatistics_UniversityDetailsId",
                table: "UniversityStatistics");

            migrationBuilder.DropColumn(
                name: "UniversityDetailsId",
                table: "UniversityStatistics");

            migrationBuilder.AddColumn<Guid>(
                name: "UniversityId",
                table: "UniversityStatistics",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ApartmentNumber",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AvailabilityFormUrl",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "Universities",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Universities",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Epuap",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IconId",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PdfLink",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonManaging",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PromotionalFilmUrl",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecruitmentLink",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecruitmentPageUrl",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Regon",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupervisoryAuthority",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TercCity",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TercDistrict",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TercVoivodeship",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Typ",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UniversityName",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Voivodeship",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Www",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UniversityStatistics_UniversityId",
                table: "UniversityStatistics",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_CityId",
                table: "Universities",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_CountryId",
                table: "Universities",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_Cities_CityId",
                table: "Universities",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_Country_CountryId",
                table: "Universities",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityStatistics_Universities_UniversityId",
                table: "UniversityStatistics",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Universities_Cities_CityId",
                table: "Universities");

            migrationBuilder.DropForeignKey(
                name: "FK_Universities_Country_CountryId",
                table: "Universities");

            migrationBuilder.DropForeignKey(
                name: "FK_UniversityStatistics_Universities_UniversityId",
                table: "UniversityStatistics");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_UniversityStatistics_UniversityId",
                table: "UniversityStatistics");

            migrationBuilder.DropIndex(
                name: "IX_Universities_CityId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Universities_CountryId",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "UniversityStatistics");

            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "AvailabilityFormUrl",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Epuap",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "IconId",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Krs",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Nip",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "PdfLink",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "PersonManaging",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "PromotionalFilmUrl",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "RecruitmentLink",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "RecruitmentPageUrl",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Regon",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "SupervisoryAuthority",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "TercCity",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "TercDistrict",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "TercVoivodeship",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Typ",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "UniversityName",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Voivodeship",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Www",
                table: "Universities");

            migrationBuilder.AddColumn<Guid>(
                name: "UniversityDetailsId",
                table: "UniversityStatistics",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UniversitiesDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "text", nullable: false),
                    AvailabilityFormUrl = table.Column<string>(type: "text", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Epuap = table.Column<string>(type: "text", nullable: false),
                    IconId = table.Column<string>(type: "text", nullable: false),
                    Krs = table.Column<string>(type: "text", nullable: false),
                    Nip = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    PdfLink = table.Column<string>(type: "text", nullable: false),
                    PersonManaging = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    PostCode = table.Column<string>(type: "text", nullable: false),
                    PromotionalFilmUrl = table.Column<string>(type: "text", nullable: false),
                    RecruitmentLink = table.Column<string>(type: "text", nullable: false),
                    RecruitmentPageUrl = table.Column<string>(type: "text", nullable: false),
                    Regon = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    SupervisoryAuthority = table.Column<string>(type: "text", nullable: false),
                    TercCity = table.Column<string>(type: "text", nullable: false),
                    TercDistrict = table.Column<string>(type: "text", nullable: false),
                    TercVoivodeship = table.Column<string>(type: "text", nullable: false),
                    Typ = table.Column<string>(type: "text", nullable: false),
                    UniversityName = table.Column<string>(type: "text", nullable: false),
                    Voivodeship = table.Column<string>(type: "text", nullable: false),
                    Www = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversitiesDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UniversityStatistics_UniversityDetailsId",
                table: "UniversityStatistics",
                column: "UniversityDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityStatistics_UniversitiesDetails_UniversityDetailsId",
                table: "UniversityStatistics",
                column: "UniversityDetailsId",
                principalTable: "UniversitiesDetails",
                principalColumn: "Id");
        }
    }
}
