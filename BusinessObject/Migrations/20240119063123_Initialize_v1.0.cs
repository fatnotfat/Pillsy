using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class Initialize_v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPackage",
                columns: table => new
                {
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<float>(type: "real", nullable: false),
                    CurrencyUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPackage", x => x.PackageId);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    DoctorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.DoctorID);
                    table.ForeignKey(
                        name: "FK_Doctor_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_Patient_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patient_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "PaymentId");
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    AppointmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.AppointmentID);
                    table.ForeignKey(
                        name: "FK_Appointment_Doctor_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID");
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    PrescriptionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExaminationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.PrescriptionID);
                    table.ForeignKey(
                        name: "FK_Prescription_Doctor_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID");
                    table.ForeignKey(
                        name: "FK_Prescription_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistory",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SubscriptionPackagePackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistory", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_TransactionHistory_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionHistory_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionHistory_SubscriptionPackage_SubscriptionPackagePackageId",
                        column: x => x.SubscriptionPackagePackageId,
                        principalTable: "SubscriptionPackage",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pill",
                columns: table => new
                {
                    PillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PillName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PillDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DosagePerDay = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    QuantityPerDose = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Morning = table.Column<int>(type: "int", nullable: false),
                    Afternoon = table.Column<int>(type: "int", nullable: false),
                    Evening = table.Column<int>(type: "int", nullable: false),
                    PrescriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pill", x => x.PillId);
                    table.ForeignKey(
                        name: "FK_Pill_Prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescription",
                        principalColumn: "PrescriptionID");
                    table.ForeignKey(
                        name: "FK_Pill_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "CreatedBy", "CreatedDate", "Email", "LastModifiedDate", "ModifiedBy", "Password", "Role", "Status" },
                values: new object[,]
                {
                    { new Guid("5fcc8b0e-4969-407b-9db0-6e01490500fd"), null, new DateTime(2024, 1, 19, 6, 31, 23, 263, DateTimeKind.Utc).AddTicks(5957), "dungnvse160223@fpt.edu.vn", new DateTime(2024, 1, 19, 6, 31, 23, 263, DateTimeKind.Utc).AddTicks(5958), null, "@@patient@@", 2, 1 },
                    { new Guid("8ad40f75-c57a-4fec-98c2-ef229ddbe571"), null, new DateTime(2024, 1, 19, 6, 31, 23, 263, DateTimeKind.Utc).AddTicks(6023), "khoatruong2509@fpt.edu.vn", new DateTime(2024, 1, 19, 6, 31, 23, 263, DateTimeKind.Utc).AddTicks(6023), null, "@@doctor@@", 1, 1 },
                    { new Guid("f52a1617-1265-4054-80f2-649e43b87b89"), null, new DateTime(2024, 1, 19, 6, 31, 23, 263, DateTimeKind.Utc).AddTicks(5950), "nguyenphat2711@gmail.com", new DateTime(2024, 1, 19, 6, 31, 23, 263, DateTimeKind.Utc).AddTicks(5954), null, "@@admin@@", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "PaymentId", "CreatedBy", "CreatedDate", "LastModifiedDate", "ModifiedBy", "PaymentType", "Status" },
                values: new object[] { new Guid("96eb0644-ce19-4ebe-9b6d-481f6720560e"), null, new DateTime(2024, 1, 19, 6, 31, 23, 263, DateTimeKind.Utc).AddTicks(6184), new DateTime(2024, 1, 19, 6, 31, 23, 263, DateTimeKind.Utc).AddTicks(6185), null, "Momo", 0 });

            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "ScheduleId", "CreatedBy", "CreatedDate", "DateEnd", "DateStart", "LastModifiedDate", "ModifiedBy", "Notes", "Status" },
                values: new object[] { new Guid("be9b3d2e-e848-48ae-acdb-7c1398c0d502"), new Guid("5fcc8b0e-4969-407b-9db0-6e01490500fd"), new DateTime(2024, 1, 19, 6, 31, 23, 263, DateTimeKind.Utc).AddTicks(6477), new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 19, 6, 31, 23, 263, DateTimeKind.Utc).AddTicks(6461), new DateTime(2024, 1, 19, 6, 31, 23, 263, DateTimeKind.Utc).AddTicks(6478), new Guid("5fcc8b0e-4969-407b-9db0-6e01490500fd"), "Dung 3 lieu, moi ngay 1 lieu", 1 });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "DoctorID", "AccountId", "CreatedBy", "CreatedDate", "FirstName", "LastModifiedDate", "LastName", "ModifiedBy", "PhoneNumber", "Specialty" },
                values: new object[] { new Guid("162fb2ec-d66a-41d1-9f2f-d6a352600a5e"), new Guid("8ad40f75-c57a-4fec-98c2-ef229ddbe571"), new Guid("8ad40f75-c57a-4fec-98c2-ef229ddbe571"), new DateTime(2024, 1, 19, 6, 31, 23, 263, DateTimeKind.Utc).AddTicks(6202), "Khoa", new DateTime(2024, 1, 19, 6, 31, 23, 263, DateTimeKind.Utc).AddTicks(6203), "Truong", new Guid("8ad40f75-c57a-4fec-98c2-ef229ddbe571"), "0987654321", "Khoa noi" });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "PatientID", "AccountId", "Address", "CreatedBy", "CreatedDate", "DateOfBirth", "FirstName", "Gender", "LastModifiedDate", "LastName", "ModifiedBy", "PaymentId", "PhoneNumber" },
                values: new object[] { new Guid("82babafb-13af-4a17-82f4-70cf44487c35"), new Guid("5fcc8b0e-4969-407b-9db0-6e01490500fd"), "Bac Ninh", new Guid("5fcc8b0e-4969-407b-9db0-6e01490500fd"), new DateTime(2024, 1, 19, 6, 31, 23, 263, DateTimeKind.Utc).AddTicks(6405), new DateTime(2002, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dung", 0, new DateTime(2024, 1, 19, 6, 31, 23, 263, DateTimeKind.Utc).AddTicks(6405), "Nguyen", new Guid("5fcc8b0e-4969-407b-9db0-6e01490500fd"), new Guid("96eb0644-ce19-4ebe-9b6d-481f6720560e"), "0123456789" });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "PrescriptionID", "CreatedBy", "CreatedDate", "Diagnosis", "DoctorID", "ExaminationDate", "Image", "Index", "LastModifiedDate", "ModifiedBy", "PatientID", "Status" },
                values: new object[] { new Guid("52fda784-d359-4af2-80d2-65f8cc655614"), new Guid("5fcc8b0e-4969-407b-9db0-6e01490500fd"), new DateTime(2024, 1, 19, 6, 31, 23, 263, DateTimeKind.Utc).AddTicks(6501), "viem da day", new Guid("162fb2ec-d66a-41d1-9f2f-d6a352600a5e"), new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "test", 1, new DateTime(2024, 1, 19, 6, 31, 23, 263, DateTimeKind.Utc).AddTicks(6501), new Guid("5fcc8b0e-4969-407b-9db0-6e01490500fd"), new Guid("82babafb-13af-4a17-82f4-70cf44487c35"), 1 });

            migrationBuilder.InsertData(
                table: "Pill",
                columns: new[] { "PillId", "Afternoon", "CreatedBy", "CreatedDate", "DosagePerDay", "Evening", "Index", "LastModifiedDate", "ModifiedBy", "Morning", "Period", "PillDescription", "PillName", "PrescriptionId", "Quantity", "QuantityPerDose", "ScheduleId", "Status", "Unit" },
                values: new object[,]
                {
                    { new Guid("5f7ab433-1a11-4f5a-830a-15500aebbaa2"), 0, new Guid("5fcc8b0e-4969-407b-9db0-6e01490500fd"), new DateTime(2024, 1, 19, 6, 31, 23, 263, DateTimeKind.Utc).AddTicks(6519), 1, 0, 1, new DateTime(2024, 1, 19, 6, 31, 23, 263, DateTimeKind.Utc).AddTicks(6519), new Guid("5fcc8b0e-4969-407b-9db0-6e01490500fd"), 1, "ngay", "1 ngay uong 1 vien 30 phut sau khi an", "Nexium mup", new Guid("52fda784-d359-4af2-80d2-65f8cc655614"), 30, 1, new Guid("be9b3d2e-e848-48ae-acdb-7c1398c0d502"), 1, "vien" },
                    { new Guid("f2ae4b54-003a-441e-ba5f-c1ab2c679b94"), 0, new Guid("5fcc8b0e-4969-407b-9db0-6e01490500fd"), new DateTime(2024, 1, 19, 6, 31, 23, 263, DateTimeKind.Utc).AddTicks(6534), 2, 1, 1, new DateTime(2024, 1, 19, 6, 31, 23, 263, DateTimeKind.Utc).AddTicks(6534), new Guid("5fcc8b0e-4969-407b-9db0-6e01490500fd"), 1, "ngay", "1 ngay uong 2 vien chia lam 2 lan(sang, toi - sau khi an)", "Amoxycilin", new Guid("52fda784-d359-4af2-80d2-65f8cc655614"), 20, 1, new Guid("be9b3d2e-e848-48ae-acdb-7c1398c0d502"), 1, "vien" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_Email",
                table: "Account",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DoctorID",
                table: "Appointment",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientID",
                table: "Appointment",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_AccountId",
                table: "Doctor",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_PhoneNumber",
                table: "Doctor",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_AccountId",
                table: "Patient",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PaymentId",
                table: "Patient",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PhoneNumber",
                table: "Patient",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pill_PrescriptionId",
                table: "Pill",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pill_ScheduleId",
                table: "Pill",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_DoctorID",
                table: "Prescription",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_PatientID",
                table: "Prescription",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_PatientId",
                table: "TransactionHistory",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_PaymentId",
                table: "TransactionHistory",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_SubscriptionPackagePackageId",
                table: "TransactionHistory",
                column: "SubscriptionPackagePackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Pill");

            migrationBuilder.DropTable(
                name: "TransactionHistory");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "SubscriptionPackage");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Payment");
        }
    }
}
