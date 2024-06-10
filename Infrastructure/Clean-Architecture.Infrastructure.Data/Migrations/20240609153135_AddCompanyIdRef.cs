using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean_Architecture.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyIdRef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                schema: "Accounting",
                table: "Accounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CompanyId",
                schema: "Accounting",
                table: "Accounts",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Companies_CompanyId",
                schema: "Accounting",
                table: "Accounts",
                column: "CompanyId",
                principalSchema: "Common",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Companies_CompanyId",
                schema: "Accounting",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_CompanyId",
                schema: "Accounting",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Accounting",
                table: "Accounts");
        }
    }
}
