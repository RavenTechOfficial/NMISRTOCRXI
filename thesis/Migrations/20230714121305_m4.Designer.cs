﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using thesis.Data;

#nullable disable

namespace thesis.Migrations
{
    [DbContext(typeof(thesisContext))]
    [Migration("20230714121305_m4")]
    partial class m4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.5.23280.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("thesis.Areas.Identity.Data.AccountDetails", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("MeatEstablishmentId")
                        .HasColumnType("int");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Roles")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("contactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MeatEstablishmentId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("thesis.Models.Antemortem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MeatInspectionReportId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MeatInspectionReportId");

                    b.ToTable("Antemortems");
                });

            modelBuilder.Entity("thesis.Models.ConductOfInspection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AntemortemId")
                        .HasColumnType("int");

                    b.Property<int>("Cause")
                        .HasColumnType("int");

                    b.Property<int>("Issue")
                        .HasColumnType("int");

                    b.Property<int>("NoOfHeads")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AntemortemId");

                    b.ToTable("ConductOfInspections");
                });

            modelBuilder.Entity("thesis.Models.DisapprovedApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MTVInspectionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MTVInspectionId");

                    b.ToTable("DisapprovedApplications");
                });

            modelBuilder.Entity("thesis.Models.MTVApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountDetailsId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DriverLicense")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriverName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstablishmentType")
                        .HasColumnType("int");

                    b.Property<string>("HelperName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MTVDetailsId")
                        .HasColumnType("int");

                    b.Property<string>("Quiz")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Seminar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleDestination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountDetailsId");

                    b.HasIndex("MTVDetailsId");

                    b.ToTable("MTVApplications");
                });

            modelBuilder.Entity("thesis.Models.MTVApplicationResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MTVInspectionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Processed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Received")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MTVInspectionId");

                    b.ToTable("MTVApplicationResults");
                });

            modelBuilder.Entity("thesis.Models.MTVDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicantType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ControlNo")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngineNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FaxNumber")
                        .HasColumnType("int");

                    b.Property<string>("LTOCR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LTOOR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlateNo")
                        .HasColumnType("int");

                    b.Property<string>("RegisteredOwner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleMaker")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MTVDetails");
                });

            modelBuilder.Entity("thesis.Models.MTVInspection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CorrectlyInstalled")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Enclosed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Insulated")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MTVApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("PlasticCurtains")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TempControlled")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MTVApplicationId");

                    b.ToTable("MTVInspection");
                });

            modelBuilder.Entity("thesis.Models.MeatDealers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MeatEstablishmentId")
                        .HasColumnType("int");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MeatEstablishmentId");

                    b.ToTable("MeatDealers");
                });

            modelBuilder.Entity("thesis.Models.MeatEstablishment", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LicenseToOperateNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MeatEstablishment");
                });

            modelBuilder.Entity("thesis.Models.MeatInspectionReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ReceivingReportId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RepDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VerifiedByPOSMSHead")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReceivingReportId");

                    b.ToTable("MeatInspectionReports");
                });

            modelBuilder.Entity("thesis.Models.PassedForSlaughter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConductOfInspectionId")
                        .HasColumnType("int");

                    b.Property<int>("NoOfHeads")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConductOfInspectionId");

                    b.ToTable("PassedForSlaughters");
                });

            modelBuilder.Entity("thesis.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MTVApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentReceipt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MTVApplicationId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("thesis.Models.Postmortem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnimalPart")
                        .HasColumnType("int");

                    b.Property<int>("Cause")
                        .HasColumnType("int");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfHeads")
                        .HasColumnType("int");

                    b.Property<int>("PassedForSlaughterId")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PassedForSlaughterId");

                    b.ToTable("Postmortems");
                });

            modelBuilder.Entity("thesis.Models.Receiving", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountDetailsId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("RecDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountDetailsId");

                    b.ToTable("Receivings");
                });

            modelBuilder.Entity("thesis.Models.ReceivingReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BatchCode")
                        .HasColumnType("int");

                    b.Property<int?>("Category")
                        .HasColumnType("int");

                    b.Property<int?>("HoldingPenNo")
                        .HasColumnType("int");

                    b.Property<int?>("LiveWeight")
                        .HasColumnType("int");

                    b.Property<int?>("MeatDealersId")
                        .HasColumnType("int");

                    b.Property<int?>("NoOfHeads")
                        .HasColumnType("int");

                    b.Property<string>("Origin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RecTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReceivingBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReceivingId")
                        .HasColumnType("int");

                    b.Property<int>("ShippingDoc")
                        .HasColumnType("int");

                    b.Property<int?>("Species")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MeatDealersId");

                    b.HasIndex("ReceivingId");

                    b.ToTable("ReceivingReports");
                });

            modelBuilder.Entity("thesis.Models.SummaryAndDistributionOfMIC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CertificateStatus")
                        .HasColumnType("int");

                    b.Property<string>("DestinationAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalNoFitForHumanConsumptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TotalNoFitForHumanConsumptionId");

                    b.ToTable("SummaryAndDistributionOfMICs");
                });

            modelBuilder.Entity("thesis.Models.totalNoFitForHumanConsumptions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DressedWeight")
                        .HasColumnType("int");

                    b.Property<int>("NoOfHeads")
                        .HasColumnType("int");

                    b.Property<int>("PostmortemId")
                        .HasColumnType("int");

                    b.Property<int>("Species")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostmortemId");

                    b.ToTable("totalNoFitForHumanConsumptions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("thesis.Areas.Identity.Data.AccountDetails", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("thesis.Areas.Identity.Data.AccountDetails", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("thesis.Areas.Identity.Data.AccountDetails", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("thesis.Areas.Identity.Data.AccountDetails", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("thesis.Areas.Identity.Data.AccountDetails", b =>
                {
                    b.HasOne("thesis.Models.MeatEstablishment", "MeatEstablishment")
                        .WithMany()
                        .HasForeignKey("MeatEstablishmentId");

                    b.Navigation("MeatEstablishment");
                });

            modelBuilder.Entity("thesis.Models.Antemortem", b =>
                {
                    b.HasOne("thesis.Models.MeatInspectionReport", "MeatInspectionReport")
                        .WithMany()
                        .HasForeignKey("MeatInspectionReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MeatInspectionReport");
                });

            modelBuilder.Entity("thesis.Models.ConductOfInspection", b =>
                {
                    b.HasOne("thesis.Models.Antemortem", "Antemortem")
                        .WithMany()
                        .HasForeignKey("AntemortemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Antemortem");
                });

            modelBuilder.Entity("thesis.Models.DisapprovedApplication", b =>
                {
                    b.HasOne("thesis.Models.MTVInspection", "MTVInspection")
                        .WithMany()
                        .HasForeignKey("MTVInspectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MTVInspection");
                });

            modelBuilder.Entity("thesis.Models.MTVApplication", b =>
                {
                    b.HasOne("thesis.Areas.Identity.Data.AccountDetails", "AccountDetails")
                        .WithMany()
                        .HasForeignKey("AccountDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("thesis.Models.MTVDetails", "MTVDetails")
                        .WithMany()
                        .HasForeignKey("MTVDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountDetails");

                    b.Navigation("MTVDetails");
                });

            modelBuilder.Entity("thesis.Models.MTVApplicationResult", b =>
                {
                    b.HasOne("thesis.Models.MTVInspection", "MTVInspection")
                        .WithMany()
                        .HasForeignKey("MTVInspectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MTVInspection");
                });

            modelBuilder.Entity("thesis.Models.MTVInspection", b =>
                {
                    b.HasOne("thesis.Models.MTVApplication", "MTVApplication")
                        .WithMany()
                        .HasForeignKey("MTVApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MTVApplication");
                });

            modelBuilder.Entity("thesis.Models.MeatDealers", b =>
                {
                    b.HasOne("thesis.Models.MeatEstablishment", "MeatEstablishment")
                        .WithMany()
                        .HasForeignKey("MeatEstablishmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MeatEstablishment");
                });

            modelBuilder.Entity("thesis.Models.MeatInspectionReport", b =>
                {
                    b.HasOne("thesis.Models.ReceivingReport", "ReceivingReport")
                        .WithMany()
                        .HasForeignKey("ReceivingReportId");

                    b.Navigation("ReceivingReport");
                });

            modelBuilder.Entity("thesis.Models.PassedForSlaughter", b =>
                {
                    b.HasOne("thesis.Models.ConductOfInspection", "ConductOfInspection")
                        .WithMany()
                        .HasForeignKey("ConductOfInspectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConductOfInspection");
                });

            modelBuilder.Entity("thesis.Models.Payment", b =>
                {
                    b.HasOne("thesis.Models.MTVApplication", "MTVApplication")
                        .WithMany()
                        .HasForeignKey("MTVApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MTVApplication");
                });

            modelBuilder.Entity("thesis.Models.Postmortem", b =>
                {
                    b.HasOne("thesis.Models.PassedForSlaughter", "PassedForSlaughter")
                        .WithMany()
                        .HasForeignKey("PassedForSlaughterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PassedForSlaughter");
                });

            modelBuilder.Entity("thesis.Models.Receiving", b =>
                {
                    b.HasOne("thesis.Areas.Identity.Data.AccountDetails", "AccountDetails")
                        .WithMany()
                        .HasForeignKey("AccountDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountDetails");
                });

            modelBuilder.Entity("thesis.Models.ReceivingReport", b =>
                {
                    b.HasOne("thesis.Models.MeatDealers", "MeatDealers")
                        .WithMany()
                        .HasForeignKey("MeatDealersId");

                    b.HasOne("thesis.Models.Receiving", "Receiving")
                        .WithMany()
                        .HasForeignKey("ReceivingId");

                    b.Navigation("MeatDealers");

                    b.Navigation("Receiving");
                });

            modelBuilder.Entity("thesis.Models.SummaryAndDistributionOfMIC", b =>
                {
                    b.HasOne("thesis.Models.totalNoFitForHumanConsumptions", "TotalNoFitForHumanConsumption")
                        .WithMany()
                        .HasForeignKey("TotalNoFitForHumanConsumptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TotalNoFitForHumanConsumption");
                });

            modelBuilder.Entity("thesis.Models.totalNoFitForHumanConsumptions", b =>
                {
                    b.HasOne("thesis.Models.Postmortem", "Postmortem")
                        .WithMany()
                        .HasForeignKey("PostmortemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Postmortem");
                });
#pragma warning restore 612, 618
        }
    }
}
