using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRegistrationApi.Migrations
{
    /// <inheritdoc />
    public partial class AddIsNotificationSentToRegistrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNotificationSent",
                table: "Registrations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNotificationSent",
                table: "Registrations");
        }
    }
}
