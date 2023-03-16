using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1Repository.Migrations
{
    /// <inheritdoc />
    public partial class u : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Users_UserId",
                table: "Children");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Children",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Users_UserId",
                table: "Children",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Users_UserId",
                table: "Children");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Children",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Users_UserId",
                table: "Children",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
