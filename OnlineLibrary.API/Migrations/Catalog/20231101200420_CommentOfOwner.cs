using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineRentCar.API.Migrations.Catalog
{
    /// <inheritdoc />
    public partial class CommentOfOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentOfOwner",
                table: "RentalCars",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentOfOwner",
                table: "RentalCars");
        }
    }
}
