using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                name: "CarBrands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarChassisTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarChassisTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarFuelTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarFuelTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComputerBrands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComputerOperatingSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerOperatingSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComputerProcessors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    Gen = table.Column<short>(type: "smallint", nullable: true),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerProcessors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComputerRAMs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Memory = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerRAMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComputerSSDCapacities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Capacity = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerSSDCapacities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComputerVideoCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Memory = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerVideoCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneBrands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneInternalMemories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Capacity = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneInternalMemories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneRAMs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Memory = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneRAMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying", nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BrandId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    ModelYear = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                    table.ForeignKey(
                        name: "BrandId_fkey",
                        column: x => x.BrandId,
                        principalTable: "CarBrands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhoneModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BrandId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneModels", x => x.Id);
                    table.ForeignKey(
                        name: "BrandId_fkey",
                        column: x => x.BrandId,
                        principalTable: "PhoneBrands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "ProductCategories_fkey",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Product_CreatorUserId_fkey",
                        column: x => x.CreatorUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying", nullable: false),
                    LastName = table.Column<string>(type: "character varying", nullable: false),
                    Address = table.Column<string>(type: "character varying", nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CarProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    CarProductCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    ColorId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    FuelTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChassisTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Kilometer = table.Column<int>(type: "integer", nullable: false),
                    Gear = table.Column<short>(type: "smallint", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    EnginePower = table.Column<short>(type: "smallint", nullable: false),
                    EngineDisplacement = table.Column<short>(type: "smallint", nullable: false),
                    Warranty = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarProducts", x => x.Id);
                    table.ForeignKey(
                        name: "CarProductCategoryId_fkey",
                        column: x => x.CarProductCategoryId,
                        principalTable: "CarProductCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ChassisTypeId",
                        column: x => x.ChassisTypeId,
                        principalTable: "CarChassisTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ColorId_fkey",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalTable: "CarFuelTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ModelId",
                        column: x => x.ModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ProductId_fkey",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComputerProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    BrandId = table.Column<Guid>(type: "uuid", nullable: false),
                    RAMId = table.Column<Guid>(type: "uuid", nullable: false),
                    VideoCardId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProcessorId = table.Column<Guid>(type: "uuid", nullable: false),
                    SSDCapacityId = table.Column<Guid>(type: "uuid", nullable: false),
                    OperatingSystemId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerProducts", x => x.Id);
                    table.ForeignKey(
                        name: "BrandId_fkey",
                        column: x => x.BrandId,
                        principalTable: "ComputerBrands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "OperatingSystemId_fkey",
                        column: x => x.OperatingSystemId,
                        principalTable: "ComputerOperatingSystems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ProcessorId_fkey",
                        column: x => x.ProcessorId,
                        principalTable: "ComputerProcessors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ProductId_fkey",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "RAMId_fkey",
                        column: x => x.RAMId,
                        principalTable: "ComputerRAMs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "SSDCapacityId_fkey",
                        column: x => x.SSDCapacityId,
                        principalTable: "ComputerSSDCapacities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "VideoCardId_fkey",
                        column: x => x.VideoCardId,
                        principalTable: "ComputerVideoCards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhoneProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    ColorId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    InternalMemoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    RAMId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsageStatus = table.Column<bool>(type: "boolean", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneProducts", x => x.Id);
                    table.ForeignKey(
                        name: "ColorId_fkey",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "InternalMemoryId_fkey",
                        column: x => x.InternalMemoryId,
                        principalTable: "PhoneInternalMemories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ModelId_fkey",
                        column: x => x.ModelId,
                        principalTable: "PhoneModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ProductId_fkey",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "RAMId_fkey",
                        column: x => x.RAMId,
                        principalTable: "PhoneRAMs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserFavouriteProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavouriteProducts", x => x.Id);
                    table.ForeignKey(
                        name: "ProductId_fkey",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "UserId_fkey",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_BrandId",
                table: "CarModels",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CarProducts_CarProductCategoryId",
                table: "CarProducts",
                column: "CarProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CarProducts_ChassisTypeId",
                table: "CarProducts",
                column: "ChassisTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarProducts_ColorId",
                table: "CarProducts",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_CarProducts_FuelTypeId",
                table: "CarProducts",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarProducts_ModelId",
                table: "CarProducts",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CarProducts_ProductId",
                table: "CarProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerProducts_BrandId",
                table: "ComputerProducts",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerProducts_OperatingSystemId",
                table: "ComputerProducts",
                column: "OperatingSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerProducts_ProcessorId",
                table: "ComputerProducts",
                column: "ProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerProducts_ProductId",
                table: "ComputerProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerProducts_RAMId",
                table: "ComputerProducts",
                column: "RAMId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerProducts_SSDCapacityId",
                table: "ComputerProducts",
                column: "SSDCapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerProducts_VideoCardId",
                table: "ComputerProducts",
                column: "VideoCardId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneModels_BrandId",
                table: "PhoneModels",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneProducts_ColorId",
                table: "PhoneProducts",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneProducts_InternalMemoryId",
                table: "PhoneProducts",
                column: "InternalMemoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneProducts_ModelId",
                table: "PhoneProducts",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneProducts_ProductId",
                table: "PhoneProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneProducts_RAMId",
                table: "PhoneProducts",
                column: "RAMId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatorUserId",
                table: "Products",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavouriteProducts_ProductId",
                table: "UserFavouriteProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavouriteProducts_UserId",
                table: "UserFavouriteProducts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarProducts");

            migrationBuilder.DropTable(
                name: "ComputerProducts");

            migrationBuilder.DropTable(
                name: "PhoneProducts");

            migrationBuilder.DropTable(
                name: "UserFavouriteProducts");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "CarProductCategories");

            migrationBuilder.DropTable(
                name: "CarChassisTypes");

            migrationBuilder.DropTable(
                name: "CarFuelTypes");

            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "ComputerBrands");

            migrationBuilder.DropTable(
                name: "ComputerOperatingSystems");

            migrationBuilder.DropTable(
                name: "ComputerProcessors");

            migrationBuilder.DropTable(
                name: "ComputerRAMs");

            migrationBuilder.DropTable(
                name: "ComputerSSDCapacities");

            migrationBuilder.DropTable(
                name: "ComputerVideoCards");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "PhoneInternalMemories");

            migrationBuilder.DropTable(
                name: "PhoneModels");

            migrationBuilder.DropTable(
                name: "PhoneRAMs");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "CarBrands");

            migrationBuilder.DropTable(
                name: "PhoneBrands");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
