using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class Initialize_v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("d74fdda3-1ffe-4ae4-8f55-c23e92b0c19e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "199d38c3-c051-4a76-b64e-67d25a7894e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5698b9e3-ebfd-40b8-acde-02fcb8157900");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d213039d-0f03-495b-a1a6-538369ce24a2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d15ffe8-463c-4322-a76e-f5609d3c6871");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "48543c33-263b-4a09-bfd1-b3346eefe31e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2dc2d8-279d-449f-931e-9f7bbfc3b333");

            migrationBuilder.DeleteData(
                table: "Pill",
                keyColumn: "PillId",
                keyValue: new Guid("07b8bae5-0cdb-4f8c-90a5-b6749fb0f7d9"));

            migrationBuilder.DeleteData(
                table: "Pill",
                keyColumn: "PillId",
                keyValue: new Guid("56c35107-7373-4e4a-b879-474303892dc0"));

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "PrescriptionID",
                keyValue: new Guid("d1b551c2-f64d-4bc6-a01c-bce1f7cb711e"));

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "DoctorID",
                keyValue: new Guid("7e58e8f5-ad56-4129-beb0-a3c22a6b20dd"));

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "PatientID",
                keyValue: new Guid("dbaf0216-ad5d-45a6-bf60-e6975ca9961e"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("56862c2b-bd74-41cf-8af2-c82966f332ad"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("8fc5ef50-7ed0-45c4-aa12-9f5120f5d799"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "PaymentId",
                keyValue: new Guid("5d9c6279-394d-433f-bbcb-42fb45627501"));

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentId",
                table: "Patient",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentId",
                table: "Patient",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "CreatedBy", "CreatedDate", "Email", "LastModifiedDate", "ModifiedBy", "Password", "Role", "Status" },
                values: new object[,]
                {
                    { new Guid("56862c2b-bd74-41cf-8af2-c82966f332ad"), null, new DateTime(2024, 1, 30, 5, 30, 28, 774, DateTimeKind.Utc).AddTicks(7209), "khoatruong2509@fpt.edu.vn", new DateTime(2024, 1, 30, 5, 30, 28, 774, DateTimeKind.Utc).AddTicks(7210), null, "@@doctor@@", 1, 1 },
                    { new Guid("8fc5ef50-7ed0-45c4-aa12-9f5120f5d799"), null, new DateTime(2024, 1, 30, 5, 30, 28, 774, DateTimeKind.Utc).AddTicks(7206), "dungnvse160223@fpt.edu.vn", new DateTime(2024, 1, 30, 5, 30, 28, 774, DateTimeKind.Utc).AddTicks(7207), null, "@@patient@@", 2, 1 },
                    { new Guid("d74fdda3-1ffe-4ae4-8f55-c23e92b0c19e"), null, new DateTime(2024, 1, 30, 5, 30, 28, 774, DateTimeKind.Utc).AddTicks(7198), "nguyenphat2711@gmail.com", new DateTime(2024, 1, 30, 5, 30, 28, 774, DateTimeKind.Utc).AddTicks(7202), null, "@@admin@@", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "199d38c3-c051-4a76-b64e-67d25a7894e0", "2", "Doctor", "Doctor" },
                    { "5698b9e3-ebfd-40b8-acde-02fcb8157900", "1", "Admin", "Admin" },
                    { "d213039d-0f03-495b-a1a6-538369ce24a2", "3", "Patient", "Patient" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1d15ffe8-463c-4322-a76e-f5609d3c6871", 0, "2cc4d13b-5754-4382-ab76-adbdcb1bc6fd", "nguyenphat2711@gmail.com", false, false, null, null, null, null, null, false, "d5042133-0775-4fca-b7f6-eb4c6ccef6e6", false, "Phat Nguyen" },
                    { "48543c33-263b-4a09-bfd1-b3346eefe31e", 0, "25e5268f-6a6d-4a83-9a4c-c44572ff5cc1", "dungnvse160223@fpt.edu.vn", false, false, null, null, null, null, null, false, "2e8494e9-2304-450f-bcf6-1be48fd40edf", false, "Dung Nguyen" },
                    { "4a2dc2d8-279d-449f-931e-9f7bbfc3b333", 0, "5c9ddb5c-09d2-4b63-9f41-88d270b1a614", "khoatruong2509@fpt.edu.vn", false, false, null, null, null, null, null, false, "13388991-7fb0-4de0-942c-04fa990d4ca6", false, "Khoa Truong" }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "PaymentId", "CreatedBy", "CreatedDate", "LastModifiedDate", "ModifiedBy", "PaymentType", "Status" },
                values: new object[] { new Guid("5d9c6279-394d-433f-bbcb-42fb45627501"), null, new DateTime(2024, 1, 30, 5, 30, 28, 774, DateTimeKind.Utc).AddTicks(7518), new DateTime(2024, 1, 30, 5, 30, 28, 774, DateTimeKind.Utc).AddTicks(7519), null, "Momo", 0 });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "DoctorID", "AccountId", "CreatedBy", "CreatedDate", "FirstName", "LastModifiedDate", "LastName", "ModifiedBy", "PhoneNumber", "Specialty" },
                values: new object[] { new Guid("7e58e8f5-ad56-4129-beb0-a3c22a6b20dd"), new Guid("56862c2b-bd74-41cf-8af2-c82966f332ad"), new Guid("56862c2b-bd74-41cf-8af2-c82966f332ad"), new DateTime(2024, 1, 30, 5, 30, 28, 774, DateTimeKind.Utc).AddTicks(7542), "Khoa", new DateTime(2024, 1, 30, 5, 30, 28, 774, DateTimeKind.Utc).AddTicks(7543), "Truong", new Guid("56862c2b-bd74-41cf-8af2-c82966f332ad"), "0987654321", "Khoa noi" });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "PatientID", "AccountId", "Address", "CreatedBy", "CreatedDate", "DateOfBirth", "FirstName", "Gender", "LastModifiedDate", "LastName", "ModifiedBy", "PaymentId", "PhoneNumber" },
                values: new object[] { new Guid("dbaf0216-ad5d-45a6-bf60-e6975ca9961e"), new Guid("8fc5ef50-7ed0-45c4-aa12-9f5120f5d799"), "Bac Ninh", new Guid("8fc5ef50-7ed0-45c4-aa12-9f5120f5d799"), new DateTime(2024, 1, 30, 5, 30, 28, 774, DateTimeKind.Utc).AddTicks(7658), new DateTime(2002, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dung", 0, new DateTime(2024, 1, 30, 5, 30, 28, 774, DateTimeKind.Utc).AddTicks(7658), "Nguyen", new Guid("8fc5ef50-7ed0-45c4-aa12-9f5120f5d799"), new Guid("5d9c6279-394d-433f-bbcb-42fb45627501"), "0123456789" });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "PrescriptionID", "CreatedBy", "CreatedDate", "Diagnosis", "DoctorID", "ExaminationDate", "Image", "ImageBase64", "Index", "LastModifiedDate", "ModifiedBy", "PatientID", "Status" },
                values: new object[] { new Guid("d1b551c2-f64d-4bc6-a01c-bce1f7cb711e"), new Guid("8fc5ef50-7ed0-45c4-aa12-9f5120f5d799"), new DateTime(2024, 1, 30, 5, 30, 28, 774, DateTimeKind.Utc).AddTicks(7690), "viem da day", new Guid("7e58e8f5-ad56-4129-beb0-a3c22a6b20dd"), new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "test", null, 1, new DateTime(2024, 1, 30, 5, 30, 28, 774, DateTimeKind.Utc).AddTicks(7690), new Guid("8fc5ef50-7ed0-45c4-aa12-9f5120f5d799"), new Guid("dbaf0216-ad5d-45a6-bf60-e6975ca9961e"), 1 });

            migrationBuilder.InsertData(
                table: "Pill",
                columns: new[] { "PillId", "Afternoon", "CreatedBy", "CreatedDate", "DateEnd", "DateStart", "DosagePerDay", "Evening", "Index", "LastModifiedDate", "ModifiedBy", "Morning", "Period", "PillDescription", "PillName", "PrescriptionId", "Quantity", "QuantityPerDose", "Status", "Unit" },
                values: new object[,]
                {
                    { new Guid("07b8bae5-0cdb-4f8c-90a5-b6749fb0f7d9"), 0, new Guid("8fc5ef50-7ed0-45c4-aa12-9f5120f5d799"), new DateTime(2024, 1, 30, 5, 30, 28, 774, DateTimeKind.Utc).AddTicks(7713), null, null, 1, 0, 1, new DateTime(2024, 1, 30, 5, 30, 28, 774, DateTimeKind.Utc).AddTicks(7714), new Guid("8fc5ef50-7ed0-45c4-aa12-9f5120f5d799"), 1, "ngay", "1 ngay uong 1 vien 30 phut sau khi an", "Nexium mup", new Guid("d1b551c2-f64d-4bc6-a01c-bce1f7cb711e"), 30, 1, 1, "vien" },
                    { new Guid("56c35107-7373-4e4a-b879-474303892dc0"), 0, new Guid("8fc5ef50-7ed0-45c4-aa12-9f5120f5d799"), new DateTime(2024, 1, 30, 5, 30, 28, 774, DateTimeKind.Utc).AddTicks(7728), null, null, 2, 1, 1, new DateTime(2024, 1, 30, 5, 30, 28, 774, DateTimeKind.Utc).AddTicks(7728), new Guid("8fc5ef50-7ed0-45c4-aa12-9f5120f5d799"), 1, "ngay", "1 ngay uong 2 vien chia lam 2 lan(sang, toi - sau khi an)", "Amoxycilin", new Guid("d1b551c2-f64d-4bc6-a01c-bce1f7cb711e"), 20, 1, 1, "vien" }
                });
        }
    }
}
