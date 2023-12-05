using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOPlabNEW.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_BookHolderId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "BookHolderId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_BookHolderId",
                table: "Books",
                column: "BookHolderId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_BookHolderId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "BookHolderId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_BookHolderId",
                table: "Books",
                column: "BookHolderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
