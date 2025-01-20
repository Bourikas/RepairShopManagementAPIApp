using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairShopManagementAPIApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRSTNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LASTNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PRIMARY_PHONE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SECONDARY_PHONE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ADDRESS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NOTES = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRSTNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LASTNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DEVICES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SERIAL_NUMBER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MAKER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MODEL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DEVICE_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DATE_OF_PURCHASE = table.Column<DateOnly>(type: "date", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEVICES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CUSTOMERS_DEVICES",
                        column: x => x.CustomerID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SERVICE_ENTRY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    DATE_TIME_OF_ENTRY = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PROBLEM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DAMAGES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ESTIMATED_PRICE = table.Column<double>(type: "float", nullable: true),
                    PARTS_USED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATE_OF_SERVICE_START = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DATE_OF_SERVICE_END = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FINAL_PRICE = table.Column<double>(type: "float", nullable: true),
                    DEPOSIT = table.Column<double>(type: "float", nullable: true),
                    DATE_OF_RETURN = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NOTES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_RETURNED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICE_ENTRY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DEVICES_DEVICE_ENTRIES",
                        column: x => x.DeviceId,
                        principalTable: "DEVICES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DEVICES_CustomerID",
                table: "DEVICES",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICE_ENTRY_DeviceId",
                table: "SERVICE_ENTRY",
                column: "DeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SERVICE_ENTRY");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "DEVICES");

            migrationBuilder.DropTable(
                name: "CUSTOMERS");
        }
    }
}
