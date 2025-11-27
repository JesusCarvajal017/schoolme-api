using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations.Postgres
{
    public partial class schoolmedb_v5 : Migration
    /// <inheritdoc />
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "parameters",
                table: "type_answare",
                columns: new[] { "id", "created_at", "deleted_at", "description", "name", "status", "updated_at" },
                values: new object[] { 6, null, null, "Selección de opción múltiple", "OptionMulti", 1, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "parameters",
                table: "type_answare",
                keyColumn: "id",
                keyValue: 6);
        }
    }
}
