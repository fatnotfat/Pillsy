﻿// <auto-generated />
using System;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessObject.Migrations
{
    [DbContext(typeof(PillsyDBContext))]
    partial class PillsyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessObject.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("AccountId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Account", (string)null);

                    b.HasData(
                        new
                        {
                            AccountId = new Guid("2b1efc3d-f1b9-49c6-bfbd-cf3480531fe3"),
                            CreatedDate = new DateTime(2024, 1, 26, 20, 20, 42, 640, DateTimeKind.Utc).AddTicks(6296),
                            Email = "nguyenphat2711@gmail.com",
                            LastModifiedDate = new DateTime(2024, 1, 26, 20, 20, 42, 640, DateTimeKind.Utc).AddTicks(6299),
                            Password = "@@admin@@",
                            Role = 0,
                            Status = 1
                        },
                        new
                        {
                            AccountId = new Guid("d166440b-7cd4-4124-861f-5fce0e5d0c9c"),
                            CreatedDate = new DateTime(2024, 1, 26, 20, 20, 42, 640, DateTimeKind.Utc).AddTicks(6302),
                            Email = "dungnvse160223@fpt.edu.vn",
                            LastModifiedDate = new DateTime(2024, 1, 26, 20, 20, 42, 640, DateTimeKind.Utc).AddTicks(6303),
                            Password = "@@patient@@",
                            Role = 2,
                            Status = 1
                        },
                        new
                        {
                            AccountId = new Guid("03757b9d-60cf-483e-85ef-fc27c48657a9"),
                            CreatedDate = new DateTime(2024, 1, 26, 20, 20, 42, 640, DateTimeKind.Utc).AddTicks(6305),
                            Email = "khoatruong2509@fpt.edu.vn",
                            LastModifiedDate = new DateTime(2024, 1, 26, 20, 20, 42, 640, DateTimeKind.Utc).AddTicks(6305),
                            Password = "@@doctor@@",
                            Role = 1,
                            Status = 1
                        });
                });

            modelBuilder.Entity("BusinessObject.Appointment", b =>
                {
                    b.Property<Guid>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DoctorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("PatientID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("AppointmentID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("PatientID");

                    b.ToTable("Appointment", (string)null);
                });

            modelBuilder.Entity("BusinessObject.Doctor", b =>
                {
                    b.Property<Guid>("DoctorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("DoctorID");

                    b.HasIndex("AccountId");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("Doctor", (string)null);

                    b.HasData(
                        new
                        {
                            DoctorID = new Guid("f04b33f9-035b-4871-8e13-76966d52915d"),
                            AccountId = new Guid("03757b9d-60cf-483e-85ef-fc27c48657a9"),
                            CreatedBy = new Guid("03757b9d-60cf-483e-85ef-fc27c48657a9"),
                            CreatedDate = new DateTime(2024, 1, 26, 20, 20, 42, 640, DateTimeKind.Utc).AddTicks(6499),
                            FirstName = "Khoa",
                            LastModifiedDate = new DateTime(2024, 1, 26, 20, 20, 42, 640, DateTimeKind.Utc).AddTicks(6500),
                            LastName = "Truong",
                            ModifiedBy = new Guid("03757b9d-60cf-483e-85ef-fc27c48657a9"),
                            PhoneNumber = "0987654321",
                            Specialty = "Khoa noi"
                        });
                });

            modelBuilder.Entity("BusinessObject.Patient", b =>
                {
                    b.Property<Guid>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Gender")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PatientID");

                    b.HasIndex("AccountId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("Patient", (string)null);

                    b.HasData(
                        new
                        {
                            PatientID = new Guid("2ba2f9e4-135f-4f2f-bb9e-912e3a11c2e3"),
                            AccountId = new Guid("d166440b-7cd4-4124-861f-5fce0e5d0c9c"),
                            Address = "Bac Ninh",
                            CreatedBy = new Guid("d166440b-7cd4-4124-861f-5fce0e5d0c9c"),
                            CreatedDate = new DateTime(2024, 1, 26, 20, 20, 42, 640, DateTimeKind.Utc).AddTicks(6601),
                            DateOfBirth = new DateTime(2002, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Dung",
                            Gender = 0,
                            LastModifiedDate = new DateTime(2024, 1, 26, 20, 20, 42, 640, DateTimeKind.Utc).AddTicks(6602),
                            LastName = "Nguyen",
                            ModifiedBy = new Guid("d166440b-7cd4-4124-861f-5fce0e5d0c9c"),
                            PaymentId = new Guid("1f4ae2d5-620a-4675-9436-baf885ec8da1"),
                            PhoneNumber = "0123456789"
                        });
                });

            modelBuilder.Entity("BusinessObject.Payment", b =>
                {
                    b.Property<Guid>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.ToTable("Payment", (string)null);

                    b.HasData(
                        new
                        {
                            PaymentId = new Guid("1f4ae2d5-620a-4675-9436-baf885ec8da1"),
                            CreatedDate = new DateTime(2024, 1, 26, 20, 20, 42, 640, DateTimeKind.Utc).AddTicks(6450),
                            LastModifiedDate = new DateTime(2024, 1, 26, 20, 20, 42, 640, DateTimeKind.Utc).AddTicks(6451),
                            PaymentType = "Momo",
                            Status = 0
                        });
                });

            modelBuilder.Entity("BusinessObject.Pill", b =>
                {
                    b.Property<Guid>("PillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Afternoon")
                        .HasColumnType("int");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DosagePerDay")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Evening")
                        .HasColumnType("int");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Morning")
                        .HasColumnType("int");

                    b.Property<string>("Period")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PillDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PillName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("PrescriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("QuantityPerDose")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PillId");

                    b.HasIndex("PrescriptionId");

                    b.ToTable("Pill", (string)null);

                    b.HasData(
                        new
                        {
                            PillId = new Guid("96966c6e-2291-4e27-a2ae-9273dae671b2"),
                            Afternoon = 0,
                            CreatedBy = new Guid("d166440b-7cd4-4124-861f-5fce0e5d0c9c"),
                            CreatedDate = new DateTime(2024, 1, 26, 20, 20, 42, 640, DateTimeKind.Utc).AddTicks(6643),
                            DosagePerDay = 1,
                            Evening = 0,
                            Index = 1,
                            LastModifiedDate = new DateTime(2024, 1, 26, 20, 20, 42, 640, DateTimeKind.Utc).AddTicks(6644),
                            ModifiedBy = new Guid("d166440b-7cd4-4124-861f-5fce0e5d0c9c"),
                            Morning = 1,
                            Period = "ngay",
                            PillDescription = "1 ngay uong 1 vien 30 phut sau khi an",
                            PillName = "Nexium mup",
                            PrescriptionId = new Guid("47de07e6-229c-4a42-8b72-9d798adfc5fc"),
                            Quantity = 30,
                            QuantityPerDose = 1,
                            Status = 1,
                            Unit = "vien"
                        },
                        new
                        {
                            PillId = new Guid("045ab47d-1a87-461e-ab64-b4f85cb7fb55"),
                            Afternoon = 0,
                            CreatedBy = new Guid("d166440b-7cd4-4124-861f-5fce0e5d0c9c"),
                            CreatedDate = new DateTime(2024, 1, 26, 20, 20, 42, 640, DateTimeKind.Utc).AddTicks(6655),
                            DosagePerDay = 2,
                            Evening = 1,
                            Index = 1,
                            LastModifiedDate = new DateTime(2024, 1, 26, 20, 20, 42, 640, DateTimeKind.Utc).AddTicks(6656),
                            ModifiedBy = new Guid("d166440b-7cd4-4124-861f-5fce0e5d0c9c"),
                            Morning = 1,
                            Period = "ngay",
                            PillDescription = "1 ngay uong 2 vien chia lam 2 lan(sang, toi - sau khi an)",
                            PillName = "Amoxycilin",
                            PrescriptionId = new Guid("47de07e6-229c-4a42-8b72-9d798adfc5fc"),
                            Quantity = 20,
                            QuantityPerDose = 1,
                            Status = 1,
                            Unit = "vien"
                        });
                });

            modelBuilder.Entity("BusinessObject.Prescription", b =>
                {
                    b.Property<Guid>("PrescriptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diagnosis")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("DoctorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ExaminationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ImageBase64")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("PrescriptionID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("PatientID");

                    b.ToTable("Prescription", (string)null);

                    b.HasData(
                        new
                        {
                            PrescriptionID = new Guid("47de07e6-229c-4a42-8b72-9d798adfc5fc"),
                            CreatedBy = new Guid("d166440b-7cd4-4124-861f-5fce0e5d0c9c"),
                            CreatedDate = new DateTime(2024, 1, 26, 20, 20, 42, 640, DateTimeKind.Utc).AddTicks(6625),
                            Diagnosis = "viem da day",
                            DoctorID = new Guid("f04b33f9-035b-4871-8e13-76966d52915d"),
                            ExaminationDate = new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "test",
                            Index = 1,
                            LastModifiedDate = new DateTime(2024, 1, 26, 20, 20, 42, 640, DateTimeKind.Utc).AddTicks(6626),
                            ModifiedBy = new Guid("d166440b-7cd4-4124-861f-5fce0e5d0c9c"),
                            PatientID = new Guid("2ba2f9e4-135f-4f2f-bb9e-912e3a11c2e3"),
                            Status = 1
                        });
                });

            modelBuilder.Entity("BusinessObject.SubscriptionPackage", b =>
                {
                    b.Property<Guid>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CurrencyUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PackageType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Period")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<float>("UnitPrice")
                        .HasColumnType("real");

                    b.HasKey("PackageId");

                    b.ToTable("SubscriptionPackage", (string)null);
                });

            modelBuilder.Entity("BusinessObject.TransactionHistory", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PackageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("SubscriptionPackagePackageId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TransactionId");

                    b.HasIndex("PatientId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("SubscriptionPackagePackageId");

                    b.ToTable("TransactionHistory", (string)null);
                });

            modelBuilder.Entity("BusinessObject.Appointment", b =>
                {
                    b.HasOne("BusinessObject.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BusinessObject.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("BusinessObject.Doctor", b =>
                {
                    b.HasOne("BusinessObject.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BusinessObject.Patient", b =>
                {
                    b.HasOne("BusinessObject.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.Payment", "Payment")
                        .WithMany("Patients")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("BusinessObject.Pill", b =>
                {
                    b.HasOne("BusinessObject.Prescription", "Prescription")
                        .WithMany("Pills")
                        .HasForeignKey("PrescriptionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("BusinessObject.Prescription", b =>
                {
                    b.HasOne("BusinessObject.Doctor", "Doctor")
                        .WithMany("Prescriptions")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("BusinessObject.Patient", "Patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("BusinessObject.TransactionHistory", b =>
                {
                    b.HasOne("BusinessObject.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.SubscriptionPackage", "SubscriptionPackage")
                        .WithMany()
                        .HasForeignKey("SubscriptionPackagePackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("Payment");

                    b.Navigation("SubscriptionPackage");
                });

            modelBuilder.Entity("BusinessObject.Doctor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("BusinessObject.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("BusinessObject.Payment", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("BusinessObject.Prescription", b =>
                {
                    b.Navigation("Pills");
                });
#pragma warning restore 612, 618
        }
    }
}
