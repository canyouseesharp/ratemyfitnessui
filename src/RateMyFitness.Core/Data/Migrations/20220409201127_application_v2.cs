using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RateMyFitness.Core.Data.Migrations
{
    public partial class application_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jumps_GenderType_GenderId",
                table: "Jumps");

            migrationBuilder.DropForeignKey(
                name: "FK_JumpStandards_GenderType_GenderId",
                table: "JumpStandards");

            migrationBuilder.DropForeignKey(
                name: "FK_JumpStandards_Rating_RatingId",
                table: "JumpStandards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rating",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenderType",
                table: "GenderType");

            migrationBuilder.RenameTable(
                name: "Rating",
                newName: "Ratings");

            migrationBuilder.RenameTable(
                name: "GenderType",
                newName: "GenderTypes");

            migrationBuilder.AddColumn<int>(
                name: "StandardId",
                table: "Jumps",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenderTypes",
                table: "GenderTypes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Jumps_StandardId",
                table: "Jumps",
                column: "StandardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jumps_GenderTypes_GenderId",
                table: "Jumps",
                column: "GenderId",
                principalTable: "GenderTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jumps_JumpStandards_StandardId",
                table: "Jumps",
                column: "StandardId",
                principalTable: "JumpStandards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JumpStandards_GenderTypes_GenderId",
                table: "JumpStandards",
                column: "GenderId",
                principalTable: "GenderTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JumpStandards_Ratings_RatingId",
                table: "JumpStandards",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jumps_GenderTypes_GenderId",
                table: "Jumps");

            migrationBuilder.DropForeignKey(
                name: "FK_Jumps_JumpStandards_StandardId",
                table: "Jumps");

            migrationBuilder.DropForeignKey(
                name: "FK_JumpStandards_GenderTypes_GenderId",
                table: "JumpStandards");

            migrationBuilder.DropForeignKey(
                name: "FK_JumpStandards_Ratings_RatingId",
                table: "JumpStandards");

            migrationBuilder.DropIndex(
                name: "IX_Jumps_StandardId",
                table: "Jumps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenderTypes",
                table: "GenderTypes");

            migrationBuilder.DropColumn(
                name: "StandardId",
                table: "Jumps");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "Rating");

            migrationBuilder.RenameTable(
                name: "GenderTypes",
                newName: "GenderType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rating",
                table: "Rating",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenderType",
                table: "GenderType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jumps_GenderType_GenderId",
                table: "Jumps",
                column: "GenderId",
                principalTable: "GenderType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JumpStandards_GenderType_GenderId",
                table: "JumpStandards",
                column: "GenderId",
                principalTable: "GenderType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JumpStandards_Rating_RatingId",
                table: "JumpStandards",
                column: "RatingId",
                principalTable: "Rating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
