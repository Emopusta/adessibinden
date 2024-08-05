using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateproductinteractioncounttablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interactionCounts_products_ProductId",
                table: "interactionCounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_interactionCounts",
                table: "interactionCounts");

            migrationBuilder.RenameTable(
                name: "interactionCounts",
                newName: "productInteractionCounts");

            migrationBuilder.RenameIndex(
                name: "IX_interactionCounts_ProductId",
                table: "productInteractionCounts",
                newName: "IX_productInteractionCounts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productInteractionCounts",
                table: "productInteractionCounts",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "yy0VwtKR2DyRfl0CiBrcunScPmhLOgYAVdDLlYZh+9dvzKt6cE6xwr2TXZ2xL2b+z+F15hxs3phQiTNIOGZqyg==", "pgOIGxfpgn6Wg1hIoBknc4bxVUNLcLNcfOe3uR/Hy4BxS5jbXOZqAVEqdRKiLSRZjV5Ud//9PuZy4TTECXBK0/6/QAg2FZ3zDOeYYk7ogamCxdiW5s971eUcPmISx1EwoQQTsot1A07oRniE4DeBD83+LV0gVaxrymZWw6Rh3FY=" });

            migrationBuilder.AddForeignKey(
                name: "FK_productInteractionCounts_products_ProductId",
                table: "productInteractionCounts",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productInteractionCounts_products_ProductId",
                table: "productInteractionCounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productInteractionCounts",
                table: "productInteractionCounts");

            migrationBuilder.RenameTable(
                name: "productInteractionCounts",
                newName: "interactionCounts");

            migrationBuilder.RenameIndex(
                name: "IX_productInteractionCounts_ProductId",
                table: "interactionCounts",
                newName: "IX_interactionCounts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_interactionCounts",
                table: "interactionCounts",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "FtnOl4PqWldtm5aWYJWaM1W1FwbR2bAm92E+l5W08Qkrak1jzN97hFvTE+/0ph2nmjDHkyWxNTv8Dxzi1NYz6w==", "ex1XHt++gHPAudUgugf0c7cvBdv1BbKOSzLzNCMAfv/+JHuOAY9Kc9Af4Tet2n2L4JOVzOMpBx+hE7jotuM8CS4pYb2A8SZEtDQeS6Nkg9d8rp4JD6gEZb90Nr4Ue0Fhq1CrKW0yDKUL2G5MaHFku+fcld4UzoDGUYSYNHUIzLo=" });

            migrationBuilder.AddForeignKey(
                name: "FK_interactionCounts_products_ProductId",
                table: "interactionCounts",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
