using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManagement.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Customer_New_Properties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                schema: "system",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ResponsiblePersonName",
                schema: "system",
                table: "Customer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                schema: "system",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ResponsiblePersonName",
                schema: "system",
                table: "Customer");
        }
    }
}
