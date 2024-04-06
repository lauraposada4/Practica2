using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScientificResearch.API.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesFull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Investigators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    specialty = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    membership = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investigators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ScientificInvestigations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificInvestigations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "searchActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_searchActivities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "specializedResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    supplier = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    deliveyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specializedResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResearcherParticipations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_ScientificInvestigations = table.Column<int>(type: "int", nullable: false),
                    ScientificInvestigationsId = table.Column<int>(type: "int", nullable: true),
                    Id_Investigators = table.Column<int>(type: "int", nullable: false),
                    InvestigatorsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearcherParticipations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearcherParticipations_Investigators_InvestigatorsId",
                        column: x => x.InvestigatorsId,
                        principalTable: "Investigators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResearcherParticipations_ScientificInvestigations_ScientificInvestigationsId",
                        column: x => x.ScientificInvestigationsId,
                        principalTable: "ScientificInvestigations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResourceAllocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Id_ScientificInvestigations = table.Column<int>(type: "int", nullable: false),
                    ScientificInvestigationsId = table.Column<int>(type: "int", nullable: true),
                    Id_searchActivities = table.Column<int>(type: "int", nullable: false),
                    searchActivitiesId = table.Column<int>(type: "int", nullable: true),
                    Id_specializedResources = table.Column<int>(type: "int", nullable: false),
                    specializedResourcesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceAllocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceAllocations_ScientificInvestigations_ScientificInvestigationsId",
                        column: x => x.ScientificInvestigationsId,
                        principalTable: "ScientificInvestigations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResourceAllocations_searchActivities_searchActivitiesId",
                        column: x => x.searchActivitiesId,
                        principalTable: "searchActivities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResourceAllocations_specializedResources_specializedResourcesId",
                        column: x => x.specializedResourcesId,
                        principalTable: "specializedResources",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResearcherParticipations_InvestigatorsId",
                table: "ResearcherParticipations",
                column: "InvestigatorsId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearcherParticipations_ScientificInvestigationsId",
                table: "ResearcherParticipations",
                column: "ScientificInvestigationsId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceAllocations_ScientificInvestigationsId",
                table: "ResourceAllocations",
                column: "ScientificInvestigationsId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceAllocations_searchActivitiesId",
                table: "ResourceAllocations",
                column: "searchActivitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceAllocations_specializedResourcesId",
                table: "ResourceAllocations",
                column: "specializedResourcesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropTable(
                name: "ResearcherParticipations");

            migrationBuilder.DropTable(
                name: "ResourceAllocations");

            migrationBuilder.DropTable(
                name: "Investigators");

            migrationBuilder.DropTable(
                name: "ScientificInvestigations");

            migrationBuilder.DropTable(
                name: "searchActivities");

            migrationBuilder.DropTable(
                name: "specializedResources");
        }
    }
}
