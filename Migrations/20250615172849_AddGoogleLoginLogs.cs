using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevTrack.Migrations
{
    /// <inheritdoc />
    public partial class AddGoogleLoginLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoogleLoginLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    GoogleId = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    LoginTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IpAddress = table.Column<string>(type: "TEXT", maxLength: 45, nullable: true),
                    UserAgent = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoogleLoginLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoogleLoginLogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoogleLoginLogs_Email",
                table: "GoogleLoginLogs",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_GoogleLoginLogs_GoogleId",
                table: "GoogleLoginLogs",
                column: "GoogleId");

            migrationBuilder.CreateIndex(
                name: "IX_GoogleLoginLogs_LoginTime",
                table: "GoogleLoginLogs",
                column: "LoginTime");

            migrationBuilder.CreateIndex(
                name: "IX_GoogleLoginLogs_UserId",
                table: "GoogleLoginLogs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoogleLoginLogs");
        }
    }
}
