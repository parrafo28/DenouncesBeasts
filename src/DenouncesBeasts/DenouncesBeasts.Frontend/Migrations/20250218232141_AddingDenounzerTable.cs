using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DenouncesBeasts.Frontend.Migrations
{
    /// <inheritdoc />
    public partial class AddingDenounzerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DenounzerId",
                table: "Denounces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Denounzers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denounzers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Denounces_DenounzerId",
                table: "Denounces",
                column: "DenounzerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Denounces_Denounzers_DenounzerId",
                table: "Denounces",
                column: "DenounzerId",
                principalTable: "Denounzers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Denounces_Denounzers_DenounzerId",
                table: "Denounces");

            migrationBuilder.DropTable(
                name: "Denounzers");

            migrationBuilder.DropIndex(
                name: "IX_Denounces_DenounzerId",
                table: "Denounces");

            migrationBuilder.DropColumn(
                name: "DenounzerId",
                table: "Denounces");
        }
    }
}
