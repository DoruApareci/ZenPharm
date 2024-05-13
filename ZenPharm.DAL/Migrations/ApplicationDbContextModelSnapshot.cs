﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZenPharm.DAL;

#nullable disable

namespace _3.ZenPharm.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1f92b138-a27e-44cd-904e-7c10eff9616e",
                            Name = "Buyer",
                            NormalizedName = "BUYER"
                        },
                        new
                        {
                            Id = "af3c4ceb-2c5f-4b07-abcc-e2cd010de7f5",
                            Name = "Moderator",
                            NormalizedName = "MODERATOR"
                        },
                        new
                        {
                            Id = "58ff34ee-ed69-4d43-9124-53ac00c07c85",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "e6452a0c-6887-4255-a10e-858e857ab2ed",
                            RoleId = "58ff34ee-ed69-4d43-9124-53ac00c07c85"
                        },
                        new
                        {
                            UserId = "40d18e53-8fdc-442b-894c-1537e18ee9c0",
                            RoleId = "af3c4ceb-2c5f-4b07-abcc-e2cd010de7f5"
                        },
                        new
                        {
                            UserId = "a0b0cd50-7fac-4b4c-9a31-0967103dcb1e",
                            RoleId = "1f92b138-a27e-44cd-904e-7c10eff9616e"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ZenPharm.DAL.Models.FeedBack", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Placed")
                        .HasColumnType("TEXT");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("FeedBacks");
                });

            modelBuilder.Entity("ZenPharm.DAL.Models.Order", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Placed")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("UserID")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ZenPharm.DAL.Models.OrderItem", b =>
                {
                    b.Property<Guid>("OrderItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("OrderID")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrderItemProductID")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderItemID");

                    b.HasIndex("OrderID");

                    b.HasIndex("OrderItemProductID");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("ZenPharm.DAL.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ProdTypeID")
                        .HasColumnType("TEXT");

                    b.Property<string>("PubId")
                        .HasColumnType("TEXT");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProdTypeID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ZenPharm.DAL.Models.ProductType", b =>
                {
                    b.Property<Guid>("ProdTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ProdTypeID");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("ZenPharm.DAL.Models.ZenPharmUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "e6452a0c-6887-4255-a10e-858e857ab2ed",
                            AccessFailedCount = 0,
                            Address = "AdminAddress",
                            ConcurrencyStamp = "fd5c3aea-d8fe-4f1f-9498-c8374051c623",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            FirstName = "AdminFirstName",
                            LastName = "AdminLastName",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAECx0E3nkS1BusXlob34/ki0P1uI6C1Olafdg6RkwpVnXGcwJtCvUGPwKwWRH5VJYGw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c3b00a82-a04b-4d05-bce0-f3e0ce2e4a82",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com"
                        },
                        new
                        {
                            Id = "40d18e53-8fdc-442b-894c-1537e18ee9c0",
                            AccessFailedCount = 0,
                            Address = "ManagerAddress",
                            ConcurrencyStamp = "95ff8626-ef06-4a0f-89af-ba99da10cbcb",
                            Email = "manager@manager.com",
                            EmailConfirmed = true,
                            FirstName = "ManagerFirstName",
                            LastName = "ManagerLastName",
                            LockoutEnabled = false,
                            NormalizedEmail = "MANAGER@MANAGER.COM",
                            NormalizedUserName = "MANAGER@MANAGER.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEMdsb1MS0ipPBk2PMIpTe8D+XAbxa7b1yPuLsjU0m6H90LPxnAX3wLNRC2FED3xxzA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "88450e27-4614-470d-a1b9-c86bff0606e4",
                            TwoFactorEnabled = false,
                            UserName = "manager@manager.com"
                        },
                        new
                        {
                            Id = "a0b0cd50-7fac-4b4c-9a31-0967103dcb1e",
                            AccessFailedCount = 0,
                            Address = "BuyerAddress",
                            ConcurrencyStamp = "50ba3114-27d7-4a74-a0c0-1d1bd97fe8bb",
                            Email = "buyer@buyer.com",
                            EmailConfirmed = true,
                            FirstName = "BuyerFirstName",
                            LastName = "BuyerLastName",
                            LockoutEnabled = false,
                            NormalizedEmail = "BUYER@BUYER.COM",
                            NormalizedUserName = "BUYER@BUYER.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEEHPgDKwfy30kJ0IB0ne9DXX5OCuoMy9XDgX5Vq8wy4oIaD2VVWEwHGLjxzr48h7mg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "cdce9b7e-0d82-41be-b7ac-54e5b422e894",
                            TwoFactorEnabled = false,
                            UserName = "buyer@buyer.com"
                        });
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
                    b.HasOne("ZenPharm.DAL.Models.ZenPharmUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ZenPharm.DAL.Models.ZenPharmUser", null)
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

                    b.HasOne("ZenPharm.DAL.Models.ZenPharmUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ZenPharm.DAL.Models.ZenPharmUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ZenPharm.DAL.Models.Order", b =>
                {
                    b.HasOne("ZenPharm.DAL.Models.ZenPharmUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ZenPharm.DAL.Models.OrderItem", b =>
                {
                    b.HasOne("ZenPharm.DAL.Models.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID");

                    b.HasOne("ZenPharm.DAL.Models.Product", "OrderItemProduct")
                        .WithMany()
                        .HasForeignKey("OrderItemProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderItemProduct");
                });

            modelBuilder.Entity("ZenPharm.DAL.Models.Product", b =>
                {
                    b.HasOne("ZenPharm.DAL.Models.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProdTypeID");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("ZenPharm.DAL.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("ZenPharm.DAL.Models.ProductType", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
