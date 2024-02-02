using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class v12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("ae319569-eeaf-48f2-aa3f-3ff371f37f54"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03a2582e-6eee-407a-88f0-29abe6cec0ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "333167ba-eac2-4647-a686-a5fe06df6244");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66d22dde-fd40-411d-b218-970a72e3751d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "57bcad15-f17e-4ec5-8f9f-5ea760a84a4e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "603f5a31-893a-4719-828c-2a0c2f606513");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb540be0-e144-4a28-aa5f-f5910cc01750");

            migrationBuilder.DeleteData(
                table: "Pill",
                keyColumn: "PillId",
                keyValue: new Guid("4445eb6d-8471-49a7-b818-57c15f83cb9d"));

            migrationBuilder.DeleteData(
                table: "Pill",
                keyColumn: "PillId",
                keyValue: new Guid("73c79a51-f469-421d-b8f1-b5a5327ff9fc"));

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "PrescriptionID",
                keyValue: new Guid("8895da60-2e7b-42ab-8b37-107990afb505"));

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorID",
                keyValue: new Guid("34543098-a683-4add-a6c9-f8be6f02ffab"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "PatientID",
                keyValue: new Guid("9c255002-796a-4b1c-89a0-2523f2ca7a5d"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("45d5c50c-2eba-4ed2-b06e-43956e0cb1f4"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("b0926bd8-74b3-432d-8e49-a5d91075114e"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("3d6697d9-7b21-4fa1-abd2-0b9128fc035f"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "CreatedBy", "CreatedDate", "Email", "LastModifiedDate", "ModifiedBy", "Password", "Role", "Status" },
                values: new object[,]
                {
                    { new Guid("45d5c50c-2eba-4ed2-b06e-43956e0cb1f4"), null, new DateTime(2024, 1, 30, 5, 55, 49, 679, DateTimeKind.Utc).AddTicks(3210), "dungnvse160223@fpt.edu.vn", new DateTime(2024, 1, 30, 5, 55, 49, 679, DateTimeKind.Utc).AddTicks(3211), null, "@@patient@@", 2, 1 },
                    { new Guid("ae319569-eeaf-48f2-aa3f-3ff371f37f54"), null, new DateTime(2024, 1, 30, 5, 55, 49, 679, DateTimeKind.Utc).AddTicks(3204), "nguyenphat2711@gmail.com", new DateTime(2024, 1, 30, 5, 55, 49, 679, DateTimeKind.Utc).AddTicks(3208), null, "@@admin@@", 0, 1 },
                    { new Guid("b0926bd8-74b3-432d-8e49-a5d91075114e"), null, new DateTime(2024, 1, 30, 5, 55, 49, 679, DateTimeKind.Utc).AddTicks(3213), "khoatruong2509@fpt.edu.vn", new DateTime(2024, 1, 30, 5, 55, 49, 679, DateTimeKind.Utc).AddTicks(3213), null, "@@doctor@@", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03a2582e-6eee-407a-88f0-29abe6cec0ba", "2", "Doctor", "Doctor" },
                    { "333167ba-eac2-4647-a686-a5fe06df6244", "3", "Patient", "Patient" },
                    { "66d22dde-fd40-411d-b218-970a72e3751d", "1", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "57bcad15-f17e-4ec5-8f9f-5ea760a84a4e", 0, "d9dbc392-b28b-4997-8068-8e7512b35a13", "dungnvse160223@fpt.edu.vn", false, false, null, null, null, null, null, false, "60d4cb23-e003-4e47-8328-f8285ef152cf", false, "Dung Nguyen" },
                    { "603f5a31-893a-4719-828c-2a0c2f606513", 0, "50f6c598-9e46-4d4b-bf30-f1531641c0e5", "khoatruong2509@fpt.edu.vn", false, false, null, null, null, null, null, false, "7ff97fd8-37c7-45f4-807b-87ec4ef8c5ca", false, "Khoa Truong" },
                    { "eb540be0-e144-4a28-aa5f-f5910cc01750", 0, "11b4bd7e-c884-4f01-9a24-369d5042555f", "nguyenphat2711@gmail.com", false, false, null, null, null, null, null, false, "6779484f-a364-48ea-b855-0e15f02de7a9", false, "Phat Nguyen" }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "PaymentId", "CreatedBy", "CreatedDate", "LastModifiedDate", "ModifiedBy", "PaymentType", "Status" },
                values: new object[] { new Guid("3d6697d9-7b21-4fa1-abd2-0b9128fc035f"), null, new DateTime(2024, 1, 30, 5, 55, 49, 679, DateTimeKind.Utc).AddTicks(3393), new DateTime(2024, 1, 30, 5, 55, 49, 679, DateTimeKind.Utc).AddTicks(3393), null, "Momo", 0 });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "DoctorID", "AccountId", "CreatedBy", "CreatedDate", "FirstName", "LastModifiedDate", "LastName", "ModifiedBy", "PhoneNumber", "Specialty" },
                values: new object[] { new Guid("34543098-a683-4add-a6c9-f8be6f02ffab"), new Guid("b0926bd8-74b3-432d-8e49-a5d91075114e"), new Guid("b0926bd8-74b3-432d-8e49-a5d91075114e"), new DateTime(2024, 1, 30, 5, 55, 49, 679, DateTimeKind.Utc).AddTicks(3411), "Khoa", new DateTime(2024, 1, 30, 5, 55, 49, 679, DateTimeKind.Utc).AddTicks(3411), "Truong", new Guid("b0926bd8-74b3-432d-8e49-a5d91075114e"), "0987654321", "Khoa noi" });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "PatientID", "AccountId", "Address", "CreatedBy", "CreatedDate", "DateOfBirth", "FirstName", "Gender", "LastModifiedDate", "LastName", "ModifiedBy", "PaymentId", "PhoneNumber" },
                values: new object[] { new Guid("9c255002-796a-4b1c-89a0-2523f2ca7a5d"), new Guid("45d5c50c-2eba-4ed2-b06e-43956e0cb1f4"), "Bac Ninh", new Guid("45d5c50c-2eba-4ed2-b06e-43956e0cb1f4"), new DateTime(2024, 1, 30, 5, 55, 49, 679, DateTimeKind.Utc).AddTicks(3497), new DateTime(2002, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dung", 0, new DateTime(2024, 1, 30, 5, 55, 49, 679, DateTimeKind.Utc).AddTicks(3497), "Nguyen", new Guid("45d5c50c-2eba-4ed2-b06e-43956e0cb1f4"), new Guid("3d6697d9-7b21-4fa1-abd2-0b9128fc035f"), "0123456789" });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "PrescriptionID", "CreatedBy", "CreatedDate", "Diagnosis", "DoctorID", "ExaminationDate", "Image", "ImageBase64", "Index", "LastModifiedDate", "ModifiedBy", "PatientID", "Status" },
                values: new object[] { new Guid("8895da60-2e7b-42ab-8b37-107990afb505"), new Guid("45d5c50c-2eba-4ed2-b06e-43956e0cb1f4"), new DateTime(2024, 1, 30, 5, 55, 49, 679, DateTimeKind.Utc).AddTicks(3515), "viem da day", new Guid("34543098-a683-4add-a6c9-f8be6f02ffab"), new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "test", null, 1, new DateTime(2024, 1, 30, 5, 55, 49, 679, DateTimeKind.Utc).AddTicks(3515), new Guid("45d5c50c-2eba-4ed2-b06e-43956e0cb1f4"), new Guid("9c255002-796a-4b1c-89a0-2523f2ca7a5d"), 1 });

            migrationBuilder.InsertData(
                table: "Pill",
                columns: new[] { "PillId", "Afternoon", "CreatedBy", "CreatedDate", "DateEnd", "DateStart", "DosagePerDay", "Evening", "Index", "LastModifiedDate", "ModifiedBy", "Morning", "Period", "PillDescription", "PillName", "PrescriptionId", "Quantity", "QuantityPerDose", "Status", "Unit" },
                values: new object[,]
                {
                    { new Guid("4445eb6d-8471-49a7-b818-57c15f83cb9d"), 0, new Guid("45d5c50c-2eba-4ed2-b06e-43956e0cb1f4"), new DateTime(2024, 1, 30, 5, 55, 49, 679, DateTimeKind.Utc).AddTicks(3531), null, null, 1, 0, 1, new DateTime(2024, 1, 30, 5, 55, 49, 679, DateTimeKind.Utc).AddTicks(3532), new Guid("45d5c50c-2eba-4ed2-b06e-43956e0cb1f4"), 1, "ngay", "1 ngay uong 1 vien 30 phut sau khi an", "Nexium mup", new Guid("8895da60-2e7b-42ab-8b37-107990afb505"), 30, 1, 1, "vien" },
                    { new Guid("73c79a51-f469-421d-b8f1-b5a5327ff9fc"), 0, new Guid("45d5c50c-2eba-4ed2-b06e-43956e0cb1f4"), new DateTime(2024, 1, 30, 5, 55, 49, 679, DateTimeKind.Utc).AddTicks(3604), null, null, 2, 1, 1, new DateTime(2024, 1, 30, 5, 55, 49, 679, DateTimeKind.Utc).AddTicks(3605), new Guid("45d5c50c-2eba-4ed2-b06e-43956e0cb1f4"), 1, "ngay", "1 ngay uong 2 vien chia lam 2 lan(sang, toi - sau khi an)", "Amoxycilin", new Guid("8895da60-2e7b-42ab-8b37-107990afb505"), 20, 1, 1, "vien" }
                });
        }
    }
}
