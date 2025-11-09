using Entity.ConfigModels.global;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Security
{
    public class RolFormPermissionConfig : IEntityTypeConfiguration<RolFormPermission>
    {
        public void Configure(EntityTypeBuilder<RolFormPermission> builder)
        {
            builder.ToTable("rolFormPermission", schema: "security");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();
            builder.Property(p => p.RolId)
                .HasColumnName("rol_id")
                .IsRequired();
            builder.Property(p => p.FormId)
                .HasColumnName("form_id")
                .IsRequired();
            builder.Property(p => p.PermissionId)
                 .HasColumnName("permission_id")
                 .IsRequired();

            // Llave foraena
            builder.HasOne(ur => ur.Rol)
               .WithMany(r => r.RolFormPermission)
               .HasForeignKey(ur => ur.RolId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ur => ur.Form)
               .WithMany(r => r.RolFormPermission)
               .HasForeignKey(ur => ur.FormId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ur => ur.Permission)
                .WithMany(r => r.RolFormPermission)
                .HasForeignKey(ur => ur.PermissionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.MapBaseModel();

            //builder.HasData(
               builder.HasData(
                    new RolFormPermission { Id = 1, RolId = 1, FormId = 1, PermissionId = 1, Status= 1},
                    new RolFormPermission { Id = 3, RolId = 1, FormId = 3, PermissionId = 1, Status= 1},
                    new RolFormPermission { Id = 4, RolId = 1, FormId = 4, PermissionId = 1, Status= 1},
                    new RolFormPermission { Id = 5, RolId = 1, FormId = 5, PermissionId = 1, Status= 1},
                    new RolFormPermission { Id = 6, RolId = 1, FormId = 6, PermissionId = 1, Status= 1},
                    new RolFormPermission { Id = 7, RolId = 1, FormId = 7, PermissionId = 1, Status= 1},
                    new RolFormPermission { Id = 8, RolId = 1, FormId = 8, PermissionId = 1, Status= 1},
                    new RolFormPermission { Id = 9, RolId = 1, FormId = 9, PermissionId = 1, Status= 1},
                    new RolFormPermission { Id = 10, RolId = 1, FormId = 10, PermissionId = 1, Status= 1 },
                    new RolFormPermission { Id = 11, RolId = 1, FormId = 11, PermissionId = 1, Status= 1 },
                    new RolFormPermission { Id = 12, RolId = 1, FormId = 12, PermissionId = 1, Status= 1 },
                    new RolFormPermission { Id = 13, RolId = 1, FormId = 13, PermissionId = 1, Status= 1 },
                    new RolFormPermission { Id = 14, RolId = 1, FormId = 14, PermissionId = 1, Status= 1 },
                    new RolFormPermission { Id = 15, RolId = 1, FormId = 15, PermissionId = 1, Status= 1 },
                    new RolFormPermission { Id = 16, RolId = 1, FormId = 16, PermissionId = 1, Status= 1 },
                    new RolFormPermission { Id = 17, RolId = 1, FormId = 17, PermissionId = 1, Status= 1 },
                    new RolFormPermission { Id = 18, RolId = 1, FormId = 18, PermissionId = 1, Status= 1 },
                    new RolFormPermission { Id = 19, RolId = 1, FormId = 19, PermissionId = 1, Status= 1 },
                    new RolFormPermission { Id = 20, RolId = 1, FormId = 20, PermissionId = 1, Status= 1 },
                    new RolFormPermission { Id = 21, RolId = 1, FormId = 21, PermissionId = 1, Status= 1 },
                    new RolFormPermission { Id = 22, RolId = 1, FormId = 22, PermissionId = 1, Status= 1 },
                    new RolFormPermission { Id = 23, RolId = 1, FormId = 23, PermissionId = 1, Status= 1 },
                    new RolFormPermission { Id = 24, RolId = 1, FormId = 24, PermissionId = 1, Status= 1 },
                    new RolFormPermission { Id = 25, RolId = 1, FormId = 25, PermissionId = 1, Status= 1 },
                    new RolFormPermission { Id = 26, RolId = 1, FormId = 26, PermissionId = 1, Status= 1 }
                    //)
           );
        }
    }
}
