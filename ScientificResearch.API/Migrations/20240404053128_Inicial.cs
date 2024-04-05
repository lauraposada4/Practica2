using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScientificResearch.API.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
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
                name: "InvestigatorScientificInvestigation",
                columns: table => new
                {
                    InvestigatorsId = table.Column<int>(type: "int", nullable: false),
                    ScientificInvestigationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigatorScientificInvestigation", x => new { x.InvestigatorsId, x.ScientificInvestigationsId });
                    table.ForeignKey(
                        name: "FK_InvestigatorScientificInvestigation_Investigators_InvestigatorsId",
                        column: x => x.InvestigatorsId,
                        principalTable: "Investigators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvestigatorScientificInvestigation_ScientificInvestigations_ScientificInvestigationsId",
                        column: x => x.ScientificInvestigationsId,
                        principalTable: "ScientificInvestigations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScientificInvestigationsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.id);
                    table.ForeignKey(
                        name: "FK_Publications_ScientificInvestigations_ScientificInvestigationsId",
                        column: x => x.ScientificInvestigationsId,
                        principalTable: "ScientificInvestigations",
                        principalColumn: "Id");
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
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScientificInvestigationsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_searchActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_searchActivities_ScientificInvestigations_ScientificInvestigationsId",
                        column: x => x.ScientificInvestigationsId,
                        principalTable: "ScientificInvestigations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "specializedResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    supplier = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    deliveyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScientificInvestigationsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specializedResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_specializedResources_ScientificInvestigations_ScientificInvestigationsId",
                        column: x => x.ScientificInvestigationsId,
                        principalTable: "ScientificInvestigations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "searchActivityspecializedResource",
                columns: table => new
                {
                    SearchActivitiesId = table.Column<int>(type: "int", nullable: false),
                    SpecializedResourcesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_searchActivityspecializedResource", x => new { x.SearchActivitiesId, x.SpecializedResourcesId });
                    table.ForeignKey(
                        name: "FK_searchActivityspecializedResource_searchActivities_SearchActivitiesId",
                        column: x => x.SearchActivitiesId,
                        principalTable: "searchActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_searchActivityspecializedResource_specializedResources_SpecializedResourcesId",
                        column: x => x.SpecializedResourcesId,
                        principalTable: "specializedResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestigatorScientificInvestigation_ScientificInvestigationsId",
                table: "InvestigatorScientificInvestigation",
                column: "ScientificInvestigationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_ScientificInvestigationsId",
                table: "Publications",
                column: "ScientificInvestigationsId");

            migrationBuilder.CreateIndex(
                name: "IX_searchActivities_ScientificInvestigationsId",
                table: "searchActivities",
                column: "ScientificInvestigationsId");

            migrationBuilder.CreateIndex(
                name: "IX_searchActivityspecializedResource_SpecializedResourcesId",
                table: "searchActivityspecializedResource",
                column: "SpecializedResourcesId");

            migrationBuilder.CreateIndex(
                name: "IX_specializedResources_ScientificInvestigationsId",
                table: "specializedResources",
                column: "ScientificInvestigationsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestigatorScientificInvestigation");

            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropTable(
                name: "searchActivityspecializedResource");

            migrationBuilder.DropTable(
                name: "Investigators");

            migrationBuilder.DropTable(
                name: "searchActivities");

            migrationBuilder.DropTable(
                name: "specializedResources");

            migrationBuilder.DropTable(
                name: "ScientificInvestigations");
        }
    }
}
