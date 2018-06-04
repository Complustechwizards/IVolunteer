using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IVolunteer.Data.Migrations
{
    public partial class Cephas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posting",
                columns: table => new
                {
                    PostingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgeRequirementFrom = table.Column<int>(nullable: false),
                    AgeRequirementTo = table.Column<int>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    JobLocation = table.Column<string>(nullable: false),
                    JobTitle = table.Column<string>(nullable: false),
                    NumberOfVolunteersNeeded = table.Column<int>(nullable: false),
                    Requirements = table.Column<string>(nullable: false),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posting", x => x.PostingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posting");
        }
    }
}
