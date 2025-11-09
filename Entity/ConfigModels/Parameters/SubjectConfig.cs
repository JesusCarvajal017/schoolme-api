using Entity.ConfigModels.global;
using Entity.Model.Paramters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Parameters
{
    public class SubjectConfig : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {

           // Tabla y esquema
            builder.ToTable("subject", schema: "parameters");

            // Clave primaria
            builder.HasKey(s => s.Id);

            // Columnas
            builder.Property(s => s.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(s => s.Name)
                .HasColumnName("name")
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);

            builder.MapBaseModel();

            builder.HasMany(s => s.AcademicLoads)
                   .WithOne(al => al.Subject)
                   .HasForeignKey(al => al.SubjectId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Subject { Id = 1, Name = "Lengua Castellana", Status = 1 },
                new Subject { Id = 2, Name = "Matemáticas", Status = 1 },
                new Subject { Id = 3, Name = "Ciencias Naturales", Status = 1 },
                new Subject { Id = 4, Name = "Ciencias Sociales", Status = 1 },
                new Subject { Id = 5, Name = "Inglés", Status = 1 },
                new Subject { Id = 6, Name = "Educación Artística", Status = 1 },
                new Subject { Id = 7, Name = "Educación Física", Status = 1 },
                new Subject { Id = 8, Name = "Tecnología e Informática", Status = 1 },
                new Subject { Id = 9, Name = "Ética y Valores", Status = 1 },
                new Subject { Id = 10, Name = "Religión", Status = 1 }
            );


        }
    }
}
