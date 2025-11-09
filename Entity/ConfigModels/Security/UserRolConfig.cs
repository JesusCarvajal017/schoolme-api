using Entity.ConfigModels.global;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Security
{
    public class UserRolConfig : IEntityTypeConfiguration<UserRol>
    {
        public void Configure(EntityTypeBuilder<UserRol> builder)
        {
            builder.ToTable("userRol", schema: "security");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();
            builder.Property(p => p.UserId)
                .HasColumnName("user_id")
                .IsRequired();
            builder.Property(p => p.RolId)
                .HasColumnName("rol_id")
                .IsRequired();

            // Llave foraena
            builder.HasOne(ur => ur.Rol)
               .WithMany(r => r.UserRol)
               .HasForeignKey(ur => ur.RolId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ur => ur.User)
               .WithMany(r => r.UserRol)
               .HasForeignKey(ur => ur.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.MapBaseModel();

            builder.HasData(
                new UserRol
                {
                    Id = 1,
                    UserId = 1,
                    RolId = 1,
                    Status = 1,
                },
                new UserRol
                {
                    Id = 2,
                    UserId = 2,
                    RolId = 2,
                    Status = 1,
                },
                new UserRol
                {
                    Id = 3,
                    UserId = 3,
                    RolId = 3,
                    Status = 1,
                },
                new UserRol
                {
                    Id = 4,
                    UserId = 4,
                    RolId = 2,
                    Status = 1,
                },
                new UserRol
                {
                    Id = 5,
                    UserId = 5,
                    RolId = 4,
                    Status = 1,
                }
            );

        }
    }
}
