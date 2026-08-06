using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace volunteer_management.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opportunities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    Center = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 254, nullable: false),
                    HomePhone = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    WorkPhone = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    CellPhone = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    AddressLine1 = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    AddressLine2 = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    PreferredCenters = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    SkillsInterests = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Availability = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    EducationalBackground = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    CurrentLicenses = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    EmergencyContactName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    EmergencyContactHomePhone = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    EmergencyContactWorkPhone = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    EmergencyContactEmail = table.Column<string>(type: "TEXT", maxLength: 254, nullable: true),
                    EmergencyContactAddress = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    HasDriversLicenseCopy = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    HasSocialSecurityCardCopy = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false, defaultValue: "Pending"),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_Center",
                table: "Opportunities",
                column: "Center");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_CreatedAt",
                table: "Opportunities",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_Name",
                table: "Opportunities",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_Email",
                table: "Volunteers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_LastName",
                table: "Volunteers",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_Status",
                table: "Volunteers",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_Username",
                table: "Volunteers",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opportunities");

            migrationBuilder.DropTable(
                name: "Volunteers");
        }
    }
}
