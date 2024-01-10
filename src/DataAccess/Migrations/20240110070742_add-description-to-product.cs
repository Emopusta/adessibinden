using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class adddescriptiontoproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "products",
                type: "character varying",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "sOu9h4ZZKabeS0fUigYDlkbFAGO0ervuQa3zJx8h7++H5fgtzQXdJZF54re9pF7c1eni/HpPm5LBD3A9ACM61A==", "xFC/T28J2Hwaagk7zeJEJCYR4EW+lE3OQ6r6z4EyVv9W0jvLH0998F1mYEFRzI8S7TFYXBeLFflbXwe5G7f0TvBVfP8JxoSpuTA/M2Od8Asw21MhKF7ppS5XkgwxW/5EvgOOQIHCZnQzssHbQAJ0oPCTIP1EmJ4PP8wRYQJglU4=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "products");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "JlKTW9/RTmC7MEP4vyxnwCI8J4lTiN/xkPL9Tq7o28VmqCtrx+NpG1x885bKR0gU1uMdcqCXlM6JIFe+47n9qg==", "RKUaG7gY2MKb6EdgR+joT/at/3R7FaRrTmPzNj/WFiLltYGqxYW2diKzQ1HCxWfaAuxug25MET1pDf8Yhau7N7n4UOEsFkcRQLdLp9Ye8K8/4An05OCYvAzV3Sp3hUUceswzrjxzR2mGn1Duq3kfjk6A7cEMo5l2UudNW8HVujo=" });
        }
    }
}
