using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RateMyFitness.Core.Data.Migrations
{
    public partial class application_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenderType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jumps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Measurement = table.Column<double>(type: "REAL", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    GenderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jumps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jumps_GenderType_GenderId",
                        column: x => x.GenderId,
                        principalTable: "GenderType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JumpStandards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AgeMin = table.Column<int>(type: "INTEGER", nullable: false),
                    AgeMax = table.Column<int>(type: "INTEGER", nullable: false),
                    GenderId = table.Column<int>(type: "INTEGER", nullable: false),
                    MeasurementMin = table.Column<double>(type: "REAL", nullable: false),
                    MeasurementMax = table.Column<double>(type: "REAL", nullable: false),
                    RatingId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JumpStandards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JumpStandards_GenderType_GenderId",
                        column: x => x.GenderId,
                        principalTable: "GenderType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JumpStandards_Rating_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Rating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jumps_GenderId",
                table: "Jumps",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_JumpStandards_GenderId",
                table: "JumpStandards",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_JumpStandards_RatingId",
                table: "JumpStandards",
                column: "RatingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jumps");

            migrationBuilder.DropTable(
                name: "JumpStandards");

            migrationBuilder.DropTable(
                name: "GenderType");

            migrationBuilder.DropTable(
                name: "Rating");
        }
    }
}
