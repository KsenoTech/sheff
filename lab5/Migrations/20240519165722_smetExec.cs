using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSheff.Migrations
{
    /// <inheritdoc />
    public partial class smetExec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id_executor",
                table: "Smeta",
                type: "int",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id_executor",
                table: "Smeta",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 450,
                oldNullable: true);
        }
    }
}
