using Microsoft.EntityFrameworkCore.Migrations;

namespace apitest.Migrations
{
    public partial class inital2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "StoreB",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "StoreA",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tag",
                table: "StoreB");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "StoreA");
        }
    }
}
