using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarhangbookStore.DataModel.Migrations
{
    /// <inheritdoc />
    public partial class MIG_Dbinit_AllTables_14021030 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "TBLProductCategories",
                columns: table => new
                {
                    Categoryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryFaTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryEnTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SubCategory = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLProductCategories", x => x.Categoryid);
                    table.ForeignKey(
                        name: "FK_TBLProductCategories_TBLProductCategories_SubCategory",
                        column: x => x.SubCategory,
                        principalTable: "TBLProductCategories",
                        principalColumn: "Categoryid");
                });

            migrationBuilder.CreateTable(
                name: "TBLProductGroupBooks",
                columns: table => new
                {
                    GroupBookid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupBookTitle = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLProductGroupBooks", x => x.GroupBookid);
                });

            migrationBuilder.CreateTable(
                name: "TBLProductPublishers",
                columns: table => new
                {
                    Publisherid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherFaTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PublisherEnTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLProductPublishers", x => x.Publisherid);
                });

            migrationBuilder.CreateTable(
                name: "TBLProductSizeBooks",
                columns: table => new
                {
                    SizeBookid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeBookName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    SizeBookRange = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLProductSizeBooks", x => x.SizeBookid);
                });

            migrationBuilder.CreateTable(
                name: "TBLProductWriters",
                columns: table => new
                {
                    Writerid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WriterFaTitle = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLProductWriters", x => x.Writerid);
                });

            migrationBuilder.CreateTable(
                name: "TBLPropertyNames",
                columns: table => new
                {
                    PropertyNameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyTitle = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLPropertyNames", x => x.PropertyNameId);
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
                name: "TBLProducts",
                columns: table => new
                {
                    Productid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductFaTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProductEnTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publishers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Published = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Circulation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Writer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductImageAlt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SlugNamaak = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductSell = table.Column<int>(type: "int", nullable: false),
                    ProductGrade = table.Column<byte>(type: "tinyint", nullable: false),
                    ProductTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductWeith = table.Column<int>(type: "int", maxLength: 10000, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Categoryid = table.Column<int>(type: "int", nullable: false),
                    Publisherid = table.Column<int>(type: "int", nullable: false),
                    Writerid = table.Column<int>(type: "int", nullable: false),
                    SizeBookid = table.Column<int>(type: "int", nullable: false),
                    GroupBookid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLProducts", x => x.Productid);
                    table.ForeignKey(
                        name: "FK_TBLProducts_TBLProductCategories_Categoryid",
                        column: x => x.Categoryid,
                        principalTable: "TBLProductCategories",
                        principalColumn: "Categoryid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLProducts_TBLProductGroupBooks_GroupBookid",
                        column: x => x.GroupBookid,
                        principalTable: "TBLProductGroupBooks",
                        principalColumn: "GroupBookid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLProducts_TBLProductPublishers_Publisherid",
                        column: x => x.Publisherid,
                        principalTable: "TBLProductPublishers",
                        principalColumn: "Publisherid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLProducts_TBLProductSizeBooks_SizeBookid",
                        column: x => x.SizeBookid,
                        principalTable: "TBLProductSizeBooks",
                        principalColumn: "SizeBookid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLProducts_TBLProductWriters_Writerid",
                        column: x => x.Writerid,
                        principalTable: "TBLProductWriters",
                        principalColumn: "Writerid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBLPropertyNameCategories",
                columns: table => new
                {
                    pncId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyNameId = table.Column<int>(type: "int", nullable: false),
                    Categoryid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLPropertyNameCategories", x => x.pncId);
                    table.ForeignKey(
                        name: "FK_TBLPropertyNameCategories_TBLProductCategories_Categoryid",
                        column: x => x.Categoryid,
                        principalTable: "TBLProductCategories",
                        principalColumn: "Categoryid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLPropertyNameCategories_TBLPropertyNames_PropertyNameId",
                        column: x => x.PropertyNameId,
                        principalTable: "TBLPropertyNames",
                        principalColumn: "PropertyNameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBLProductFaviorates",
                columns: table => new
                {
                    Faviorateid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Productid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLProductFaviorates", x => x.Faviorateid);
                    table.ForeignKey(
                        name: "FK_TBLProductFaviorates_TBLProducts_Productid",
                        column: x => x.Productid,
                        principalTable: "TBLProducts",
                        principalColumn: "Productid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBLProductGalleries",
                columns: table => new
                {
                    galleryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Productid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLProductGalleries", x => x.galleryid);
                    table.ForeignKey(
                        name: "FK_TBLProductGalleries_TBLProducts_Productid",
                        column: x => x.Productid,
                        principalTable: "TBLProducts",
                        principalColumn: "Productid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBLProductPrices",
                columns: table => new
                {
                    Productpriceid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mainprice = table.Column<int>(type: "int", nullable: false),
                    sepcialprice = table.Column<int>(type: "int", nullable: true),
                    count = table.Column<int>(type: "int", nullable: false),
                    MaxorderCount = table.Column<int>(type: "int", nullable: false),
                    Productid = table.Column<int>(type: "int", nullable: false),
                    Createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateDisCount = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLProductPrices", x => x.Productpriceid);
                    table.ForeignKey(
                        name: "FK_TBLProductPrices_TBLProducts_Productid",
                        column: x => x.Productid,
                        principalTable: "TBLProducts",
                        principalColumn: "Productid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBLProductReatings",
                columns: table => new
                {
                    Reatingid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Productid = table.Column<int>(type: "int", nullable: false),
                    PropertyNameId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLProductReatings", x => x.Reatingid);
                    table.ForeignKey(
                        name: "FK_TBLProductReatings_TBLProducts_Productid",
                        column: x => x.Productid,
                        principalTable: "TBLProducts",
                        principalColumn: "Productid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLProductReatings_TBLPropertyNames_PropertyNameId",
                        column: x => x.PropertyNameId,
                        principalTable: "TBLPropertyNames",
                        principalColumn: "PropertyNameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBLProductReviews",
                columns: table => new
                {
                    Reviewid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reviewDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: true),
                    AticleTitle = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    ArticleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Productid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLProductReviews", x => x.Reviewid);
                    table.ForeignKey(
                        name: "FK_TBLProductReviews_TBLProducts_Productid",
                        column: x => x.Productid,
                        principalTable: "TBLProducts",
                        principalColumn: "Productid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBLPropertyValueies",
                columns: table => new
                {
                    PropertyValueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyValue = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PropertyNameId = table.Column<int>(type: "int", nullable: false),
                    Productid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLPropertyValueies", x => x.PropertyValueId);
                    table.ForeignKey(
                        name: "FK_TBLPropertyValueies_TBLProducts_Productid",
                        column: x => x.Productid,
                        principalTable: "TBLProducts",
                        principalColumn: "Productid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLPropertyValueies_TBLPropertyNames_PropertyNameId",
                        column: x => x.PropertyNameId,
                        principalTable: "TBLPropertyNames",
                        principalColumn: "PropertyNameId",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_TBLProductCategories_SubCategory",
                table: "TBLProductCategories",
                column: "SubCategory");

            migrationBuilder.CreateIndex(
                name: "IX_TBLProductFaviorates_Productid",
                table: "TBLProductFaviorates",
                column: "Productid");

            migrationBuilder.CreateIndex(
                name: "IX_TBLProductGalleries_Productid",
                table: "TBLProductGalleries",
                column: "Productid");

            migrationBuilder.CreateIndex(
                name: "IX_TBLProductPrices_Productid",
                table: "TBLProductPrices",
                column: "Productid");

            migrationBuilder.CreateIndex(
                name: "IX_TBLProductReatings_Productid",
                table: "TBLProductReatings",
                column: "Productid");

            migrationBuilder.CreateIndex(
                name: "IX_TBLProductReatings_PropertyNameId",
                table: "TBLProductReatings",
                column: "PropertyNameId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLProductReviews_Productid",
                table: "TBLProductReviews",
                column: "Productid");

            migrationBuilder.CreateIndex(
                name: "IX_TBLProducts_Categoryid",
                table: "TBLProducts",
                column: "Categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_TBLProducts_GroupBookid",
                table: "TBLProducts",
                column: "GroupBookid");

            migrationBuilder.CreateIndex(
                name: "IX_TBLProducts_Publisherid",
                table: "TBLProducts",
                column: "Publisherid");

            migrationBuilder.CreateIndex(
                name: "IX_TBLProducts_SizeBookid",
                table: "TBLProducts",
                column: "SizeBookid");

            migrationBuilder.CreateIndex(
                name: "IX_TBLProducts_Writerid",
                table: "TBLProducts",
                column: "Writerid");

            migrationBuilder.CreateIndex(
                name: "IX_TBLPropertyNameCategories_Categoryid",
                table: "TBLPropertyNameCategories",
                column: "Categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_TBLPropertyNameCategories_PropertyNameId",
                table: "TBLPropertyNameCategories",
                column: "PropertyNameId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLPropertyValueies_Productid",
                table: "TBLPropertyValueies",
                column: "Productid");

            migrationBuilder.CreateIndex(
                name: "IX_TBLPropertyValueies_PropertyNameId",
                table: "TBLPropertyValueies",
                column: "PropertyNameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "TBLProductFaviorates");

            migrationBuilder.DropTable(
                name: "TBLProductGalleries");

            migrationBuilder.DropTable(
                name: "TBLProductPrices");

            migrationBuilder.DropTable(
                name: "TBLProductReatings");

            migrationBuilder.DropTable(
                name: "TBLProductReviews");

            migrationBuilder.DropTable(
                name: "TBLPropertyNameCategories");

            migrationBuilder.DropTable(
                name: "TBLPropertyValueies");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TBLProducts");

            migrationBuilder.DropTable(
                name: "TBLPropertyNames");

            migrationBuilder.DropTable(
                name: "TBLProductCategories");

            migrationBuilder.DropTable(
                name: "TBLProductGroupBooks");

            migrationBuilder.DropTable(
                name: "TBLProductPublishers");

            migrationBuilder.DropTable(
                name: "TBLProductSizeBooks");

            migrationBuilder.DropTable(
                name: "TBLProductWriters");
        }
    }
}
