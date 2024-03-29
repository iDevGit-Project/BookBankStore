﻿// <auto-generated />
using System;
using FarhangbookStore.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FarhangbookStore.DataModel.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240120120735_MIG_Dbinit_AllTables_14021030")]
    partial class MIG_Dbinit_AllTables_14021030
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_Product", b =>
                {
                    b.Property<int>("Productid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Productid"));

                    b.Property<int>("Categoryid")
                        .HasColumnType("int");

                    b.Property<string>("Circulation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupBookid")
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Keywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ProductCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductEnTitle")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ProductFaTitle")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<byte>("ProductGrade")
                        .HasColumnType("tinyint");

                    b.Property<string>("ProductImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductImageAlt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductImageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductSell")
                        .HasColumnType("int");

                    b.Property<string>("ProductTag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ProductUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductWeith")
                        .HasMaxLength(10000)
                        .HasColumnType("int");

                    b.Property<string>("Published")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Publisherid")
                        .HasColumnType("int");

                    b.Property<string>("Publishers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SizeBookid")
                        .HasColumnType("int");

                    b.Property<string>("SlugNamaak")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Writer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Writerid")
                        .HasColumnType("int");

                    b.HasKey("Productid");

                    b.HasIndex("Categoryid");

                    b.HasIndex("GroupBookid");

                    b.HasIndex("Publisherid");

                    b.HasIndex("SizeBookid");

                    b.HasIndex("Writerid");

                    b.ToTable("TBLProducts");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_ProductCategory", b =>
                {
                    b.Property<int>("Categoryid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Categoryid"));

                    b.Property<string>("CategoryEnTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CategoryFaTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int?>("SubCategory")
                        .HasColumnType("int");

                    b.HasKey("Categoryid");

                    b.HasIndex("SubCategory");

                    b.ToTable("TBLProductCategories");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_ProductFaviorate", b =>
                {
                    b.Property<int>("Faviorateid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Faviorateid"));

                    b.Property<int>("Productid")
                        .HasColumnType("int");

                    b.HasKey("Faviorateid");

                    b.HasIndex("Productid");

                    b.ToTable("TBLProductFaviorates");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_ProductGallery", b =>
                {
                    b.Property<int>("galleryid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("galleryid"));

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Productid")
                        .HasColumnType("int");

                    b.HasKey("galleryid");

                    b.HasIndex("Productid");

                    b.ToTable("TBLProductGalleries");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_ProductGroupBooks", b =>
                {
                    b.Property<int>("GroupBookid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupBookid"));

                    b.Property<string>("GroupBookTitle")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("GroupBookid");

                    b.ToTable("TBLProductGroupBooks");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_ProductPrice", b =>
                {
                    b.Property<int>("Productpriceid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Productpriceid"));

                    b.Property<DateTime>("Createdate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDateDisCount")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxorderCount")
                        .HasColumnType("int");

                    b.Property<int>("Productid")
                        .HasColumnType("int");

                    b.Property<int>("count")
                        .HasColumnType("int");

                    b.Property<int>("mainprice")
                        .HasColumnType("int");

                    b.Property<int?>("sepcialprice")
                        .HasColumnType("int");

                    b.HasKey("Productpriceid");

                    b.HasIndex("Productid");

                    b.ToTable("TBLProductPrices");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_ProductPublisher", b =>
                {
                    b.Property<int>("Publisherid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Publisherid"));

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("PublisherEnTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PublisherFaTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Publisherid");

                    b.ToTable("TBLProductPublishers");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_ProductReating", b =>
                {
                    b.Property<int>("Reatingid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Reatingid"));

                    b.Property<int>("Productid")
                        .HasColumnType("int");

                    b.Property<int>("PropertyNameId")
                        .HasColumnType("int");

                    b.Property<byte>("Value")
                        .HasColumnType("tinyint");

                    b.HasKey("Reatingid");

                    b.HasIndex("Productid");

                    b.HasIndex("PropertyNameId");

                    b.ToTable("TBLProductReatings");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_ProductReview", b =>
                {
                    b.Property<int>("Reviewid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Reviewid"));

                    b.Property<string>("ArticleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AticleTitle")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Productid")
                        .HasColumnType("int");

                    b.Property<string>("reviewDescription")
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Reviewid");

                    b.HasIndex("Productid");

                    b.ToTable("TBLProductReviews");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_ProductSizeBook", b =>
                {
                    b.Property<int>("SizeBookid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SizeBookid"));

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("SizeBookName")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("SizeBookRange")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("SizeBookid");

                    b.ToTable("TBLProductSizeBooks");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_ProductWriter", b =>
                {
                    b.Property<int>("Writerid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Writerid"));

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("WriterFaTitle")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Writerid");

                    b.ToTable("TBLProductWriters");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_PropertyName", b =>
                {
                    b.Property<int>("PropertyNameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropertyNameId"));

                    b.Property<string>("PropertyTitle")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.HasKey("PropertyNameId");

                    b.ToTable("TBLPropertyNames");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_PropertyName_Category", b =>
                {
                    b.Property<int>("pncId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("pncId"));

                    b.Property<int>("Categoryid")
                        .HasColumnType("int");

                    b.Property<int>("PropertyNameId")
                        .HasColumnType("int");

                    b.HasKey("pncId");

                    b.HasIndex("Categoryid");

                    b.HasIndex("PropertyNameId");

                    b.ToTable("TBLPropertyNameCategories");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_PropertyValue", b =>
                {
                    b.Property<int>("PropertyValueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropertyValueId"));

                    b.Property<int>("Productid")
                        .HasColumnType("int");

                    b.Property<int>("PropertyNameId")
                        .HasColumnType("int");

                    b.Property<string>("PropertyValue")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("PropertyValueId");

                    b.HasIndex("Productid");

                    b.HasIndex("PropertyNameId");

                    b.ToTable("TBLPropertyValueies");
                });

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
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

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_Product", b =>
                {
                    b.HasOne("FarhangbookStore.DataModel.Entities.TBL_ProductCategory", "TBLProductCategorys")
                        .WithMany("TBLProducts")
                        .HasForeignKey("Categoryid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarhangbookStore.DataModel.Entities.TBL_ProductGroupBooks", "TBLProductGroupBooks")
                        .WithMany()
                        .HasForeignKey("GroupBookid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarhangbookStore.DataModel.Entities.TBL_ProductPublisher", "TBLProductPublishers")
                        .WithMany()
                        .HasForeignKey("Publisherid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarhangbookStore.DataModel.Entities.TBL_ProductSizeBook", "TBLProductSizeBooks")
                        .WithMany()
                        .HasForeignKey("SizeBookid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarhangbookStore.DataModel.Entities.TBL_ProductWriter", "TBLProductWriters")
                        .WithMany()
                        .HasForeignKey("Writerid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TBLProductCategorys");

                    b.Navigation("TBLProductGroupBooks");

                    b.Navigation("TBLProductPublishers");

                    b.Navigation("TBLProductSizeBooks");

                    b.Navigation("TBLProductWriters");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_ProductCategory", b =>
                {
                    b.HasOne("FarhangbookStore.DataModel.Entities.TBL_ProductCategory", "Categori")
                        .WithMany()
                        .HasForeignKey("SubCategory");

                    b.Navigation("Categori");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_ProductFaviorate", b =>
                {
                    b.HasOne("FarhangbookStore.DataModel.Entities.TBL_Product", "TBLProducts")
                        .WithMany()
                        .HasForeignKey("Productid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TBLProducts");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_ProductGallery", b =>
                {
                    b.HasOne("FarhangbookStore.DataModel.Entities.TBL_Product", "TBLProducts")
                        .WithMany()
                        .HasForeignKey("Productid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TBLProducts");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_ProductPrice", b =>
                {
                    b.HasOne("FarhangbookStore.DataModel.Entities.TBL_Product", "TBLProducts")
                        .WithMany()
                        .HasForeignKey("Productid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TBLProducts");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_ProductReating", b =>
                {
                    b.HasOne("FarhangbookStore.DataModel.Entities.TBL_Product", "TBLProducts")
                        .WithMany()
                        .HasForeignKey("Productid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarhangbookStore.DataModel.Entities.TBL_PropertyName", "TBLPropertyNames")
                        .WithMany("TBLProductReatings")
                        .HasForeignKey("PropertyNameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TBLProducts");

                    b.Navigation("TBLPropertyNames");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_ProductReview", b =>
                {
                    b.HasOne("FarhangbookStore.DataModel.Entities.TBL_Product", "TBLProducts")
                        .WithMany()
                        .HasForeignKey("Productid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TBLProducts");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_PropertyName_Category", b =>
                {
                    b.HasOne("FarhangbookStore.DataModel.Entities.TBL_ProductCategory", "TBLProductCategorys")
                        .WithMany("TBLPropertyNameCategories")
                        .HasForeignKey("Categoryid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarhangbookStore.DataModel.Entities.TBL_PropertyName", "TBLPropertyNames")
                        .WithMany("TBLPropertyNameCategories")
                        .HasForeignKey("PropertyNameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TBLProductCategorys");

                    b.Navigation("TBLPropertyNames");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_PropertyValue", b =>
                {
                    b.HasOne("FarhangbookStore.DataModel.Entities.TBL_Product", "TBLProducts")
                        .WithMany()
                        .HasForeignKey("Productid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FarhangbookStore.DataModel.Entities.TBL_PropertyName", "TBLPropertyNames")
                        .WithMany("TBLPropertyValues")
                        .HasForeignKey("PropertyNameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TBLProducts");

                    b.Navigation("TBLPropertyNames");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_ProductCategory", b =>
                {
                    b.Navigation("TBLProducts");

                    b.Navigation("TBLPropertyNameCategories");
                });

            modelBuilder.Entity("FarhangbookStore.DataModel.Entities.TBL_PropertyName", b =>
                {
                    b.Navigation("TBLProductReatings");

                    b.Navigation("TBLPropertyNameCategories");

                    b.Navigation("TBLPropertyValues");
                });
#pragma warning restore 612, 618
        }
    }
}
