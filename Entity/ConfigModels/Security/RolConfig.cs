using Entity.ConfigModels.global;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Security
{
    public class RolConfig : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("rol", schema: "security");

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
                new Rol
                {
                    Id = 1,
                    Name = "Administrador",
                    Description = "Control sobre todo",
                    Status = 1
                },
                new Rol
                {
                    Id = 2,
                    Name = "Administrativo",
                    Description = "Permisos al 90%",
                    Status = 1
                },
                new Rol
                {
                    Id = 3,
                    Name = "Docente",
                    Description = "Permisos al 30%",
                    Status = 1
                },
                new Rol
                {
                    Id = 4,
                    Name = "Acudiente",
                    Description = "Solo interactura de forma base",
                    Status = 1
                }
            );
        }
    }
}
