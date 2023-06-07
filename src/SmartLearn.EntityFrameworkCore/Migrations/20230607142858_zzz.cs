using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartLearn.Migrations
{
    public partial class zzz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test_Id",
                table: "Sl.Records");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Test_Id",
                table: "Sl.Records",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
