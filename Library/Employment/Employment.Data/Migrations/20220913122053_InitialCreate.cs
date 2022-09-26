using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Employment.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    EmployerId = table.Column<int>(type: "int", nullable: false),
                    PayRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    PayPeriod = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PayType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployerId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    RoleName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    PayRate = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    PayPeriod = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PayType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    BreakInMinutes = table.Column<int>(type: "int", nullable: false),
                    RecordedStartDateTime = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    RecordedEndDateTime = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    RecordedBreakInMinutes = table.Column<int>(type: "int", nullable: false),
                    IsProspective = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shifts_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shifts_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employers_Id",
                table: "Employers",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_EmployerId",
                table: "Roles",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Id",
                table: "Roles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_EmployerId",
                table: "Shifts",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_Id",
                table: "Shifts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_RoleId",
                table: "Shifts",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Employers");
        }
    }
}
