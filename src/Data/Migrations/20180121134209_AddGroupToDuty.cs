using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TaskPlanner.Data.Migrations
{
    public partial class AddGroupToDuty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DutyId",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_DutyId",
                table: "Groups",
                column: "DutyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Duties_DutyId",
                table: "Groups",
                column: "DutyId",
                principalTable: "Duties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Duties_DutyId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_DutyId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "DutyId",
                table: "Groups");
        }
    }
}
