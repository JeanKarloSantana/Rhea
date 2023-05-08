using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rhea.DAL.Migrations
{
    public partial class Firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "event_statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "event_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "furniture_statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_furniture_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "reservation_statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_event_type = table.Column<int>(type: "int", nullable: false),
                    id_event_status = table.Column<int>(type: "int", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.id);
                    table.ForeignKey(
                        name: "FK_events_event_statuses_id_event_status",
                        column: x => x.id_event_status,
                        principalTable: "event_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_events_event_types_id_event_type",
                        column: x => x.id_event_type,
                        principalTable: "event_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "furnitures",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_furniture_status = table.Column<int>(type: "int", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_furnitures", x => x.id);
                    table.ForeignKey(
                        name: "FK_furnitures_furniture_statuses_id_furniture_status",
                        column: x => x.id_furniture_status,
                        principalTable: "furniture_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user_type = table.Column<int>(type: "int", nullable: false),
                    id_user_status = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_user_statuses_id_user_status",
                        column: x => x.id_user_status,
                        principalTable: "user_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_user_types_id_user_type",
                        column: x => x.id_user_type,
                        principalTable: "user_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    normalized_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.id);
                    table.ForeignKey(
                        name: "FK_companies_users_id",
                        column: x => x.id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    normalized_first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    normalized_last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.id);
                    table.ForeignKey(
                        name: "FK_persons_users_id",
                        column: x => x.id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    id_event = table.Column<int>(type: "int", nullable: false),
                    id_reservation_status = table.Column<int>(type: "int", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    start_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reservation_events_id_event",
                        column: x => x.id_event,
                        principalTable: "events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservation_reservation_statuses_id_reservation_status",
                        column: x => x.id_reservation_status,
                        principalTable: "reservation_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservation_users_id_user",
                        column: x => x.id_user,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "furniture_details",
                columns: table => new
                {
                    id_reservation = table.Column<int>(type: "int", nullable: false),
                    id_furniture = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_furniture_details", x => new { x.id_reservation, x.id_furniture });
                    table.ForeignKey(
                        name: "FK_furniture_details_furnitures_id_furniture",
                        column: x => x.id_furniture,
                        principalTable: "furnitures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_furniture_details_reservation_id_reservation",
                        column: x => x.id_reservation,
                        principalTable: "reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_events_id_event_status",
                table: "events",
                column: "id_event_status");

            migrationBuilder.CreateIndex(
                name: "IX_events_id_event_type",
                table: "events",
                column: "id_event_type");

            migrationBuilder.CreateIndex(
                name: "IX_furniture_details_id_furniture",
                table: "furniture_details",
                column: "id_furniture");

            migrationBuilder.CreateIndex(
                name: "IX_furnitures_id_furniture_status",
                table: "furnitures",
                column: "id_furniture_status");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_id_event",
                table: "reservation",
                column: "id_event");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_id_reservation_status",
                table: "reservation",
                column: "id_reservation_status");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_id_user",
                table: "reservation",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_users_id_user_status",
                table: "users",
                column: "id_user_status");

            migrationBuilder.CreateIndex(
                name: "IX_users_id_user_type",
                table: "users",
                column: "id_user_type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "furniture_details");

            migrationBuilder.DropTable(
                name: "persons");

            migrationBuilder.DropTable(
                name: "furnitures");

            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.DropTable(
                name: "furniture_statuses");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "reservation_statuses");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "event_statuses");

            migrationBuilder.DropTable(
                name: "event_types");

            migrationBuilder.DropTable(
                name: "user_statuses");

            migrationBuilder.DropTable(
                name: "user_types");
        }
    }
}
