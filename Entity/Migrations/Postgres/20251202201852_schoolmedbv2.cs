using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations.Postgres
{
    /// <inheritdoc />
    public partial class schoolmedbv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "security",
                table: "userRol",
                keyColumn: "id",
                keyValue: 4,
                column: "rol_id",
                value: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "security",
                table: "userRol",
                keyColumn: "id",
                keyValue: 4,
                column: "rol_id",
                value: 2);
        }
    }
}
