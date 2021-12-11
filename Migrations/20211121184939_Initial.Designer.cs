﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockManagement.Models;

namespace StockManagement.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20211121184939_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StockManagement.Models.Customer", b =>
                {
                    b.Property<int>("customer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("item_id")
                        .HasColumnType("int");

                    b.Property<int?>("item_id1")
                        .HasColumnType("int");

                    b.Property<int?>("order_id")
                        .HasColumnType("int");

                    b.Property<string>("phone_number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("user_id")
                        .HasColumnType("int");

                    b.Property<int?>("user_id1")
                        .HasColumnType("int");

                    b.HasKey("customer_id");

                    b.HasIndex("item_id1");

                    b.HasIndex("user_id1");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("StockManagement.Models.Item", b =>
                {
                    b.Property<int>("item_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("in_stock")
                        .HasColumnType("bit");

                    b.Property<string>("item_image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("item_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("seller_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("item_id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            item_id = 101,
                            in_stock = true,
                            item_image = "Image7.jpg",
                            item_name = "Mobile",
                            price = 5000.0,
                            quantity = 40,
                            seller_name = "Sadguru"
                        },
                        new
                        {
                            item_id = 102,
                            in_stock = true,
                            item_image = "Image1.jpg",
                            item_name = "bag",
                            price = 5000.0,
                            quantity = 40,
                            seller_name = "Sadguru"
                        },
                        new
                        {
                            item_id = 103,
                            in_stock = true,
                            item_image = "Image5.jpg",
                            item_name = "Study Lamp",
                            price = 5000.0,
                            quantity = 40,
                            seller_name = "Sadguru"
                        },
                        new
                        {
                            item_id = 104,
                            in_stock = true,
                            item_image = "Image13.jpg",
                            item_name = "Night Lamp",
                            price = 5000.0,
                            quantity = 40,
                            seller_name = "Sadguru"
                        },
                        new
                        {
                            item_id = 105,
                            in_stock = true,
                            item_image = "Image7.jpg",
                            item_name = "Mobile",
                            price = 5000.0,
                            quantity = 40,
                            seller_name = "Sadguru"
                        },
                        new
                        {
                            item_id = 106,
                            in_stock = true,
                            item_image = "Image12.jpg",
                            item_name = "Watch",
                            price = 5000.0,
                            quantity = 40,
                            seller_name = "Sadguru"
                        },
                        new
                        {
                            item_id = 107,
                            in_stock = true,
                            item_image = "Image10.jpg",
                            item_name = "Tomato",
                            price = 5000.0,
                            quantity = 40,
                            seller_name = "Sadguru"
                        },
                        new
                        {
                            item_id = 108,
                            in_stock = true,
                            item_image = "Image2.jpg",
                            item_name = "Clothes",
                            price = 5000.0,
                            quantity = 40,
                            seller_name = "Sadguru"
                        },
                        new
                        {
                            item_id = 109,
                            in_stock = true,
                            item_image = "Image9.jpg",
                            item_name = "Table",
                            price = 5000.0,
                            quantity = 40,
                            seller_name = "Sadguru"
                        },
                        new
                        {
                            item_id = 100,
                            in_stock = true,
                            item_image = "Image4.jpg",
                            item_name = "Guitar",
                            price = 5000.0,
                            quantity = 40,
                            seller_name = "Sadguru"
                        });
                });

            modelBuilder.Entity("StockManagement.Models.Order", b =>
                {
                    b.Property<int>("order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("customer_id")
                        .HasColumnType("int");

                    b.Property<int?>("item_id")
                        .HasColumnType("int");

                    b.Property<int?>("item_id1")
                        .HasColumnType("int");

                    b.Property<string>("order_date")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("order_id");

                    b.HasIndex("customer_id")
                        .IsUnique()
                        .HasFilter("[customer_id] IS NOT NULL");

                    b.HasIndex("item_id1");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("StockManagement.Models.User", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("is_admin")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("user_id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            user_id = 1000,
                            is_admin = true,
                            password = "password",
                            username = "root"
                        },
                        new
                        {
                            user_id = 1001,
                            is_admin = false,
                            password = "password1",
                            username = "abc"
                        });
                });

            modelBuilder.Entity("StockManagement.Models.Customer", b =>
                {
                    b.HasOne("StockManagement.Models.Item", "item")
                        .WithMany()
                        .HasForeignKey("item_id1");

                    b.HasOne("StockManagement.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("user_id1");

                    b.Navigation("item");

                    b.Navigation("user");
                });

            modelBuilder.Entity("StockManagement.Models.Order", b =>
                {
                    b.HasOne("StockManagement.Models.Customer", "customer")
                        .WithOne("order")
                        .HasForeignKey("StockManagement.Models.Order", "customer_id");

                    b.HasOne("StockManagement.Models.Item", "item")
                        .WithMany()
                        .HasForeignKey("item_id1");

                    b.Navigation("customer");

                    b.Navigation("item");
                });

            modelBuilder.Entity("StockManagement.Models.Customer", b =>
                {
                    b.Navigation("order");
                });
#pragma warning restore 612, 618
        }
    }
}
