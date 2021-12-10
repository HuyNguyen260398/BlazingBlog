using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazingBlog.Server.Migrations
{
    public partial class AddImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ispublished",
                table: "BlogPosts",
                newName: "IsPublished");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "BlogPosts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "BlogPosts");

            migrationBuilder.RenameColumn(
                name: "IsPublished",
                table: "BlogPosts",
                newName: "Ispublished");
        }
    }
}
