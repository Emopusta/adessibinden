using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class colorsuniqueindex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userFavouriteProducts",
                table: "userFavouriteProducts");

            migrationBuilder.DropIndex(
                name: "IX_userFavouriteProducts_UserId",
                table: "userFavouriteProducts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "userFavouriteProducts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "userFavouriteProducts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "userFavouriteProducts");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "userFavouriteProducts");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "products",
                type: "character varying",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userFavouriteProducts",
                table: "userFavouriteProducts",
                columns: new[] { "UserId", "ProductId" });

            migrationBuilder.InsertData(
                table: "colors",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Red", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Green", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yellow", null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blue", null }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "z+8s+gmAdF2A/yxh7b8UsZ55iyacKb/iNoAwf62EVum/MmQ4Ix9GlS0o1Hhfuu/1f5toCjf3/i3gF29kScH1MQ==", "rVcnkzFAfvma0MeKnXzArhrHLw4ctBu9o45haT8Q79Rr0z4gMCrfb+ouorY+Uac6WAE3UCLtevULkd0i2c47yUKDBKUp/hajFvikrBDNlLDtNlBRy/kvRJOI/Sx+I/Me3KmbXDaV7Bqn+EKoQWQYP/hkRZlzpDY2eOz64yjAkOk=" });

            migrationBuilder.CreateIndex(
                name: "IX_colors_Name",
                table: "colors",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userFavouriteProducts",
                table: "userFavouriteProducts");

            migrationBuilder.DropIndex(
                name: "IX_colors_Name",
                table: "colors");

            migrationBuilder.DeleteData(
                table: "colors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "colors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "colors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "colors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Title",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "userFavouriteProducts",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "userFavouriteProducts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "userFavouriteProducts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "userFavouriteProducts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_userFavouriteProducts",
                table: "userFavouriteProducts",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "sOu9h4ZZKabeS0fUigYDlkbFAGO0ervuQa3zJx8h7++H5fgtzQXdJZF54re9pF7c1eni/HpPm5LBD3A9ACM61A==", "xFC/T28J2Hwaagk7zeJEJCYR4EW+lE3OQ6r6z4EyVv9W0jvLH0998F1mYEFRzI8S7TFYXBeLFflbXwe5G7f0TvBVfP8JxoSpuTA/M2Od8Asw21MhKF7ppS5XkgwxW/5EvgOOQIHCZnQzssHbQAJ0oPCTIP1EmJ4PP8wRYQJglU4=" });

            migrationBuilder.CreateIndex(
                name: "IX_userFavouriteProducts_UserId",
                table: "userFavouriteProducts",
                column: "UserId");
        }
    }
}
