using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedVoivodeshipToCities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VoivodeshipId",
                table: "Cities",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Cities_VoivodeshipId",
                table: "Cities",
                column: "VoivodeshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Voivodeships_VoivodeshipId",
                table: "Cities",
                column: "VoivodeshipId",
                principalTable: "Voivodeships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Voivodeships_VoivodeshipId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_VoivodeshipId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "VoivodeshipId",
                table: "Cities");
        }
    }
}
