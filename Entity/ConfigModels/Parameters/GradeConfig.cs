using Entity.ConfigModels.global;
using Entity.Model.Paramters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Parameters
{
    public class GradeConfig : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            // Tabla y esquema
            builder.ToTable("grade", schema: "parameters");

            // Clave primaria
            builder.HasKey(p => p.Id);

            // Columnas
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.MapBaseModel();



            builder.HasData(
                new Grade { Id = 1, Name = "Primero", Status = 1 },
                new Grade { Id = 2, Name = "Segundo", Status = 1 },
                new Grade { Id = 3, Name = "Tercero", Status = 1 },
                new Grade { Id = 4, Name = "Cuarto", Status = 1 },
                new Grade { Id = 5, Name = "Quinto", Status = 1 }
            );


        }
    }
}
