using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppLoanMSAPIConnect.Migrations
{
    public partial class FinalMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BorrowerInformation",
                columns: table => new
                {
                    BorrowerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    Contact = table.Column<string>(maxLength: 10, nullable: false),
                    Dob = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: false),
                    IdentityType = table.Column<string>(nullable: false),
                    IdentityId = table.Column<string>(nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowerInformation", x => x.BorrowerId);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Full_Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNameOrEmail = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Confirm_Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyInformation",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanType = table.Column<string>(maxLength: 20, nullable: false),
                    LoanPurpose = table.Column<string>(nullable: false),
                    RequestAmount = table.Column<double>(nullable: false),
                    LoanTenure = table.Column<int>(nullable: false),
                    BorrowerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyInformation", x => x.ApplicantId);
                    table.ForeignKey(
                        name: "FK_PropertyInformation_BorrowerInformation_BorrowerId",
                        column: x => x.BorrowerId,
                        principalTable: "BorrowerInformation",
                        principalColumn: "BorrowerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegalDocuments",
                columns: table => new
                {
                    ApplicationNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyProof = table.Column<string>(maxLength: 50, nullable: true),
                    BankSalarySlip = table.Column<string>(maxLength: 50, nullable: false),
                    AddressProof = table.Column<string>(maxLength: 50, nullable: false),
                    GuarantorName = table.Column<string>(maxLength: 50, nullable: false),
                    GuarantorProofType = table.Column<string>(maxLength: 50, nullable: false),
                    GuarantorProofId = table.Column<string>(maxLength: 50, nullable: false),
                    ApplicantId = table.Column<int>(nullable: false),
                    PropertyApplicantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalDocuments", x => x.ApplicationNo);
                    table.ForeignKey(
                        name: "FK_LegalDocuments_PropertyInformation_PropertyApplicantId",
                        column: x => x.PropertyApplicantId,
                        principalTable: "PropertyInformation",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "UserDetails",
                columns: new[] { "Id", "Confirm_Password", "Password", "UserNameOrEmail" },
                values: new object[] { 1, null, "A@123", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_LegalDocuments_PropertyApplicantId",
                table: "LegalDocuments",
                column: "PropertyApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyInformation_BorrowerId",
                table: "PropertyInformation",
                column: "BorrowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "LegalDocuments");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "PropertyInformation");

            migrationBuilder.DropTable(
                name: "BorrowerInformation");
        }
    }
}
