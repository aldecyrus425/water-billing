using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Latest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingMonth",
                table: "MeterReadings");

            migrationBuilder.AddColumn<decimal>(
                name: "AmountTendered",
                table: "Payments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "MeterReadings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "BillingMonthId",
                table: "MeterReadings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WaterMeterSerialNum",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BillingMonths",
                columns: table => new
                {
                    BillingMonthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingMonths", x => x.BillingMonthId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeterReadings_BillingMonthId",
                table: "MeterReadings",
                column: "BillingMonthId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeterReadings_BillingMonths_BillingMonthId",
                table: "MeterReadings",
                column: "BillingMonthId",
                principalTable: "BillingMonths",
                principalColumn: "BillingMonthId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeterReadings_BillingMonths_BillingMonthId",
                table: "MeterReadings");

            migrationBuilder.DropTable(
                name: "BillingMonths");

            migrationBuilder.DropIndex(
                name: "IX_MeterReadings_BillingMonthId",
                table: "MeterReadings");

            migrationBuilder.DropColumn(
                name: "AmountTendered",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "BillingMonthId",
                table: "MeterReadings");

            migrationBuilder.DropColumn(
                name: "WaterMeterSerialNum",
                table: "Bills");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "MeterReadings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingMonth",
                table: "MeterReadings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
