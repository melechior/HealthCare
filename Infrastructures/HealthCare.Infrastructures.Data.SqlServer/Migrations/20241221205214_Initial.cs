using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Infrastructures.Data.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ContractInfoId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TotalPersonage = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    CompletedFile = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    FileNotSend = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    FileSent = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    FileDefect = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DamageFiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ReceiverUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptNumber = table.Column<long>(type: "bigint", nullable: true),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMan = table.Column<bool>(type: "bit", nullable: true),
                    BirthCertificateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InsuranceCoding = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    ImageAddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    JobPosition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractOfPeople",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ContractId = table.Column<long>(type: "bigint", nullable: false),
                    PersonageId = table.Column<long>(type: "bigint", nullable: false),
                    MainPersonageId = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Relative = table.Column<int>(type: "int", nullable: false),
                    Leader = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "عمومی"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractOfPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractOfPeople_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractOfPeople_Personages_MainPersonageId",
                        column: x => x.MainPersonageId,
                        principalTable: "Personages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractOfPeople_Personages_PersonageId",
                        column: x => x.PersonageId,
                        principalTable: "Personages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DamageFileDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    DamageFileId = table.Column<long>(type: "bigint", nullable: false),
                    ContractOfPersonId = table.Column<long>(type: "bigint", nullable: false),
                    DamageItem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendToInsuranceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsuranceReceiptNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamageFileState = table.Column<int>(type: "int", nullable: false),
                    RequestedAmount = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    DamageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageFileDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DamageFileDetails_ContractOfPeople_ContractOfPersonId",
                        column: x => x.ContractOfPersonId,
                        principalTable: "ContractOfPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DamageFileDetails_DamageFiles_DamageFileId",
                        column: x => x.DamageFileId,
                        principalTable: "DamageFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "Email", "FirstName", "ImageAddress", "IsActive", "IsAdmin", "JobPosition", "LastName", "ModifyDate", "NationalId", "Password", "Username" },
                values: new object[] { 1L, new DateTime(2024, 12, 21, 0, 0, 0, 0, DateTimeKind.Local), "alirezammn@yahoo.com", "علیرضا", null, true, true, "مدیریت سیستم", "مومنی", null, "0067052207", "J@farjo0n", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_ContractOfPeople_ContractId",
                table: "ContractOfPeople",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractOfPeople_MainPersonageId",
                table: "ContractOfPeople",
                column: "MainPersonageId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractOfPeople_PersonageId",
                table: "ContractOfPeople",
                column: "PersonageId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageFileDetails_ContractOfPersonId",
                table: "DamageFileDetails",
                column: "ContractOfPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageFileDetails_DamageFileId",
                table: "DamageFileDetails",
                column: "DamageFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Personages_NationalId",
                table: "Personages",
                column: "NationalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DamageFileDetails");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ContractOfPeople");

            migrationBuilder.DropTable(
                name: "DamageFiles");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Personages");
        }
    }
}
