using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rhea.DAL.Migrations
{
    public partial class AddedtablesReservationEventsFurnitureandFurnitureDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEventType = table.Column<int>(type: "int", nullable: false),
                    IdEventStatus = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_events_event_statuses_IdEventStatus",
                        column: x => x.IdEventStatus,
                        principalTable: "event_statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_events_event_types_IdEventType",
                        column: x => x.IdEventType,
                        principalTable: "event_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "furnitures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFurnitureStatus = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_furnitures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_furnitures_furniture_statuses_IdFurnitureStatus",
                        column: x => x.IdFurnitureStatus,
                        principalTable: "furniture_statuses",
                        principalColumn: "Id",
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
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reservation_events_id_event",
                        column: x => x.id_event,
                        principalTable: "events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservation_reservation_statuses_id_reservation_status",
                        column: x => x.id_reservation_status,
                        principalTable: "reservation_statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservation_users_id_user",
                        column: x => x.id_user,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "furniture_details",
                columns: table => new
                {
                    IdReservation = table.Column<int>(type: "int", nullable: false),
                    IdFurniture = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_furniture_details", x => new { x.IdReservation, x.IdFurniture });
                    table.ForeignKey(
                        name: "FK_furniture_details_furnitures_IdFurniture",
                        column: x => x.IdFurniture,
                        principalTable: "furnitures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_furniture_details_reservation_IdReservation",
                        column: x => x.IdReservation,
                        principalTable: "reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_events_IdEventStatus",
                table: "events",
                column: "IdEventStatus");

            migrationBuilder.CreateIndex(
                name: "IX_events_IdEventType",
                table: "events",
                column: "IdEventType");

            migrationBuilder.CreateIndex(
                name: "IX_furniture_details_IdFurniture",
                table: "furniture_details",
                column: "IdFurniture");

            migrationBuilder.CreateIndex(
                name: "IX_furnitures_IdFurnitureStatus",
                table: "furnitures",
                column: "IdFurnitureStatus");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "furniture_details");

            migrationBuilder.DropTable(
                name: "furnitures");

            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.DropTable(
                name: "events");
        }
    }
}
