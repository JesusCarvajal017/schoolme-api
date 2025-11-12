using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations.Postgres
{
    /// <inheritdoc />
    public partial class schoolmedb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "security",
                table: "moduleForm",
                columns: new[] { "id", "created_at", "deleted_at", "form_id", "module_id", "status", "updated_at" },
                values: new object[] { 27, null, null, 27, 7, 1, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "security",
                table: "moduleForm",
                keyColumn: "id",
                keyValue: 27);
        }
    }
}
