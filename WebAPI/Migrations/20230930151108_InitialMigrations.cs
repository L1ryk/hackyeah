using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voivodeships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voivodeships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voivodeships_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    VoivodeshipId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Voivodeships_VoivodeshipId",
                        column: x => x.VoivodeshipId,
                        principalTable: "Voivodeships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PersonManaging = table.Column<string>(type: "text", nullable: false),
                    SupervisoryAuthority = table.Column<string>(type: "text", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Regon = table.Column<string>(type: "text", nullable: false),
                    TaxId = table.Column<string>(type: "text", nullable: false),
                    JudgeRegisterId = table.Column<string>(type: "text", nullable: false),
                    Website = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    VoivodeshipId = table.Column<Guid>(type: "uuid", nullable: false),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false),
                    PostCode = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    BuildingNumber = table.Column<string>(type: "text", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "text", nullable: false),
                    RecruitmentLink = table.Column<string>(type: "text", nullable: false),
                    IconId = table.Column<string>(type: "text", nullable: false),
                    PdfLink = table.Column<string>(type: "text", nullable: false),
                    TercCity = table.Column<string>(type: "text", nullable: false),
                    TercDistrict = table.Column<string>(type: "text", nullable: false),
                    TercVoivodeship = table.Column<string>(type: "text", nullable: false),
                    Epuap = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AvailabilityFormUrl = table.Column<string>(type: "text", nullable: false),
                    RecruitmentPageUrl = table.Column<string>(type: "text", nullable: false),
                    PromotionalFilmUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Universities_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Universities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Universities_Voivodeships_VoivodeshipId",
                        column: x => x.VoivodeshipId,
                        principalTable: "Voivodeships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniversityStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UniversityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Year = table.Column<string>(type: "text", nullable: false),
                    NumberStudents = table.Column<int>(type: "integer", nullable: false),
                    NumberCourse = table.Column<int>(type: "integer", nullable: false),
                    NumberEmployees = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniversityStatistics_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_VoivodeshipId",
                table: "Cities",
                column: "VoivodeshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_CityId",
                table: "Universities",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_CountryId",
                table: "Universities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_VoivodeshipId",
                table: "Universities",
                column: "VoivodeshipId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityStatistics_UniversityId",
                table: "UniversityStatistics",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Voivodeships_CountryId",
                table: "Voivodeships",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UniversityStatistics");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Voivodeships");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
