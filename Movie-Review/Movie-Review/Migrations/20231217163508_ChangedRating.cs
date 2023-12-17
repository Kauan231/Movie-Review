using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Review.Migrations
{
    public partial class ChangedRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Rating",
                table: "Reviews",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Rating",
                table: "Reviews",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
