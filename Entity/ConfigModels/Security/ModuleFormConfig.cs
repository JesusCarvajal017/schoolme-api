using Entity.ConfigModels.global;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Security
{
    public class ModuleFormConfig : IEntityTypeConfiguration<ModuleForm>
    {
        public void Configure(EntityTypeBuilder<ModuleForm> builder)
        {
            builder.ToTable("moduleForm", schema: "security");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();
            builder.Property(p => p.ModuleId)
                .HasColumnName("module_id")
                .IsRequired();
            builder.Property(p => p.FormId)
                .HasColumnName("form_id")
                .IsRequired();

            // Llave foraena
            builder.HasOne(ur => ur.Module)
               .WithMany(r => r.ModuleForm)
               .HasForeignKey(ur => ur.ModuleId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ur => ur.Form)
               .WithMany(r => r.ModuleForm)
               .HasForeignKey(ur => ur.FormId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.MapBaseModel();

            builder.HasData(
                // ADMINISTRACIÓN
                new ModuleForm { Id = 3, ModuleId = 2, FormId = 3 },
                new ModuleForm { Id = 4, ModuleId = 2, FormId = 4 },
                new ModuleForm { Id = 5, ModuleId = 2, FormId = 5 },

                // ACADÉMICO
                new ModuleForm { Id = 6, ModuleId = 3, FormId = 6 },
                new ModuleForm { Id = 7, ModuleId = 3, FormId = 7 },
                new ModuleForm { Id = 8, ModuleId = 3, FormId = 8 },
                new ModuleForm { Id = 9, ModuleId = 3, FormId = 9 },

                // AGENDA
                new ModuleForm { Id = 10, ModuleId = 4, FormId = 10 },
                new ModuleForm { Id = 11, ModuleId = 4, FormId = 11 },

                // CONFIGURACIÓN
                new ModuleForm { Id = 13, ModuleId = 5, FormId = 13 },
                new ModuleForm { Id = 14, ModuleId = 5, FormId = 14 },
                new ModuleForm { Id = 16, ModuleId = 5, FormId = 16 },

                // SEGURIDAD
                new ModuleForm { Id = 19, ModuleId = 6, FormId = 19 },
                new ModuleForm { Id = 20, ModuleId = 6, FormId = 20 },
                new ModuleForm { Id = 21, ModuleId = 6, FormId = 21 },
                new ModuleForm { Id = 22, ModuleId = 6, FormId = 22 },
                new ModuleForm { Id = 23, ModuleId = 6, FormId = 23 },
                new ModuleForm { Id = 24, ModuleId = 6, FormId = 24 },
                new ModuleForm { Id = 25, ModuleId = 6, FormId = 25 },
                new ModuleForm { Id = 26, ModuleId = 6, FormId = 26 },


                new ModuleForm { Id = 27, ModuleId = 7, FormId = 27 },

                new ModuleForm { Id = 28, ModuleId = 3, FormId = 28 },
                new ModuleForm { Id = 29, ModuleId = 4, FormId = 29 },
                new ModuleForm { Id = 30, ModuleId = 4, FormId = 30 },
                new ModuleForm { Id = 31, ModuleId = 4, FormId = 31 },
                new ModuleForm { Id = 32, ModuleId = 4, FormId = 32 }
            );


        }
    }
}
