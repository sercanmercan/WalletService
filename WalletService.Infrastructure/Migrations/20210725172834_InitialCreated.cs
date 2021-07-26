using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletService.Infrastructure.Migrations
{
    public partial class InitialCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    senderBalance = table.Column<double>(type: "float", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false),
                    detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    senderUserId = table.Column<int>(type: "int", nullable: false),
                    receiverUserId = table.Column<int>(type: "int", nullable: false),
                    senderWalletId = table.Column<int>(type: "int", nullable: false),
                    receiverWalletId = table.Column<int>(type: "int", nullable: false),
                    senderCustomerNo = table.Column<long>(type: "bigint", nullable: false),
                    receiverCustomerNo = table.Column<long>(type: "bigint", nullable: false),
                    senderCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    receiverCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    tcNo = table.Column<long>(type: "bigint", nullable: false),
                    customerNo = table.Column<long>(type: "bigint", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usersId = table.Column<int>(type: "int", nullable: false),
                    balance = table.Column<double>(type: "float", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    walletType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Wallets");
        }
    }
}
