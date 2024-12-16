using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportTracker.Migrations
{
    public partial class AddFileNamesToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: 1000,
                column: "FileName",
                value: "LAX.png");

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: 1001,
                column: "FileName",
                value: "SEA.png");

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: 1002,
                column: "FileName",
                value: "LNK.png");

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: 1003,
                column: "FileName",
                value: "OMA.png");

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: 1004,
                column: "FileName",
                value: "JFK.png");

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: 1005,
                column: "FileName",
                value: "EWR.png");

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: 1006,
                column: "FileName",
                value: "MIA.png");

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: 1007,
                column: "FileName",
                value: "IAD.png");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 1,
                column: "TakeOff",
                value: new DateTime(2024, 11, 21, 1, 26, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 2,
                column: "TakeOff",
                value: new DateTime(2024, 11, 21, 2, 26, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 3,
                column: "TakeOff",
                value: new DateTime(2024, 11, 21, 3, 26, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 4,
                column: "TakeOff",
                value: new DateTime(2024, 11, 21, 4, 26, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 5,
                column: "TakeOff",
                value: new DateTime(2024, 11, 21, 5, 26, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 6,
                column: "TakeOff",
                value: new DateTime(2024, 11, 21, 6, 26, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 7,
                column: "TakeOff",
                value: new DateTime(2024, 11, 21, 7, 26, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 8,
                column: "TakeOff",
                value: new DateTime(2024, 11, 21, 8, 26, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 9,
                column: "TakeOff",
                value: new DateTime(2024, 11, 21, 9, 26, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 10,
                column: "TakeOff",
                value: new DateTime(2024, 11, 21, 10, 26, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 11,
                column: "TakeOff",
                value: new DateTime(2024, 11, 21, 11, 26, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 12,
                column: "TakeOff",
                value: new DateTime(2024, 11, 21, 12, 26, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 13,
                column: "TakeOff",
                value: new DateTime(2024, 11, 21, 13, 26, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 14,
                column: "TakeOff",
                value: new DateTime(2024, 11, 21, 14, 26, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 15,
                column: "TakeOff",
                value: new DateTime(2024, 11, 21, 15, 26, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 16,
                column: "TakeOff",
                value: new DateTime(2024, 11, 21, 16, 26, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 17,
                column: "TakeOff",
                value: new DateTime(2024, 11, 21, 17, 26, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 18,
                column: "TakeOff",
                value: new DateTime(2024, 11, 21, 18, 26, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 19,
                column: "TakeOff",
                value: new DateTime(2024, 11, 21, 19, 26, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 20,
                column: "TakeOff",
                value: new DateTime(2024, 11, 21, 20, 26, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: 1000,
                column: "FileName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: 1001,
                column: "FileName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: 1002,
                column: "FileName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: 1003,
                column: "FileName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: 1004,
                column: "FileName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: 1005,
                column: "FileName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: 1006,
                column: "FileName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Airports",
                keyColumn: "AirportId",
                keyValue: 1007,
                column: "FileName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 1,
                column: "TakeOff",
                value: new DateTime(2024, 11, 20, 0, 55, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 2,
                column: "TakeOff",
                value: new DateTime(2024, 11, 20, 1, 55, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 3,
                column: "TakeOff",
                value: new DateTime(2024, 11, 20, 2, 55, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 4,
                column: "TakeOff",
                value: new DateTime(2024, 11, 20, 3, 55, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 5,
                column: "TakeOff",
                value: new DateTime(2024, 11, 20, 4, 55, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 6,
                column: "TakeOff",
                value: new DateTime(2024, 11, 20, 5, 55, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 7,
                column: "TakeOff",
                value: new DateTime(2024, 11, 20, 6, 55, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 8,
                column: "TakeOff",
                value: new DateTime(2024, 11, 20, 7, 55, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 9,
                column: "TakeOff",
                value: new DateTime(2024, 11, 20, 8, 55, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 10,
                column: "TakeOff",
                value: new DateTime(2024, 11, 20, 9, 55, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 11,
                column: "TakeOff",
                value: new DateTime(2024, 11, 20, 10, 55, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 12,
                column: "TakeOff",
                value: new DateTime(2024, 11, 20, 11, 55, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 13,
                column: "TakeOff",
                value: new DateTime(2024, 11, 20, 12, 55, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 14,
                column: "TakeOff",
                value: new DateTime(2024, 11, 20, 13, 55, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 15,
                column: "TakeOff",
                value: new DateTime(2024, 11, 20, 14, 55, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 16,
                column: "TakeOff",
                value: new DateTime(2024, 11, 20, 15, 55, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 17,
                column: "TakeOff",
                value: new DateTime(2024, 11, 20, 16, 55, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 18,
                column: "TakeOff",
                value: new DateTime(2024, 11, 20, 17, 55, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 19,
                column: "TakeOff",
                value: new DateTime(2024, 11, 20, 18, 55, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "FlightId",
                keyValue: 20,
                column: "TakeOff",
                value: new DateTime(2024, 11, 20, 19, 55, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
