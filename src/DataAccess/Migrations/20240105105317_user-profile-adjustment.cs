using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class userprofileadjustment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "userProfiles",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "userProfiles",
                type: "character varying",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "JlKTW9/RTmC7MEP4vyxnwCI8J4lTiN/xkPL9Tq7o28VmqCtrx+NpG1x885bKR0gU1uMdcqCXlM6JIFe+47n9qg==", "RKUaG7gY2MKb6EdgR+joT/at/3R7FaRrTmPzNj/WFiLltYGqxYW2diKzQ1HCxWfaAuxug25MET1pDf8Yhau7N7n4UOEsFkcRQLdLp9Ye8K8/4An05OCYvAzV3Sp3hUUceswzrjxzR2mGn1Duq3kfjk6A7cEMo5l2UudNW8HVujo=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "userProfiles",
                type: "character varying",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "userProfiles",
                type: "character varying",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "TaGD8yFtY3R/AB3hdgV/lK9QqpzYMc2lo78DzBmrPEwbrq1IRI4RvtbfdE7oX7RbpHVSMk6w+J6bKR/N7UWZiQ==", "rrWiUOJzWmyfExEIZuJpbAYtEojSoYIZiMX7c5fVJE2drzmyNc8SGEvegrbYYB2cHqnWpLzQ+TRxRZ9ygt8EI4rOrDlQByJIoEdqoONni9ZiPUtf1fl9rJCwk59Gf5VAhkw+/mqBl9EyXKORRJX5Jdb6+5iQWvhj+gnGyAMP378=" });
        }
    }
}
