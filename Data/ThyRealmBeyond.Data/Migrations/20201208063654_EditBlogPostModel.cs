using Microsoft.EntityFrameworkCore.Migrations;

namespace ThyRealmBeyond.Data.Migrations
{
    public partial class EditBlogPostModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialty_Characters_CharacterId",
                table: "Specialty");

            migrationBuilder.DropForeignKey(
                name: "FK_Weakness_Characters_CharacterId",
                table: "Weakness");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weakness",
                table: "Weakness");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialty",
                table: "Specialty");

            migrationBuilder.RenameTable(
                name: "Weakness",
                newName: "Weaknesses");

            migrationBuilder.RenameTable(
                name: "Specialty",
                newName: "Specialties");

            migrationBuilder.RenameIndex(
                name: "IX_Weakness_IsDeleted",
                table: "Weaknesses",
                newName: "IX_Weaknesses_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Weakness_CharacterId",
                table: "Weaknesses",
                newName: "IX_Weaknesses_CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_Specialty_IsDeleted",
                table: "Specialties",
                newName: "IX_Specialties_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Specialty_CharacterId",
                table: "Specialties",
                newName: "IX_Specialties_CharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weaknesses",
                table: "Weaknesses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialties",
                table: "Specialties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialties_Characters_CharacterId",
                table: "Specialties",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weaknesses_Characters_CharacterId",
                table: "Weaknesses",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialties_Characters_CharacterId",
                table: "Specialties");

            migrationBuilder.DropForeignKey(
                name: "FK_Weaknesses_Characters_CharacterId",
                table: "Weaknesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weaknesses",
                table: "Weaknesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialties",
                table: "Specialties");

            migrationBuilder.RenameTable(
                name: "Weaknesses",
                newName: "Weakness");

            migrationBuilder.RenameTable(
                name: "Specialties",
                newName: "Specialty");

            migrationBuilder.RenameIndex(
                name: "IX_Weaknesses_IsDeleted",
                table: "Weakness",
                newName: "IX_Weakness_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Weaknesses_CharacterId",
                table: "Weakness",
                newName: "IX_Weakness_CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_Specialties_IsDeleted",
                table: "Specialty",
                newName: "IX_Specialty_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Specialties_CharacterId",
                table: "Specialty",
                newName: "IX_Specialty_CharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weakness",
                table: "Weakness",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialty",
                table: "Specialty",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialty_Characters_CharacterId",
                table: "Specialty",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weakness_Characters_CharacterId",
                table: "Weakness",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
