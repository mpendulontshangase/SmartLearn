using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartLearn.Migrations
{
    public partial class _101111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Learner_Grade",
                table: "Sl.Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Learner_Id",
                table: "Sl.Persons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Learner_Subject",
                table: "Sl.Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "Sl.Persons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sl.Persons_ParentId",
                table: "Sl.Persons",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sl.Persons_Sl.Persons_ParentId",
                table: "Sl.Persons",
                column: "ParentId",
                principalTable: "Sl.Persons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sl.Persons_Sl.Persons_ParentId",
                table: "Sl.Persons");

            migrationBuilder.DropIndex(
                name: "IX_Sl.Persons_ParentId",
                table: "Sl.Persons");

            migrationBuilder.DropColumn(
                name: "Learner_Grade",
                table: "Sl.Persons");

            migrationBuilder.DropColumn(
                name: "Learner_Id",
                table: "Sl.Persons");

            migrationBuilder.DropColumn(
                name: "Learner_Subject",
                table: "Sl.Persons");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Sl.Persons");
        }
    }
}
