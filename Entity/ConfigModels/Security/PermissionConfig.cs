using Entity.ConfigModels.global;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Security
{
    public class PermissionConfig : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("permission", schema: "security");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();
            builder.Property(p => p.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Description)
                .HasColumnName("description")
                .IsRequired();

            builder.MapBaseModel();

            builder.HasData(
                new Permission
                {
                    Id = 1,
                    Name = "Todo",
                    Description = "Formulario de inicio"
                },
                new Permission
                {
                    Id = 2,
                    Name = "Editor",
                    Description = "Todos los permisos excepto eliminar persistentemente"
                },
                new Permission
                {
                    Id = 3,
                    Name = "Lectura",
                    Description = "Solo puede ver"
                }
            );
        }
    }
}
