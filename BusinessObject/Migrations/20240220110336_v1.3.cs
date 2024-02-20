using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class v13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("dce7c2b2-9c0f-4580-b149-75d1c7a77c34"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2122511e-182b-46d8-be48-1afd70588f8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "484029d5-a0db-413c-b067-ec986fedc50e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "520c9523-10d9-4943-aba1-6e71365d6c1a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ab5a6ab8-4040-4bf5-b96e-a14b07b52cbc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5583a78-05a7-42ab-baff-1b48b27331e8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1b66b48-6616-44f8-9439-74ddaf491d54");

            migrationBuilder.DeleteData(
                table: "Pill",
                keyColumn: "PillId",
                keyValue: new Guid("0bf2a055-8469-461f-9d1c-6caf0e8b2963"));

            migrationBuilder.DeleteData(
                table: "Pill",
                keyColumn: "PillId",
                keyValue: new Guid("4cadafd6-352e-47d9-b72f-a52db93905e4"));

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "PrescriptionID",
                keyValue: new Guid("68b9cd57-f1ee-4fdd-8d4e-ae7c9dd26f05"));

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorID",
                keyValue: new Guid("7b13e85b-ffaa-45de-8abf-56c27a9325c3"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "PatientID",
                keyValue: new Guid("fa1e310b-e670-4f58-afb2-1692e529e668"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("29c0fbbb-17a4-4cb6-9f2c-5d7e7d203bcb"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("b8006249-0d37-48c6-8170-f575b6e91579"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("1fd1c951-9be5-4fc9-9437-04052c9174fc"));

            migrationBuilder.AddColumn<Guid>(
                name: "PillManagerId",
                table: "Pill",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerPackage",
                columns: table => new
                {
                    CustomerPackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerPackageName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    NumberScan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AllowPillHistory = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubcriptionPackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionPackagePackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPackage", x => x.CustomerPackageId);
                    table.ForeignKey(
                        name: "FK_CustomerPackage_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                    table.ForeignKey(
                        name: "FK_CustomerPackage_SubscriptionPackage_SubscriptionPackagePackageId",
                        column: x => x.SubscriptionPackagePackageId,
                        principalTable: "SubscriptionPackage",
                        principalColumn: "PackageId");
                });

            migrationBuilder.CreateTable(
                name: "PillManager",
                columns: table => new
                {
                    PillManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TakenTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PillManager", x => x.PillManagerId);
                    table.ForeignKey(
                        name: "FK_PillManager_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "CreatedBy", "CreatedDate", "Email", "LastModifiedDate", "ModifiedBy", "Password", "Role", "Status" },
                values: new object[,]
                {
                    { new Guid("2a9fd992-cba4-4126-98f3-8d59e9ec2035"), null, new DateTime(2024, 2, 20, 11, 3, 36, 606, DateTimeKind.Utc).AddTicks(7358), "nguyenphat2711@gmail.com", new DateTime(2024, 2, 20, 11, 3, 36, 606, DateTimeKind.Utc).AddTicks(7362), null, "@@admin@@", 0, 1 },
                    { new Guid("384558d8-2ba3-46c1-bc51-8a45b2b927b9"), null, new DateTime(2024, 2, 20, 11, 3, 36, 606, DateTimeKind.Utc).AddTicks(7367), "khoatruong2509@fpt.edu.vn", new DateTime(2024, 2, 20, 11, 3, 36, 606, DateTimeKind.Utc).AddTicks(7368), null, "@@doctor@@", 1, 1 },
                    { new Guid("e686ce58-34cf-444c-bfc5-500da67ea372"), null, new DateTime(2024, 2, 20, 11, 3, 36, 606, DateTimeKind.Utc).AddTicks(7364), "dungnvse160223@fpt.edu.vn", new DateTime(2024, 2, 20, 11, 3, 36, 606, DateTimeKind.Utc).AddTicks(7365), null, "@@patient@@", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "571a9f2e-9d5b-4d34-b533-1f77b65d2776", "2", "Doctor", "Doctor" },
                    { "a71ea449-dc03-4f4a-bdde-b2e3d13f165a", "1", "Admin", "Admin" },
                    { "dd50b2b8-7bbd-4ac8-b132-3cc5ca590ab3", "3", "Patient", "Patient" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a69838e9-cb69-415d-bbc7-a54f7ac7c6cc", 0, "cefda520-728b-47aa-aac7-975077b9f812", "dungnvse160223@fpt.edu.vn", false, true, null, "DUNGNVSE160223@FPT.EDU.VN", null, null, null, false, "ad1e2de3-f01f-4646-b965-a2eac1b415db", false, "Dung Nguyen" },
                    { "adf216f8-e0b9-4cc8-9c9e-3469a1cf701a", 0, "88898a3e-cf05-415e-b576-b5c607ca0acb", "nguyenphat2711@gmail.com", false, true, null, "NGUYENPHAT2711@GMAIL.COM", null, null, null, false, "cdf0e00e-04e3-43eb-a7eb-78fa5744cf37", false, "Phat Nguyen" },
                    { "e6f09b57-1fdb-4524-a341-433ba711af78", 0, "634c1b63-0743-4e90-8111-d61a2ccb5829", "khoatruong2509@fpt.edu.vn", false, true, null, "KHOATRUONG2509@FPT.EDU.VN", null, null, null, false, "2c09146e-1e2b-4afd-b097-854791aa3285", false, "Khoa Truong" }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "PaymentId", "CreatedBy", "CreatedDate", "LastModifiedDate", "ModifiedBy", "PaymentType", "Status" },
                values: new object[] { new Guid("8689eb95-3fbe-4b91-b023-073312770a76"), null, new DateTime(2024, 2, 20, 11, 3, 36, 606, DateTimeKind.Utc).AddTicks(7587), new DateTime(2024, 2, 20, 11, 3, 36, 606, DateTimeKind.Utc).AddTicks(7588), null, "Smart Banking", 0 });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "DoctorID", "AccountId", "CreatedBy", "CreatedDate", "FirstName", "LastModifiedDate", "LastName", "ModifiedBy", "PhoneNumber", "Specialty" },
                values: new object[] { new Guid("83f58690-fcd7-4361-8e19-3314a0973e52"), new Guid("384558d8-2ba3-46c1-bc51-8a45b2b927b9"), new Guid("384558d8-2ba3-46c1-bc51-8a45b2b927b9"), new DateTime(2024, 2, 20, 11, 3, 36, 606, DateTimeKind.Utc).AddTicks(7604), "Khoa", new DateTime(2024, 2, 20, 11, 3, 36, 606, DateTimeKind.Utc).AddTicks(7605), "Truong", new Guid("384558d8-2ba3-46c1-bc51-8a45b2b927b9"), "0987654321", "Khoa noi" });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "PatientID", "AccountId", "Address", "CreatedBy", "CreatedDate", "DateOfBirth", "FirstName", "Gender", "LastModifiedDate", "LastName", "ModifiedBy", "PaymentId", "PhoneNumber" },
                values: new object[] { new Guid("f6e33c12-2454-435e-973f-569d85e07471"), new Guid("e686ce58-34cf-444c-bfc5-500da67ea372"), "Bac Ninh", new Guid("e686ce58-34cf-444c-bfc5-500da67ea372"), new DateTime(2024, 2, 20, 11, 3, 36, 606, DateTimeKind.Utc).AddTicks(7696), new DateTime(2002, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dung", 0, new DateTime(2024, 2, 20, 11, 3, 36, 606, DateTimeKind.Utc).AddTicks(7696), "Nguyen", new Guid("e686ce58-34cf-444c-bfc5-500da67ea372"), new Guid("8689eb95-3fbe-4b91-b023-073312770a76"), "0123456789" });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "PrescriptionID", "CreatedBy", "CreatedDate", "Diagnosis", "DoctorID", "ExaminationDate", "Image", "ImageBase64", "Index", "LastModifiedDate", "ModifiedBy", "PatientID", "Status" },
                values: new object[] { new Guid("264f8ccc-22f1-4a8c-8152-0fd8aadec25f"), new Guid("e686ce58-34cf-444c-bfc5-500da67ea372"), new DateTime(2024, 2, 20, 11, 3, 36, 606, DateTimeKind.Utc).AddTicks(7716), "viem da day", new Guid("83f58690-fcd7-4361-8e19-3314a0973e52"), new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "test", null, 1, new DateTime(2024, 2, 20, 11, 3, 36, 606, DateTimeKind.Utc).AddTicks(7716), new Guid("e686ce58-34cf-444c-bfc5-500da67ea372"), new Guid("f6e33c12-2454-435e-973f-569d85e07471"), 1 });

            migrationBuilder.InsertData(
                table: "Pill",
                columns: new[] { "PillId", "Afternoon", "CreatedBy", "CreatedDate", "DateEnd", "DateStart", "DosagePerDay", "Evening", "Index", "LastModifiedDate", "ModifiedBy", "Morning", "Period", "PillDescription", "PillManagerId", "PillName", "PrescriptionId", "Quantity", "QuantityPerDose", "Status", "Unit" },
                values: new object[,]
                {
                    { new Guid("9845949c-1fce-4033-878f-b2df3719905e"), 0, new Guid("e686ce58-34cf-444c-bfc5-500da67ea372"), new DateTime(2024, 2, 20, 11, 3, 36, 606, DateTimeKind.Utc).AddTicks(7731), null, null, 1, 0, 1, new DateTime(2024, 2, 20, 11, 3, 36, 606, DateTimeKind.Utc).AddTicks(7731), new Guid("e686ce58-34cf-444c-bfc5-500da67ea372"), 1, "ngay", "1 ngay uong 1 vien 30 phut sau khi an", null, "Nexium mup", new Guid("264f8ccc-22f1-4a8c-8152-0fd8aadec25f"), 30, 1, 1, "vien" },
                    { new Guid("c19b7eb8-dcd4-40f0-bf69-76d59e1d162a"), 0, new Guid("e686ce58-34cf-444c-bfc5-500da67ea372"), new DateTime(2024, 2, 20, 11, 3, 36, 606, DateTimeKind.Utc).AddTicks(7743), null, null, 2, 1, 1, new DateTime(2024, 2, 20, 11, 3, 36, 606, DateTimeKind.Utc).AddTicks(7743), new Guid("e686ce58-34cf-444c-bfc5-500da67ea372"), 1, "ngay", "1 ngay uong 2 vien chia lam 2 lan(sang, toi - sau khi an)", null, "Amoxycilin", new Guid("264f8ccc-22f1-4a8c-8152-0fd8aadec25f"), 20, 1, 1, "vien" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pill_PillManagerId",
                table: "Pill",
                column: "PillManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPackage_PatientId",
                table: "CustomerPackage",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPackage_SubscriptionPackagePackageId",
                table: "CustomerPackage",
                column: "SubscriptionPackagePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PillManager_PatientId",
                table: "PillManager",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pill_PillManager_PillManagerId",
                table: "Pill",
                column: "PillManagerId",
                principalTable: "PillManager",
                principalColumn: "PillManagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pill_PillManager_PillManagerId",
                table: "Pill");

            migrationBuilder.DropTable(
                name: "CustomerPackage");

            migrationBuilder.DropTable(
                name: "PillManager");

            migrationBuilder.DropIndex(
                name: "IX_Pill_PillManagerId",
                table: "Pill");

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("2a9fd992-cba4-4126-98f3-8d59e9ec2035"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "571a9f2e-9d5b-4d34-b533-1f77b65d2776");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a71ea449-dc03-4f4a-bdde-b2e3d13f165a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd50b2b8-7bbd-4ac8-b132-3cc5ca590ab3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a69838e9-cb69-415d-bbc7-a54f7ac7c6cc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adf216f8-e0b9-4cc8-9c9e-3469a1cf701a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6f09b57-1fdb-4524-a341-433ba711af78");

            migrationBuilder.DeleteData(
                table: "Pill",
                keyColumn: "PillId",
                keyValue: new Guid("9845949c-1fce-4033-878f-b2df3719905e"));

            migrationBuilder.DeleteData(
                table: "Pill",
                keyColumn: "PillId",
                keyValue: new Guid("c19b7eb8-dcd4-40f0-bf69-76d59e1d162a"));

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "PrescriptionID",
                keyValue: new Guid("264f8ccc-22f1-4a8c-8152-0fd8aadec25f"));

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorID",
                keyValue: new Guid("83f58690-fcd7-4361-8e19-3314a0973e52"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "PatientID",
                keyValue: new Guid("f6e33c12-2454-435e-973f-569d85e07471"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("384558d8-2ba3-46c1-bc51-8a45b2b927b9"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("e686ce58-34cf-444c-bfc5-500da67ea372"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("8689eb95-3fbe-4b91-b023-073312770a76"));

            migrationBuilder.DropColumn(
                name: "PillManagerId",
                table: "Pill");

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "CreatedBy", "CreatedDate", "Email", "LastModifiedDate", "ModifiedBy", "Password", "Role", "Status" },
                values: new object[,]
                {
                    { new Guid("29c0fbbb-17a4-4cb6-9f2c-5d7e7d203bcb"), null, new DateTime(2024, 2, 2, 10, 18, 25, 794, DateTimeKind.Utc).AddTicks(8266), "khoatruong2509@fpt.edu.vn", new DateTime(2024, 2, 2, 10, 18, 25, 794, DateTimeKind.Utc).AddTicks(8267), null, "@@doctor@@", 1, 1 },
                    { new Guid("b8006249-0d37-48c6-8170-f575b6e91579"), null, new DateTime(2024, 2, 2, 10, 18, 25, 794, DateTimeKind.Utc).AddTicks(8263), "dungnvse160223@fpt.edu.vn", new DateTime(2024, 2, 2, 10, 18, 25, 794, DateTimeKind.Utc).AddTicks(8264), null, "@@patient@@", 2, 1 },
                    { new Guid("dce7c2b2-9c0f-4580-b149-75d1c7a77c34"), null, new DateTime(2024, 2, 2, 10, 18, 25, 794, DateTimeKind.Utc).AddTicks(8256), "nguyenphat2711@gmail.com", new DateTime(2024, 2, 2, 10, 18, 25, 794, DateTimeKind.Utc).AddTicks(8259), null, "@@admin@@", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2122511e-182b-46d8-be48-1afd70588f8c", "3", "Patient", "Patient" },
                    { "484029d5-a0db-413c-b067-ec986fedc50e", "2", "Doctor", "Doctor" },
                    { "520c9523-10d9-4943-aba1-6e71365d6c1a", "1", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "ab5a6ab8-4040-4bf5-b96e-a14b07b52cbc", 0, "4cedc58a-5844-4f58-8dca-0540a63627a0", "dungnvse160223@fpt.edu.vn", false, false, null, null, null, null, null, false, "362df6ef-b2d9-415e-a3e2-6f8be0747359", false, "Dung Nguyen" },
                    { "c5583a78-05a7-42ab-baff-1b48b27331e8", 0, "41867fc6-0738-49d9-a9e8-b575cdf8d87a", "khoatruong2509@fpt.edu.vn", false, false, null, null, null, null, null, false, "04e25c79-621a-4bc2-80c1-cce2940f8f69", false, "Khoa Truong" },
                    { "d1b66b48-6616-44f8-9439-74ddaf491d54", 0, "f6f85075-cff4-4918-bb24-1215d1b816c5", "nguyenphat2711@gmail.com", false, false, null, null, null, null, null, false, "6a2e8cb1-c189-41ca-837c-c1f2939e6b07", false, "Phat Nguyen" }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "PaymentId", "CreatedBy", "CreatedDate", "LastModifiedDate", "ModifiedBy", "PaymentType", "Status" },
                values: new object[] { new Guid("1fd1c951-9be5-4fc9-9437-04052c9174fc"), null, new DateTime(2024, 2, 2, 10, 18, 25, 794, DateTimeKind.Utc).AddTicks(8604), new DateTime(2024, 2, 2, 10, 18, 25, 794, DateTimeKind.Utc).AddTicks(8605), null, "Momo", 0 });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "DoctorID", "AccountId", "CreatedBy", "CreatedDate", "FirstName", "LastModifiedDate", "LastName", "ModifiedBy", "PhoneNumber", "Specialty" },
                values: new object[] { new Guid("7b13e85b-ffaa-45de-8abf-56c27a9325c3"), new Guid("29c0fbbb-17a4-4cb6-9f2c-5d7e7d203bcb"), new Guid("29c0fbbb-17a4-4cb6-9f2c-5d7e7d203bcb"), new DateTime(2024, 2, 2, 10, 18, 25, 794, DateTimeKind.Utc).AddTicks(8629), "Khoa", new DateTime(2024, 2, 2, 10, 18, 25, 794, DateTimeKind.Utc).AddTicks(8630), "Truong", new Guid("29c0fbbb-17a4-4cb6-9f2c-5d7e7d203bcb"), "0987654321", "Khoa noi" });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "PatientID", "AccountId", "Address", "CreatedBy", "CreatedDate", "DateOfBirth", "FirstName", "Gender", "LastModifiedDate", "LastName", "ModifiedBy", "PaymentId", "PhoneNumber" },
                values: new object[] { new Guid("fa1e310b-e670-4f58-afb2-1692e529e668"), new Guid("b8006249-0d37-48c6-8170-f575b6e91579"), "Bac Ninh", new Guid("b8006249-0d37-48c6-8170-f575b6e91579"), new DateTime(2024, 2, 2, 10, 18, 25, 794, DateTimeKind.Utc).AddTicks(8743), new DateTime(2002, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dung", 0, new DateTime(2024, 2, 2, 10, 18, 25, 794, DateTimeKind.Utc).AddTicks(8744), "Nguyen", new Guid("b8006249-0d37-48c6-8170-f575b6e91579"), new Guid("1fd1c951-9be5-4fc9-9437-04052c9174fc"), "0123456789" });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "PrescriptionID", "CreatedBy", "CreatedDate", "Diagnosis", "DoctorID", "ExaminationDate", "Image", "ImageBase64", "Index", "LastModifiedDate", "ModifiedBy", "PatientID", "Status" },
                values: new object[] { new Guid("68b9cd57-f1ee-4fdd-8d4e-ae7c9dd26f05"), new Guid("b8006249-0d37-48c6-8170-f575b6e91579"), new DateTime(2024, 2, 2, 10, 18, 25, 794, DateTimeKind.Utc).AddTicks(8774), "viem da day", new Guid("7b13e85b-ffaa-45de-8abf-56c27a9325c3"), new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "test", null, 1, new DateTime(2024, 2, 2, 10, 18, 25, 794, DateTimeKind.Utc).AddTicks(8775), new Guid("b8006249-0d37-48c6-8170-f575b6e91579"), new Guid("fa1e310b-e670-4f58-afb2-1692e529e668"), 1 });

            migrationBuilder.InsertData(
                table: "Pill",
                columns: new[] { "PillId", "Afternoon", "CreatedBy", "CreatedDate", "DateEnd", "DateStart", "DosagePerDay", "Evening", "Index", "LastModifiedDate", "ModifiedBy", "Morning", "Period", "PillDescription", "PillName", "PrescriptionId", "Quantity", "QuantityPerDose", "Status", "Unit" },
                values: new object[,]
                {
                    { new Guid("0bf2a055-8469-461f-9d1c-6caf0e8b2963"), 0, new Guid("b8006249-0d37-48c6-8170-f575b6e91579"), new DateTime(2024, 2, 2, 10, 18, 25, 794, DateTimeKind.Utc).AddTicks(8798), null, null, 1, 0, 1, new DateTime(2024, 2, 2, 10, 18, 25, 794, DateTimeKind.Utc).AddTicks(8799), new Guid("b8006249-0d37-48c6-8170-f575b6e91579"), 1, "ngay", "1 ngay uong 1 vien 30 phut sau khi an", "Nexium mup", new Guid("68b9cd57-f1ee-4fdd-8d4e-ae7c9dd26f05"), 30, 1, 1, "vien" },
                    { new Guid("4cadafd6-352e-47d9-b72f-a52db93905e4"), 0, new Guid("b8006249-0d37-48c6-8170-f575b6e91579"), new DateTime(2024, 2, 2, 10, 18, 25, 794, DateTimeKind.Utc).AddTicks(8813), null, null, 2, 1, 1, new DateTime(2024, 2, 2, 10, 18, 25, 794, DateTimeKind.Utc).AddTicks(8814), new Guid("b8006249-0d37-48c6-8170-f575b6e91579"), 1, "ngay", "1 ngay uong 2 vien chia lam 2 lan(sang, toi - sau khi an)", "Amoxycilin", new Guid("68b9cd57-f1ee-4fdd-8d4e-ae7c9dd26f05"), 20, 1, 1, "vien" }
                });
        }
    }
}
