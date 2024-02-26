using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenApi.Migrations
{
    public partial class UpdateSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DatePlanted",
                table: "Seeds",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Seeds",
                keyColumn: "SeedId",
                keyValue: 1,
                column: "DatePlanted",
                value: "2-14-2024");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DatePlanted",
                table: "Seeds",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Seeds",
                keyColumn: "SeedId",
                keyValue: 1,
                column: "DatePlanted",
                value: new DateOnly(2024, 2, 14));
        }
    }
}
