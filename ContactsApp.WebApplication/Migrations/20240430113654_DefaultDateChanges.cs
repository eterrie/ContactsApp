using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactsApp.WebApplication.Migrations
{
    /// <inheritdoc />
    public partial class DefaultDateChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Counteragents",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 30, 9, 26, 41, 759, DateTimeKind.Utc).AddTicks(6792));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Counteragents",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 30, 9, 26, 41, 759, DateTimeKind.Utc).AddTicks(5915));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Contacts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 30, 9, 26, 41, 759, DateTimeKind.Utc).AddTicks(4274));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Contacts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 30, 9, 26, 41, 759, DateTimeKind.Utc).AddTicks(3052));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Counteragents",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 9, 26, 41, 759, DateTimeKind.Utc).AddTicks(6792),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Counteragents",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 9, 26, 41, 759, DateTimeKind.Utc).AddTicks(5915),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Contacts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 9, 26, 41, 759, DateTimeKind.Utc).AddTicks(4274),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Contacts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 9, 26, 41, 759, DateTimeKind.Utc).AddTicks(3052),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");
        }
    }
}
