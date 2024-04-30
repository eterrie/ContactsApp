using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactsApp.WebApplication.Migrations
{
    /// <inheritdoc />
    public partial class DefaultValueChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Counteragents",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 8, 41, 27, 736, DateTimeKind.Utc).AddTicks(2883),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 30, 8, 15, 42, 104, DateTimeKind.Utc).AddTicks(6497));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Counteragents",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 8, 41, 27, 736, DateTimeKind.Utc).AddTicks(1737),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Contacts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 8, 41, 27, 735, DateTimeKind.Utc).AddTicks(9741),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Contacts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 8, 41, 27, 735, DateTimeKind.Utc).AddTicks(7912),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Counteragents",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 8, 15, 42, 104, DateTimeKind.Utc).AddTicks(6497),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 30, 8, 41, 27, 736, DateTimeKind.Utc).AddTicks(2883));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Counteragents",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 30, 8, 41, 27, 736, DateTimeKind.Utc).AddTicks(1737));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Contacts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 30, 8, 41, 27, 735, DateTimeKind.Utc).AddTicks(9741));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Contacts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 30, 8, 41, 27, 735, DateTimeKind.Utc).AddTicks(7912));
        }
    }
}
