using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                name: "SubscriptionPackage",
                columns: table => new
                {
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_SubscriptionPackage", x => x.SubscriptionId);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
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
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                        name: "FK_CustomerPackage_SubscriptionPackage_SubcriptionPackageId",
                        column: x => x.SubcriptionPackageId,
                        principalTable: "SubscriptionPackage",
                        principalColumn: "SubscriptionId");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    TotalItem = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    OrderId_PayOS = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
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

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    PrescriptionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExaminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageBase64 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                    SubscriptionPackageSubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_TransactionHistory_SubscriptionPackage_SubscriptionPackageSubscriptionId",
                        column: x => x.SubscriptionPackageSubscriptionId,
                        principalTable: "SubscriptionPackage",
                        principalColumn: "SubscriptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID");
                    table.ForeignKey(
                        name: "FK_OrderDetail_SubscriptionPackage_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "SubscriptionPackage",
                        principalColumn: "SubscriptionId");
                });

            migrationBuilder.CreateTable(
                name: "Pill",
                columns: table => new
                {
                    PillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PillName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PillDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    PillManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pill", x => x.PillId);
                    table.ForeignKey(
                        name: "FK_Pill_PillManager_PillManagerId",
                        column: x => x.PillManagerId,
                        principalTable: "PillManager",
                        principalColumn: "PillManagerId");
                    table.ForeignKey(
                        name: "FK_Pill_Prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescription",
                        principalColumn: "PrescriptionID");
                });

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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPackage_PatientId",
                table: "CustomerPackage",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPackage_SubcriptionPackageId",
                table: "CustomerPackage",
                column: "SubcriptionPackageId");

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
                name: "IX_Order_PatientId",
                table: "Order",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderID",
                table: "OrderDetail",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_SubscriptionId",
                table: "OrderDetail",
                column: "SubscriptionId");

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
                name: "IX_Pill_PillManagerId",
                table: "Pill",
                column: "PillManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Pill_PrescriptionId",
                table: "Pill",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_PillManager_PatientId",
                table: "PillManager",
                column: "PatientId");

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
                name: "IX_TransactionHistory_SubscriptionPackageSubscriptionId",
                table: "TransactionHistory",
                column: "SubscriptionPackageSubscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CustomerPackage");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Pill");

            migrationBuilder.DropTable(
                name: "TransactionHistory");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "PillManager");

            migrationBuilder.DropTable(
                name: "Prescription");

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
