using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PassbookManagement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    BirthDay = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdCardNumber = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    SignatureImagePath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    BirthDay = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdCardNumber = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Interest",
                columns: table => new
                {
                    InterestId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    StandardPeriod = table.Column<int>(type: "INTEGER", nullable: false),
                    StandardInterestRate = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interest", x => x.InterestId);
                });

            migrationBuilder.CreateTable(
                name: "LoginAccount",
                columns: table => new
                {
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Decent = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    UserRefId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginAccount", x => x.Username);
                    table.ForeignKey(
                        name: "FK_LoginAccount_Customer_UserRefId",
                        column: x => x.UserRefId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpendingAccount",
                columns: table => new
                {
                    AccountId = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerRefId = table.Column<string>(type: "TEXT", nullable: true),
                    EmployeeRefId = table.Column<string>(type: "TEXT", nullable: true),
                    InterestRate = table.Column<float>(type: "REAL", nullable: false),
                    Balance = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpendingAccount", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_SpendingAccount_Customer_CustomerRefId",
                        column: x => x.CustomerRefId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpendingAccount_Employee_EmployeeRefId",
                        column: x => x.EmployeeRefId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Passbook",
                columns: table => new
                {
                    PassbookId = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerRefId = table.Column<string>(type: "TEXT", nullable: true),
                    EmployeeRefId = table.Column<string>(type: "TEXT", nullable: true),
                    OpenMethod = table.Column<string>(type: "TEXT", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Period = table.Column<int>(type: "INTEGER", nullable: false),
                    InterestRefId = table.Column<string>(type: "TEXT", nullable: true),
                    Balance = table.Column<int>(type: "INTEGER", nullable: false),
                    IsFinalized = table.Column<bool>(type: "INTEGER", nullable: false),
                    SpendingAccountRefId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passbook", x => x.PassbookId);
                    table.ForeignKey(
                        name: "FK_Passbook_Customer_CustomerRefId",
                        column: x => x.CustomerRefId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Passbook_Employee_EmployeeRefId",
                        column: x => x.EmployeeRefId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Passbook_Interest_InterestRefId",
                        column: x => x.InterestRefId,
                        principalTable: "Interest",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Passbook_SpendingAccount_SpendingAccountRefId",
                        column: x => x.SpendingAccountRefId,
                        principalTable: "SpendingAccount",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "TEXT", nullable: false),
                    PassbookRefId = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeRefId = table.Column<string>(type: "TEXT", nullable: true),
                    TransactionMethod = table.Column<string>(type: "TEXT", nullable: true),
                    TransactionType = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    IsViolation = table.Column<bool>(type: "INTEGER", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SpendingAccountRefId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transaction_Employee_EmployeeRefId",
                        column: x => x.EmployeeRefId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_Passbook_PassbookRefId",
                        column: x => x.PassbookRefId,
                        principalTable: "Passbook",
                        principalColumn: "PassbookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_SpendingAccount_SpendingAccountRefId",
                        column: x => x.SpendingAccountRefId,
                        principalTable: "SpendingAccount",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoginAccount_UserRefId",
                table: "LoginAccount",
                column: "UserRefId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passbook_CustomerRefId",
                table: "Passbook",
                column: "CustomerRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Passbook_EmployeeRefId",
                table: "Passbook",
                column: "EmployeeRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Passbook_InterestRefId",
                table: "Passbook",
                column: "InterestRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Passbook_SpendingAccountRefId",
                table: "Passbook",
                column: "SpendingAccountRefId");

            migrationBuilder.CreateIndex(
                name: "IX_SpendingAccount_CustomerRefId",
                table: "SpendingAccount",
                column: "CustomerRefId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpendingAccount_EmployeeRefId",
                table: "SpendingAccount",
                column: "EmployeeRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_EmployeeRefId",
                table: "Transaction",
                column: "EmployeeRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_PassbookRefId",
                table: "Transaction",
                column: "PassbookRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_SpendingAccountRefId",
                table: "Transaction",
                column: "SpendingAccountRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginAccount");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Passbook");

            migrationBuilder.DropTable(
                name: "Interest");

            migrationBuilder.DropTable(
                name: "SpendingAccount");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
