using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.EFCoreMigrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentGroups",
                columns: table => new
                {
                    DocumentGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentGroups", x => x.DocumentGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamId);
                });

            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    JobTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.JobTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "JobPostings",
                columns: table => new
                {
                    JobPostingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    JobTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPostings", x => x.JobPostingId);
                    table.ForeignKey(
                        name: "FK_JobPostings_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "JobTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobTypeDocuments",
                columns: table => new
                {
                    JobTypeDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    JobTypeId = table.Column<int>(type: "int", nullable: false),
                    DocumentGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypeDocuments", x => x.JobTypeDocumentId);
                    table.ForeignKey(
                        name: "FK_JobTypeDocuments_DocumentGroups_DocumentGroupId",
                        column: x => x.DocumentGroupId,
                        principalTable: "DocumentGroups",
                        principalColumn: "DocumentGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobTypeDocuments_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "JobTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PositionExams",
                columns: table => new
                {
                    PositionExamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    MinResult = table.Column<double>(type: "float", nullable: false),
                    Multiplier = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionExams", x => x.PositionExamId);
                    table.ForeignKey(
                        name: "FK_PositionExams_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionExams_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PositionSpecificDocuments",
                columns: table => new
                {
                    PositionSpecificDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionSpecificDocuments", x => x.PositionSpecificDocumentId);
                    table.ForeignKey(
                        name: "FK_PositionSpecificDocuments_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobPostingDetails",
                columns: table => new
                {
                    JobPostingDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkedDestination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositonId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    JobPostingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPostingDetails", x => x.JobPostingDetailId);
                    table.ForeignKey(
                        name: "FK_JobPostingDetails_JobPostings_JobPostingId",
                        column: x => x.JobPostingId,
                        principalTable: "JobPostings",
                        principalColumn: "JobPostingId");
                    table.ForeignKey(
                        name: "FK_JobPostingDetails_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobPostingDetails_JobPostingId",
                table: "JobPostingDetails",
                column: "JobPostingId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPostingDetails_PositionId",
                table: "JobPostingDetails",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPostings_JobTypeId",
                table: "JobPostings",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTypeDocuments_DocumentGroupId",
                table: "JobTypeDocuments",
                column: "DocumentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTypeDocuments_JobTypeId",
                table: "JobTypeDocuments",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionExams_ExamId",
                table: "PositionExams",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionExams_PositionId",
                table: "PositionExams",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionSpecificDocuments_PositionId",
                table: "PositionSpecificDocuments",
                column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobPostingDetails");

            migrationBuilder.DropTable(
                name: "JobTypeDocuments");

            migrationBuilder.DropTable(
                name: "PositionExams");

            migrationBuilder.DropTable(
                name: "PositionSpecificDocuments");

            migrationBuilder.DropTable(
                name: "JobPostings");

            migrationBuilder.DropTable(
                name: "DocumentGroups");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "JobTypes");
        }
    }
}
