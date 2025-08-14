using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullstackDevTS.Migrations
{
    /// <inheritdoc />
    public partial class TableCategoryRenameColumnDateTimeToCreatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Category",
                newName: "CreatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Category",
                newName: "DateTime");
        }
    }
}
