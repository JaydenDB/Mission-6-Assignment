using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission06_Brown.Migrations
{
    /// <inheritdoc />
    public partial class AddCopiedToPlex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CopiedToPlex",
                table: "Movies",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CopiedToPlex",
                table: "Movies");
        }
    }
}
