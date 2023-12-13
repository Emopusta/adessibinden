using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "carChassisTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carChassisTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "carFuelTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carFuelTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "carProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "computerBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_computerBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "computerOperatingSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_computerOperatingSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "computerProcessors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    Gen = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_computerProcessors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "computerRAMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Memory = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_computerRAMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "computerSSDCapacities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Capacity = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_computerSSDCapacities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "computerVideoCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Memory = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_computerVideoCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "phoneBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phoneBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "phoneInternalMemories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Capacity = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phoneInternalMemories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "phoneRAMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Memory = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phoneRAMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying", nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "carModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrandId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    ModelYear = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carModels", x => x.Id);
                    table.ForeignKey(
                        name: "BrandId_fkey",
                        column: x => x.BrandId,
                        principalTable: "carBrands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "phoneModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrandId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phoneModels", x => x.Id);
                    table.ForeignKey(
                        name: "BrandId_fkey",
                        column: x => x.BrandId,
                        principalTable: "phoneBrands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorUserId = table.Column<int>(type: "integer", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "ProductCategories_fkey",
                        column: x => x.ProductCategoryId,
                        principalTable: "productCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Product_CreatorUserId_fkey",
                        column: x => x.CreatorUserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "userProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "character varying", nullable: false),
                    LastName = table.Column<string>(type: "character varying", nullable: false),
                    Address = table.Column<string>(type: "character varying", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "carProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    CarProductCategoryId = table.Column<int>(type: "integer", nullable: false),
                    ColorId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    FuelTypeId = table.Column<int>(type: "integer", nullable: false),
                    ChassisTypeId = table.Column<int>(type: "integer", nullable: false),
                    Kilometer = table.Column<int>(type: "integer", nullable: false),
                    Gear = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    EnginePower = table.Column<int>(type: "integer", nullable: false),
                    EngineDisplacement = table.Column<int>(type: "integer", nullable: false),
                    Warranty = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carProducts", x => x.Id);
                    table.ForeignKey(
                        name: "CarProductCategoryId_fkey",
                        column: x => x.CarProductCategoryId,
                        principalTable: "carProductCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ChassisTypeId",
                        column: x => x.ChassisTypeId,
                        principalTable: "carChassisTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ColorId_fkey",
                        column: x => x.ColorId,
                        principalTable: "colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalTable: "carFuelTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ModelId",
                        column: x => x.ModelId,
                        principalTable: "carModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ProductId_fkey",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "computerProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    BrandId = table.Column<int>(type: "integer", nullable: false),
                    RAMId = table.Column<int>(type: "integer", nullable: false),
                    VideoCardId = table.Column<int>(type: "integer", nullable: false),
                    ProcessorId = table.Column<int>(type: "integer", nullable: false),
                    SSDCapacityId = table.Column<int>(type: "integer", nullable: false),
                    OperatingSystemId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_computerProducts", x => x.Id);
                    table.ForeignKey(
                        name: "BrandId_fkey",
                        column: x => x.BrandId,
                        principalTable: "computerBrands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "OperatingSystemId_fkey",
                        column: x => x.OperatingSystemId,
                        principalTable: "computerOperatingSystems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ProcessorId_fkey",
                        column: x => x.ProcessorId,
                        principalTable: "computerProcessors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ProductId_fkey",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "RAMId_fkey",
                        column: x => x.RAMId,
                        principalTable: "computerRAMs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "SSDCapacityId_fkey",
                        column: x => x.SSDCapacityId,
                        principalTable: "computerSSDCapacities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "VideoCardId_fkey",
                        column: x => x.VideoCardId,
                        principalTable: "computerVideoCards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "phoneProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ColorId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    InternalMemoryId = table.Column<int>(type: "integer", nullable: false),
                    RAMId = table.Column<int>(type: "integer", nullable: false),
                    UsageStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phoneProducts", x => x.Id);
                    table.ForeignKey(
                        name: "ColorId_fkey",
                        column: x => x.ColorId,
                        principalTable: "colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "InternalMemoryId_fkey",
                        column: x => x.InternalMemoryId,
                        principalTable: "phoneInternalMemories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ModelId_fkey",
                        column: x => x.ModelId,
                        principalTable: "phoneModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ProductId_fkey",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "RAMId_fkey",
                        column: x => x.RAMId,
                        principalTable: "phoneRAMs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "userFavouriteProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userFavouriteProducts", x => x.Id);
                    table.ForeignKey(
                        name: "ProductId_fkey",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "UserId_fkey",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_carModels_BrandId",
                table: "carModels",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_carProducts_CarProductCategoryId",
                table: "carProducts",
                column: "CarProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_carProducts_ChassisTypeId",
                table: "carProducts",
                column: "ChassisTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_carProducts_ColorId",
                table: "carProducts",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_carProducts_FuelTypeId",
                table: "carProducts",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_carProducts_ModelId",
                table: "carProducts",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_carProducts_ProductId",
                table: "carProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_computerProducts_BrandId",
                table: "computerProducts",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_computerProducts_OperatingSystemId",
                table: "computerProducts",
                column: "OperatingSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_computerProducts_ProcessorId",
                table: "computerProducts",
                column: "ProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_computerProducts_ProductId",
                table: "computerProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_computerProducts_RAMId",
                table: "computerProducts",
                column: "RAMId");

            migrationBuilder.CreateIndex(
                name: "IX_computerProducts_SSDCapacityId",
                table: "computerProducts",
                column: "SSDCapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_computerProducts_VideoCardId",
                table: "computerProducts",
                column: "VideoCardId");

            migrationBuilder.CreateIndex(
                name: "IX_phoneModels_BrandId",
                table: "phoneModels",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_phoneProducts_ColorId",
                table: "phoneProducts",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_phoneProducts_InternalMemoryId",
                table: "phoneProducts",
                column: "InternalMemoryId");

            migrationBuilder.CreateIndex(
                name: "IX_phoneProducts_ModelId",
                table: "phoneProducts",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_phoneProducts_ProductId",
                table: "phoneProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_phoneProducts_RAMId",
                table: "phoneProducts",
                column: "RAMId");

            migrationBuilder.CreateIndex(
                name: "IX_products_CreatorUserId",
                table: "products",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_products_ProductCategoryId",
                table: "products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_userFavouriteProducts_ProductId",
                table: "userFavouriteProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_userFavouriteProducts_UserId",
                table: "userFavouriteProducts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userProfiles_UserId",
                table: "userProfiles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carProducts");

            migrationBuilder.DropTable(
                name: "computerProducts");

            migrationBuilder.DropTable(
                name: "phoneProducts");

            migrationBuilder.DropTable(
                name: "userFavouriteProducts");

            migrationBuilder.DropTable(
                name: "userProfiles");

            migrationBuilder.DropTable(
                name: "carProductCategories");

            migrationBuilder.DropTable(
                name: "carChassisTypes");

            migrationBuilder.DropTable(
                name: "carFuelTypes");

            migrationBuilder.DropTable(
                name: "carModels");

            migrationBuilder.DropTable(
                name: "computerBrands");

            migrationBuilder.DropTable(
                name: "computerOperatingSystems");

            migrationBuilder.DropTable(
                name: "computerProcessors");

            migrationBuilder.DropTable(
                name: "computerRAMs");

            migrationBuilder.DropTable(
                name: "computerSSDCapacities");

            migrationBuilder.DropTable(
                name: "computerVideoCards");

            migrationBuilder.DropTable(
                name: "colors");

            migrationBuilder.DropTable(
                name: "phoneInternalMemories");

            migrationBuilder.DropTable(
                name: "phoneModels");

            migrationBuilder.DropTable(
                name: "phoneRAMs");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "carBrands");

            migrationBuilder.DropTable(
                name: "phoneBrands");

            migrationBuilder.DropTable(
                name: "productCategories");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
