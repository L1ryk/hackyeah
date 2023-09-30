using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedUniveristyDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UniversitiesDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UniversityName = table.Column<string>(type: "text", nullable: false),
                    PersonManaging = table.Column<string>(type: "text", nullable: false),
                    SupervisoryAuthority = table.Column<string>(type: "text", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: false),
                    Typ = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Regon = table.Column<string>(type: "text", nullable: false),
                    Nip = table.Column<string>(type: "text", nullable: false),
                    Krs = table.Column<string>(type: "text", nullable: false),
                    Www = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Voivodeship = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    PostCode = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "text", nullable: false),
                    RecruitmentLink = table.Column<string>(type: "text", nullable: false),
                    IconId = table.Column<string>(type: "text", nullable: false),
                    PdfLink = table.Column<string>(type: "text", nullable: false),
                    TercCity = table.Column<string>(type: "text", nullable: false),
                    TercDistrict = table.Column<string>(type: "text", nullable: false),
                    TercVoivodeship = table.Column<string>(type: "text", nullable: false),
                    Epuap = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<string>(type: "text", nullable: false),
                    AvailabilityFormUrl = table.Column<string>(type: "text", nullable: false),
                    RecruitmentPageUrl = table.Column<string>(type: "text", nullable: false),
                    PromotionalFilmUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversitiesDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UniversityStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Year = table.Column<string>(type: "text", nullable: false),
                    NumberStudents = table.Column<int>(type: "integer", nullable: false),
                    NumberCourse = table.Column<int>(type: "integer", nullable: false),
                    NumberEmployees = table.Column<int>(type: "integer", nullable: false),
                    UniversityDetailsId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniversityStatistics_UniversitiesDetails_UniversityDetailsId",
                        column: x => x.UniversityDetailsId,
                        principalTable: "UniversitiesDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UniversityStatistics_UniversityDetailsId",
                table: "UniversityStatistics",
                column: "UniversityDetailsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UniversityStatistics");

            migrationBuilder.DropTable(
                name: "UniversitiesDetails");
        }
    }
}
