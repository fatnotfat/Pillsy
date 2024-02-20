using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class v14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPackage_SubscriptionPackage_SubscriptionPackagePackageId",
                table: "CustomerPackage");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPackage_SubscriptionPackagePackageId",
                table: "CustomerPackage");

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
                name: "SubscriptionPackagePackageId",
                table: "CustomerPackage");

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "CreatedBy", "CreatedDate", "Email", "LastModifiedDate", "ModifiedBy", "Password", "Role", "Status" },
                values: new object[,]
                {
                    { new Guid("555b7fa4-206f-4552-86ee-118721b10701"), null, new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(6294), "nguyenphat2711@gmail.com", new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(6299), null, "@@admin@@", 0, 1 },
                    { new Guid("5a1be7f8-4d4d-45c6-b730-481d3b183e3f"), null, new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(6304), "dungnvse160223@fpt.edu.vn", new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(6305), null, "@@patient@@", 2, 1 },
                    { new Guid("dea422f0-5393-455f-ba44-1cc99ab74342"), null, new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(6309), "khoatruong2509@fpt.edu.vn", new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(6310), null, "@@doctor@@", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1320cf8d-01a6-47bc-abe8-fa76b46888af", "3", "Patient", "Patient" },
                    { "236ce4f4-cccc-4a2e-b391-b2dd5f595813", "1", "Admin", "Admin" },
                    { "865816ba-41ec-4832-9b55-eee7e363c434", "2", "Doctor", "Doctor" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "61224228-6a4d-4e4a-880f-89c12dc20f17", 0, "bfe3fbd4-8d36-4562-aaa5-7cb3201fcad8", "nguyenphat2711@gmail.com", false, true, null, "NGUYENPHAT2711@GMAIL.COM", null, null, null, false, "44ef5ace-efd1-4f40-b867-d3596c42627e", false, "Phat Nguyen" },
                    { "846ca57e-eb03-4831-840f-bda238b43290", 0, "2a9ddee7-9160-40e2-8a43-37e51747bd9b", "dungnvse160223@fpt.edu.vn", false, true, null, "DUNGNVSE160223@FPT.EDU.VN", null, null, null, false, "4ec31073-e348-497b-a22a-a03b6739367a", false, "Dung Nguyen" },
                    { "97dce11b-edfd-4447-bdce-ad7b0daebe24", 0, "55c3f2ff-7eb9-4021-8abe-3c14821f42eb", "khoatruong2509@fpt.edu.vn", false, true, null, "KHOATRUONG2509@FPT.EDU.VN", null, null, null, false, "f4738d05-2411-4bab-a18c-d9f5804be973", false, "Khoa Truong" }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "PaymentId", "CreatedBy", "CreatedDate", "LastModifiedDate", "ModifiedBy", "PaymentType", "Status" },
                values: new object[] { new Guid("754c3edf-002d-4b62-9d13-e2a934260a8b"), null, new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(6967), new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(6969), null, "Smart Banking", 0 });

            migrationBuilder.InsertData(
                table: "SubscriptionPackage",
                columns: new[] { "PackageId", "CreatedBy", "CreatedDate", "CurrencyUnit", "LastModifiedDate", "ModifiedBy", "PackageType", "Period", "Status", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("0a84d947-1066-4fbe-a1ef-779732e5978c"), null, new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(7276), "USD", new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(7278), null, "Premium", "365", 1, 2f },
                    { new Guid("e55b0c52-dc55-422d-9972-35d52d7ab860"), null, new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(7255), "USD", new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(7256), null, "Basic", "90", 1, 0f }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "DoctorID", "AccountId", "CreatedBy", "CreatedDate", "FirstName", "LastModifiedDate", "LastName", "ModifiedBy", "PhoneNumber", "Specialty" },
                values: new object[] { new Guid("4493708f-ff50-43f2-b26f-b4581e46719d"), new Guid("dea422f0-5393-455f-ba44-1cc99ab74342"), new Guid("dea422f0-5393-455f-ba44-1cc99ab74342"), new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(7003), "Khoa", new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(7005), "Truong", new Guid("dea422f0-5393-455f-ba44-1cc99ab74342"), "0987654321", "Khoa noi" });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "PatientID", "AccountId", "Address", "CreatedBy", "CreatedDate", "DateOfBirth", "FirstName", "Gender", "LastModifiedDate", "LastName", "ModifiedBy", "PaymentId", "PhoneNumber" },
                values: new object[] { new Guid("5d1156d4-3cb6-4e07-91c7-fe5716080795"), new Guid("5a1be7f8-4d4d-45c6-b730-481d3b183e3f"), "Bac Ninh", new Guid("5a1be7f8-4d4d-45c6-b730-481d3b183e3f"), new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(7167), new DateTime(2002, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dung", 0, new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(7169), "Nguyen", new Guid("5a1be7f8-4d4d-45c6-b730-481d3b183e3f"), new Guid("754c3edf-002d-4b62-9d13-e2a934260a8b"), "0123456789" });

            migrationBuilder.InsertData(
                table: "CustomerPackage",
                columns: new[] { "CustomerPackageId", "AllowPillHistory", "CreatedBy", "CreatedDate", "CustomerPackageName", "DateEnd", "DateStart", "LastModifiedDate", "ModifiedBy", "NumberScan", "PatientId", "Status", "SubcriptionPackageId" },
                values: new object[] { new Guid("cf51667e-ad2e-4e92-9a1a-ba7b329f403d"), 0, null, new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(7349), "Basic", new DateTime(2024, 5, 20, 20, 12, 31, 561, DateTimeKind.Local).AddTicks(7317), new DateTime(2024, 2, 20, 20, 12, 31, 561, DateTimeKind.Local).AddTicks(7303), new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(7351), null, "2", new Guid("5d1156d4-3cb6-4e07-91c7-fe5716080795"), 1, new Guid("e55b0c52-dc55-422d-9972-35d52d7ab860") });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "PrescriptionID", "CreatedBy", "CreatedDate", "Diagnosis", "DoctorID", "ExaminationDate", "Image", "ImageBase64", "Index", "LastModifiedDate", "ModifiedBy", "PatientID", "Status" },
                values: new object[] { new Guid("f320f722-141a-4eea-a355-667e423ff8e6"), new Guid("5a1be7f8-4d4d-45c6-b730-481d3b183e3f"), new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(7220), "viem da day", new Guid("4493708f-ff50-43f2-b26f-b4581e46719d"), new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "test", null, 1, new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(7222), new Guid("5a1be7f8-4d4d-45c6-b730-481d3b183e3f"), new Guid("5d1156d4-3cb6-4e07-91c7-fe5716080795"), 1 });

            migrationBuilder.InsertData(
                table: "Pill",
                columns: new[] { "PillId", "Afternoon", "CreatedBy", "CreatedDate", "DateEnd", "DateStart", "DosagePerDay", "Evening", "Index", "LastModifiedDate", "ModifiedBy", "Morning", "Period", "PillDescription", "PillManagerId", "PillName", "PrescriptionId", "Quantity", "QuantityPerDose", "Status", "Unit" },
                values: new object[,]
                {
                    { new Guid("0d26c8a7-3a41-4354-af4a-059a1ca66716"), 0, new Guid("5a1be7f8-4d4d-45c6-b730-481d3b183e3f"), new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(7408), null, null, 2, 1, 1, new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(7409), new Guid("5a1be7f8-4d4d-45c6-b730-481d3b183e3f"), 1, "ngay", "1 ngay uong 2 vien chia lam 2 lan(sang, toi - sau khi an)", null, "Amoxycilin", new Guid("f320f722-141a-4eea-a355-667e423ff8e6"), 20, 1, 1, "vien" },
                    { new Guid("5dbdce42-4737-4019-8eee-2cd56fb511b1"), 0, new Guid("5a1be7f8-4d4d-45c6-b730-481d3b183e3f"), new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(7384), null, null, 1, 0, 1, new DateTime(2024, 2, 20, 13, 12, 31, 561, DateTimeKind.Utc).AddTicks(7386), new Guid("5a1be7f8-4d4d-45c6-b730-481d3b183e3f"), 1, "ngay", "1 ngay uong 1 vien 30 phut sau khi an", null, "Nexium mup", new Guid("f320f722-141a-4eea-a355-667e423ff8e6"), 30, 1, 1, "vien" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPackage_SubcriptionPackageId",
                table: "CustomerPackage",
                column: "SubcriptionPackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPackage_SubscriptionPackage_SubcriptionPackageId",
                table: "CustomerPackage",
                column: "SubcriptionPackageId",
                principalTable: "SubscriptionPackage",
                principalColumn: "PackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPackage_SubscriptionPackage_SubcriptionPackageId",
                table: "CustomerPackage");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPackage_SubcriptionPackageId",
                table: "CustomerPackage");

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("555b7fa4-206f-4552-86ee-118721b10701"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1320cf8d-01a6-47bc-abe8-fa76b46888af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "236ce4f4-cccc-4a2e-b391-b2dd5f595813");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "865816ba-41ec-4832-9b55-eee7e363c434");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "61224228-6a4d-4e4a-880f-89c12dc20f17");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "846ca57e-eb03-4831-840f-bda238b43290");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97dce11b-edfd-4447-bdce-ad7b0daebe24");

            migrationBuilder.DeleteData(
                table: "CustomerPackage",
                keyColumn: "CustomerPackageId",
                keyValue: new Guid("cf51667e-ad2e-4e92-9a1a-ba7b329f403d"));

            migrationBuilder.DeleteData(
                table: "Pill",
                keyColumn: "PillId",
                keyValue: new Guid("0d26c8a7-3a41-4354-af4a-059a1ca66716"));

            migrationBuilder.DeleteData(
                table: "Pill",
                keyColumn: "PillId",
                keyValue: new Guid("5dbdce42-4737-4019-8eee-2cd56fb511b1"));

            migrationBuilder.DeleteData(
                table: "SubscriptionPackage",
                keyColumn: "PackageId",
                keyValue: new Guid("0a84d947-1066-4fbe-a1ef-779732e5978c"));

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "PrescriptionID",
                keyValue: new Guid("f320f722-141a-4eea-a355-667e423ff8e6"));

            migrationBuilder.DeleteData(
                table: "SubscriptionPackage",
                keyColumn: "PackageId",
                keyValue: new Guid("e55b0c52-dc55-422d-9972-35d52d7ab860"));

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorID",
                keyValue: new Guid("4493708f-ff50-43f2-b26f-b4581e46719d"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "PatientID",
                keyValue: new Guid("5d1156d4-3cb6-4e07-91c7-fe5716080795"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("5a1be7f8-4d4d-45c6-b730-481d3b183e3f"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("dea422f0-5393-455f-ba44-1cc99ab74342"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("754c3edf-002d-4b62-9d13-e2a934260a8b"));

            migrationBuilder.AddColumn<Guid>(
                name: "SubscriptionPackagePackageId",
                table: "CustomerPackage",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                name: "IX_CustomerPackage_SubscriptionPackagePackageId",
                table: "CustomerPackage",
                column: "SubscriptionPackagePackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPackage_SubscriptionPackage_SubscriptionPackagePackageId",
                table: "CustomerPackage",
                column: "SubscriptionPackagePackageId",
                principalTable: "SubscriptionPackage",
                principalColumn: "PackageId");
        }
    }
}
