using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistory_SubscriptionPackage_SubscriptionPackageSubscriptionId",
                table: "TransactionHistory");

            migrationBuilder.DropIndex(
                name: "IX_TransactionHistory_SubscriptionPackageSubscriptionId",
                table: "TransactionHistory");

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("bfa6adf3-736e-48a5-94bb-ca60dadc0ffd"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5446a0a3-3ee8-4a0d-90ed-66038f1f1fbb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5247bdc-6ecd-431d-a5ab-187901bc5d8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7b8069a-ba53-4970-bd2d-eed6ee32b353");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17d815a6-8392-4144-81a5-416fe1bbb673");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6eab9c5f-eb1e-480c-96b7-3e2c3d8bea9e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b33fe319-5a6e-4fd8-aef3-6024d0ac3754");

            migrationBuilder.DeleteData(
                table: "CustomerPackage",
                keyColumn: "CustomerPackageId",
                keyValue: new Guid("05c54210-3feb-47ec-9cba-ea11366fc32b"));

            migrationBuilder.DeleteData(
                table: "Pill",
                keyColumn: "PillId",
                keyValue: new Guid("403369ce-b0bc-4a07-8a71-ded36fca729b"));

            migrationBuilder.DeleteData(
                table: "Pill",
                keyColumn: "PillId",
                keyValue: new Guid("e0cd6642-0d26-4653-9341-1fcc0033675a"));

            migrationBuilder.DeleteData(
                table: "SubscriptionPackage",
                keyColumn: "SubscriptionId",
                keyValue: new Guid("53077e66-d1a7-4b6b-a8e7-dc88401e2f04"));

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "PrescriptionID",
                keyValue: new Guid("a3931257-9c52-4237-92e0-6ef798fd55f0"));

            migrationBuilder.DeleteData(
                table: "SubscriptionPackage",
                keyColumn: "SubscriptionId",
                keyValue: new Guid("75f620aa-282d-41f2-b8f3-e9b7940c9d71"));

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorID",
                keyValue: new Guid("eac3307e-e29d-48e6-bb79-805437d0d970"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "PatientID",
                keyValue: new Guid("e8c6ece8-a51d-4161-bf30-956a40a26c2f"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("acd3bc8a-565a-40aa-b23c-13cfb1bb4240"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("e6125d71-4bf1-4274-a3e9-0c61d778d897"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("3a85a5c0-2189-4ef1-8dcd-bb399a844166"));

            migrationBuilder.DropColumn(
                name: "SubscriptionPackageSubscriptionId",
                table: "TransactionHistory");

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "CreatedBy", "CreatedDate", "Email", "LastModifiedDate", "ModifiedBy", "Password", "Role", "Status" },
                values: new object[,]
                {
                    { new Guid("068c3416-e2d7-4a7d-8654-8e430a32fdba"), null, new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(7509), "dungnvse160223@fpt.edu.vn", new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(7510), null, "@@patient@@", 2, 1 },
                    { new Guid("6ce2206f-c937-4e5d-a256-34e110af558f"), null, new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(7513), "khoatruong2509@fpt.edu.vn", new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(7514), null, "@@doctor@@", 1, 1 },
                    { new Guid("9a62decc-1daf-45ca-a28b-c34c1f1fdaab"), null, new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(7500), "nguyenphat2711@gmail.com", new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(7504), null, "@@admin@@", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "49d2a4c6-b14b-4697-89c8-537e686fb667", "3", "Patient", "Patient" },
                    { "6236c5ca-c706-41cf-9409-80264e881a98", "2", "Doctor", "Doctor" },
                    { "f7455e12-57d1-40cc-8929-89a09fb41241", "1", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3dd2cbb5-6e15-46a0-8523-c8820d8136a1", 0, "93498e9d-8803-4f50-9101-a455cb37fad8", "khoatruong2509@fpt.edu.vn", false, true, null, "KHOATRUONG2509@FPT.EDU.VN", null, null, null, false, "d22caba4-5239-4b56-8011-9cd82cf7609f", false, "Khoa Truong" },
                    { "8748a309-d07e-4250-b0c2-f315398bb266", 0, "e0ae70a3-3fbc-4bb3-b430-a6366dec5ecb", "dungnvse160223@fpt.edu.vn", false, true, null, "DUNGNVSE160223@FPT.EDU.VN", null, null, null, false, "17914fa1-ea48-47ca-9293-c172436aad4e", false, "Dung Nguyen" },
                    { "e50105b4-00a0-4068-b2e0-47392f4bf411", 0, "b996625a-9d26-47c0-acbf-8d571e6d3c32", "nguyenphat2711@gmail.com", false, true, null, "NGUYENPHAT2711@GMAIL.COM", null, null, null, false, "9b789972-b00f-4f43-be2f-cd07ed41f1c7", false, "Phat Nguyen" }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "PaymentId", "CreatedBy", "CreatedDate", "LastModifiedDate", "ModifiedBy", "PaymentType", "Status" },
                values: new object[] { new Guid("77b729a2-a214-4b7d-81ab-392bc5e31e3f"), null, new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(7878), new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(7879), null, "Smart Banking", 0 });

            migrationBuilder.InsertData(
                table: "SubscriptionPackage",
                columns: new[] { "SubscriptionId", "CreatedBy", "CreatedDate", "CurrencyUnit", "LastModifiedDate", "ModifiedBy", "PackageType", "Period", "Status", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("3ce50d83-b7b8-4790-a71a-19e799d53bc3"), null, new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(8162), "USD", new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(8163), null, "Premium", "365", 1, 2f },
                    { new Guid("b27301f2-6c11-4671-9962-3be7e32d5707"), null, new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(8090), "USD", new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(8091), null, "Basic", "90", 1, 0f }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "DoctorID", "AccountId", "CreatedBy", "CreatedDate", "FirstName", "LastModifiedDate", "LastName", "ModifiedBy", "PhoneNumber", "Specialty" },
                values: new object[] { new Guid("191e46fb-8bfd-4f6f-abec-caa9e8ef780f"), new Guid("6ce2206f-c937-4e5d-a256-34e110af558f"), new Guid("6ce2206f-c937-4e5d-a256-34e110af558f"), new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(7904), "Khoa", new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(7905), "Truong", new Guid("6ce2206f-c937-4e5d-a256-34e110af558f"), "0987654321", "Khoa noi" });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "PatientID", "AccountId", "Address", "CreatedBy", "CreatedDate", "DateOfBirth", "FirstName", "Gender", "LastModifiedDate", "LastName", "ModifiedBy", "PaymentId", "PhoneNumber" },
                values: new object[] { new Guid("45c87336-628c-428e-b22f-3ce8eb181751"), new Guid("068c3416-e2d7-4a7d-8654-8e430a32fdba"), "Bac Ninh", new Guid("068c3416-e2d7-4a7d-8654-8e430a32fdba"), new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(8036), new DateTime(2002, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dung", 0, new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(8037), "Nguyen", new Guid("068c3416-e2d7-4a7d-8654-8e430a32fdba"), new Guid("77b729a2-a214-4b7d-81ab-392bc5e31e3f"), "0123456789" });

            migrationBuilder.InsertData(
                table: "CustomerPackage",
                columns: new[] { "CustomerPackageId", "AllowPillHistory", "CreatedBy", "CreatedDate", "CustomerPackageName", "DateEnd", "DateStart", "LastModifiedDate", "ModifiedBy", "NumberScan", "PatientId", "Status", "SubcriptionPackageId" },
                values: new object[] { new Guid("ad4adc9f-6065-41d7-a5cf-a04deb155aac"), 0, null, new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(8220), "Basic", new DateTime(2024, 5, 31, 11, 40, 13, 360, DateTimeKind.Local).AddTicks(8197), new DateTime(2024, 3, 2, 11, 40, 13, 360, DateTimeKind.Local).AddTicks(8182), new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(8221), null, "2", new Guid("45c87336-628c-428e-b22f-3ce8eb181751"), 1, new Guid("b27301f2-6c11-4671-9962-3be7e32d5707") });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "PrescriptionID", "CreatedBy", "CreatedDate", "Diagnosis", "DoctorID", "ExaminationDate", "Image", "ImageBase64", "Index", "LastModifiedDate", "ModifiedBy", "PatientID", "Status" },
                values: new object[] { new Guid("5b2053a4-3e99-4106-84a0-c0080009663e"), new Guid("068c3416-e2d7-4a7d-8654-8e430a32fdba"), new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(8069), "viem da day", new Guid("191e46fb-8bfd-4f6f-abec-caa9e8ef780f"), new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "test", null, 1, new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(8070), new Guid("068c3416-e2d7-4a7d-8654-8e430a32fdba"), new Guid("45c87336-628c-428e-b22f-3ce8eb181751"), 1 });

            migrationBuilder.InsertData(
                table: "Pill",
                columns: new[] { "PillId", "Afternoon", "CreatedBy", "CreatedDate", "DateEnd", "DateStart", "DosagePerDay", "Evening", "Index", "LastModifiedDate", "ModifiedBy", "Morning", "Period", "PillDescription", "PillManagerId", "PillName", "PrescriptionId", "Quantity", "QuantityPerDose", "Status", "Unit" },
                values: new object[,]
                {
                    { new Guid("9aa40e47-60ca-4418-a3fa-12653259746c"), 0, new Guid("068c3416-e2d7-4a7d-8654-8e430a32fdba"), new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(8249), null, null, 1, 0, 1, new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(8250), new Guid("068c3416-e2d7-4a7d-8654-8e430a32fdba"), 1, "ngay", "1 ngay uong 1 vien 30 phut sau khi an", null, "Nexium mup", new Guid("5b2053a4-3e99-4106-84a0-c0080009663e"), 30, 1, 1, "vien" },
                    { new Guid("d7c72083-3079-4a1a-8ec2-17df5f793628"), 0, new Guid("068c3416-e2d7-4a7d-8654-8e430a32fdba"), new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(8268), null, null, 2, 1, 1, new DateTime(2024, 3, 2, 4, 40, 13, 360, DateTimeKind.Utc).AddTicks(8269), new Guid("068c3416-e2d7-4a7d-8654-8e430a32fdba"), 1, "ngay", "1 ngay uong 2 vien chia lam 2 lan(sang, toi - sau khi an)", null, "Amoxycilin", new Guid("5b2053a4-3e99-4106-84a0-c0080009663e"), 20, 1, 1, "vien" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_PackageId",
                table: "TransactionHistory",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistory_SubscriptionPackage_PackageId",
                table: "TransactionHistory",
                column: "PackageId",
                principalTable: "SubscriptionPackage",
                principalColumn: "SubscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistory_SubscriptionPackage_PackageId",
                table: "TransactionHistory");

            migrationBuilder.DropIndex(
                name: "IX_TransactionHistory_PackageId",
                table: "TransactionHistory");

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("9a62decc-1daf-45ca-a28b-c34c1f1fdaab"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49d2a4c6-b14b-4697-89c8-537e686fb667");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6236c5ca-c706-41cf-9409-80264e881a98");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7455e12-57d1-40cc-8929-89a09fb41241");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dd2cbb5-6e15-46a0-8523-c8820d8136a1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8748a309-d07e-4250-b0c2-f315398bb266");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e50105b4-00a0-4068-b2e0-47392f4bf411");

            migrationBuilder.DeleteData(
                table: "CustomerPackage",
                keyColumn: "CustomerPackageId",
                keyValue: new Guid("ad4adc9f-6065-41d7-a5cf-a04deb155aac"));

            migrationBuilder.DeleteData(
                table: "Pill",
                keyColumn: "PillId",
                keyValue: new Guid("9aa40e47-60ca-4418-a3fa-12653259746c"));

            migrationBuilder.DeleteData(
                table: "Pill",
                keyColumn: "PillId",
                keyValue: new Guid("d7c72083-3079-4a1a-8ec2-17df5f793628"));

            migrationBuilder.DeleteData(
                table: "SubscriptionPackage",
                keyColumn: "SubscriptionId",
                keyValue: new Guid("3ce50d83-b7b8-4790-a71a-19e799d53bc3"));

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "PrescriptionID",
                keyValue: new Guid("5b2053a4-3e99-4106-84a0-c0080009663e"));

            migrationBuilder.DeleteData(
                table: "SubscriptionPackage",
                keyColumn: "SubscriptionId",
                keyValue: new Guid("b27301f2-6c11-4671-9962-3be7e32d5707"));

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorID",
                keyValue: new Guid("191e46fb-8bfd-4f6f-abec-caa9e8ef780f"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "PatientID",
                keyValue: new Guid("45c87336-628c-428e-b22f-3ce8eb181751"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("068c3416-e2d7-4a7d-8654-8e430a32fdba"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("6ce2206f-c937-4e5d-a256-34e110af558f"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("77b729a2-a214-4b7d-81ab-392bc5e31e3f"));

            migrationBuilder.AddColumn<Guid>(
                name: "SubscriptionPackageSubscriptionId",
                table: "TransactionHistory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "CreatedBy", "CreatedDate", "Email", "LastModifiedDate", "ModifiedBy", "Password", "Role", "Status" },
                values: new object[,]
                {
                    { new Guid("acd3bc8a-565a-40aa-b23c-13cfb1bb4240"), null, new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(4855), "khoatruong2509@fpt.edu.vn", new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(4856), null, "@@doctor@@", 1, 1 },
                    { new Guid("bfa6adf3-736e-48a5-94bb-ca60dadc0ffd"), null, new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(4844), "nguyenphat2711@gmail.com", new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(4848), null, "@@admin@@", 0, 1 },
                    { new Guid("e6125d71-4bf1-4274-a3e9-0c61d778d897"), null, new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(4851), "dungnvse160223@fpt.edu.vn", new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(4852), null, "@@patient@@", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5446a0a3-3ee8-4a0d-90ed-66038f1f1fbb", "1", "Admin", "Admin" },
                    { "d5247bdc-6ecd-431d-a5ab-187901bc5d8f", "2", "Doctor", "Doctor" },
                    { "f7b8069a-ba53-4970-bd2d-eed6ee32b353", "3", "Patient", "Patient" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "17d815a6-8392-4144-81a5-416fe1bbb673", 0, "afbb94e7-ca87-4276-a01b-ec6648f3461a", "khoatruong2509@fpt.edu.vn", false, true, null, "KHOATRUONG2509@FPT.EDU.VN", null, null, null, false, "2c2f65bc-73d4-4573-b67d-30ab8add124b", false, "Khoa Truong" },
                    { "6eab9c5f-eb1e-480c-96b7-3e2c3d8bea9e", 0, "bd51202d-bfab-42aa-ba77-ce3bde381069", "nguyenphat2711@gmail.com", false, true, null, "NGUYENPHAT2711@GMAIL.COM", null, null, null, false, "d85fd415-3bde-42b6-8452-b4a59bf2b1bc", false, "Phat Nguyen" },
                    { "b33fe319-5a6e-4fd8-aef3-6024d0ac3754", 0, "57c34f55-e30f-4f3a-82b4-848310c37266", "dungnvse160223@fpt.edu.vn", false, true, null, "DUNGNVSE160223@FPT.EDU.VN", null, null, null, false, "5280e727-5ea9-4c62-b236-9acbafaf3f10", false, "Dung Nguyen" }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "PaymentId", "CreatedBy", "CreatedDate", "LastModifiedDate", "ModifiedBy", "PaymentType", "Status" },
                values: new object[] { new Guid("3a85a5c0-2189-4ef1-8dcd-bb399a844166"), null, new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(5264), new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(5264), null, "Smart Banking", 0 });

            migrationBuilder.InsertData(
                table: "SubscriptionPackage",
                columns: new[] { "SubscriptionId", "CreatedBy", "CreatedDate", "CurrencyUnit", "LastModifiedDate", "ModifiedBy", "PackageType", "Period", "Status", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("53077e66-d1a7-4b6b-a8e7-dc88401e2f04"), null, new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(5557), "USD", new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(5558), null, "Premium", "365", 1, 2f },
                    { new Guid("75f620aa-282d-41f2-b8f3-e9b7940c9d71"), null, new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(5484), "USD", new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(5484), null, "Basic", "90", 1, 0f }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "DoctorID", "AccountId", "CreatedBy", "CreatedDate", "FirstName", "LastModifiedDate", "LastName", "ModifiedBy", "PhoneNumber", "Specialty" },
                values: new object[] { new Guid("eac3307e-e29d-48e6-bb79-805437d0d970"), new Guid("acd3bc8a-565a-40aa-b23c-13cfb1bb4240"), new Guid("acd3bc8a-565a-40aa-b23c-13cfb1bb4240"), new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(5288), "Khoa", new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(5288), "Truong", new Guid("acd3bc8a-565a-40aa-b23c-13cfb1bb4240"), "0987654321", "Khoa noi" });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "PatientID", "AccountId", "Address", "CreatedBy", "CreatedDate", "DateOfBirth", "FirstName", "Gender", "LastModifiedDate", "LastName", "ModifiedBy", "PaymentId", "PhoneNumber" },
                values: new object[] { new Guid("e8c6ece8-a51d-4161-bf30-956a40a26c2f"), new Guid("e6125d71-4bf1-4274-a3e9-0c61d778d897"), "Bac Ninh", new Guid("e6125d71-4bf1-4274-a3e9-0c61d778d897"), new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(5427), new DateTime(2002, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dung", 0, new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(5428), "Nguyen", new Guid("e6125d71-4bf1-4274-a3e9-0c61d778d897"), new Guid("3a85a5c0-2189-4ef1-8dcd-bb399a844166"), "0123456789" });

            migrationBuilder.InsertData(
                table: "CustomerPackage",
                columns: new[] { "CustomerPackageId", "AllowPillHistory", "CreatedBy", "CreatedDate", "CustomerPackageName", "DateEnd", "DateStart", "LastModifiedDate", "ModifiedBy", "NumberScan", "PatientId", "Status", "SubcriptionPackageId" },
                values: new object[] { new Guid("05c54210-3feb-47ec-9cba-ea11366fc32b"), 0, null, new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(5615), "Basic", new DateTime(2024, 5, 28, 15, 34, 57, 644, DateTimeKind.Local).AddTicks(5591), new DateTime(2024, 2, 28, 15, 34, 57, 644, DateTimeKind.Local).AddTicks(5580), new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(5616), null, "2", new Guid("e8c6ece8-a51d-4161-bf30-956a40a26c2f"), 1, new Guid("75f620aa-282d-41f2-b8f3-e9b7940c9d71") });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "PrescriptionID", "CreatedBy", "CreatedDate", "Diagnosis", "DoctorID", "ExaminationDate", "Image", "ImageBase64", "Index", "LastModifiedDate", "ModifiedBy", "PatientID", "Status" },
                values: new object[] { new Guid("a3931257-9c52-4237-92e0-6ef798fd55f0"), new Guid("e6125d71-4bf1-4274-a3e9-0c61d778d897"), new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(5459), "viem da day", new Guid("eac3307e-e29d-48e6-bb79-805437d0d970"), new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "test", null, 1, new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(5460), new Guid("e6125d71-4bf1-4274-a3e9-0c61d778d897"), new Guid("e8c6ece8-a51d-4161-bf30-956a40a26c2f"), 1 });

            migrationBuilder.InsertData(
                table: "Pill",
                columns: new[] { "PillId", "Afternoon", "CreatedBy", "CreatedDate", "DateEnd", "DateStart", "DosagePerDay", "Evening", "Index", "LastModifiedDate", "ModifiedBy", "Morning", "Period", "PillDescription", "PillManagerId", "PillName", "PrescriptionId", "Quantity", "QuantityPerDose", "Status", "Unit" },
                values: new object[,]
                {
                    { new Guid("403369ce-b0bc-4a07-8a71-ded36fca729b"), 0, new Guid("e6125d71-4bf1-4274-a3e9-0c61d778d897"), new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(5654), null, null, 2, 1, 1, new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(5655), new Guid("e6125d71-4bf1-4274-a3e9-0c61d778d897"), 1, "ngay", "1 ngay uong 2 vien chia lam 2 lan(sang, toi - sau khi an)", null, "Amoxycilin", new Guid("a3931257-9c52-4237-92e0-6ef798fd55f0"), 20, 1, 1, "vien" },
                    { new Guid("e0cd6642-0d26-4653-9341-1fcc0033675a"), 0, new Guid("e6125d71-4bf1-4274-a3e9-0c61d778d897"), new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(5638), null, null, 1, 0, 1, new DateTime(2024, 2, 28, 8, 34, 57, 644, DateTimeKind.Utc).AddTicks(5639), new Guid("e6125d71-4bf1-4274-a3e9-0c61d778d897"), 1, "ngay", "1 ngay uong 1 vien 30 phut sau khi an", null, "Nexium mup", new Guid("a3931257-9c52-4237-92e0-6ef798fd55f0"), 30, 1, 1, "vien" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_SubscriptionPackageSubscriptionId",
                table: "TransactionHistory",
                column: "SubscriptionPackageSubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistory_SubscriptionPackage_SubscriptionPackageSubscriptionId",
                table: "TransactionHistory",
                column: "SubscriptionPackageSubscriptionId",
                principalTable: "SubscriptionPackage",
                principalColumn: "SubscriptionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
