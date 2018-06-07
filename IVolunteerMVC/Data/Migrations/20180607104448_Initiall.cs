using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IVolunteerMVC.Data.Migrations
{
    public partial class Initiall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_AspNetUsers_ApplicationUserId1",
                table: "JobApplication");

            migrationBuilder.DropIndex(
                name: "IX_JobApplication_ApplicationUserId1",
                table: "JobApplication");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "JobApplication");

            migrationBuilder.RenameColumn(
                name: "Requirements",
                table: "Posting",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "JobApplication",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_ApplicationUserId",
                table: "JobApplication",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_AspNetUsers_ApplicationUserId",
                table: "JobApplication",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_AspNetUsers_ApplicationUserId",
                table: "JobApplication");

            migrationBuilder.DropIndex(
                name: "IX_JobApplication_ApplicationUserId",
                table: "JobApplication");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Posting",
                newName: "Requirements");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "JobApplication",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "JobApplication",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_ApplicationUserId1",
                table: "JobApplication",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_AspNetUsers_ApplicationUserId1",
                table: "JobApplication",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
