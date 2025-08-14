using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullstackDevTS.Migrations
{
    /// <inheritdoc />
    public partial class Aug14_2025_RenameTableCategoryModeltoCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryModels",
                table: "CategoryModels");

            migrationBuilder.RenameTable(
                name: "CategoryModels",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "CategoryModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryModels",
                table: "CategoryModels",
                column: "Id");
        }
    }
}
