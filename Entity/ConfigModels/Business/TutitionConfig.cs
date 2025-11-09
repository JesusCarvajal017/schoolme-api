using Entity.ConfigModels.global;
using Entity.Enum;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entity.ConfigModels.Business
{
    public class TutitionConfig : IEntityTypeConfiguration<Tutition>
    {
        public void Configure(EntityTypeBuilder<Tutition> builder)
        {
            // Tabla y esquema
            builder.ToTable("tutition", schema: "business");

            // PK (asumiendo que ABaseEntity define Id)
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                   .HasColumnName("id")
                   .IsRequired();

            // Columnas simples
            builder.Property(a => a.StudentId)
                   .HasColumnName("student_id")
                   .IsRequired();

            builder.Property(a => a.GradeId)
                   .HasColumnName("grade_id")
                   .IsRequired();


            builder.MapBaseModel();


            // Relaciones
            builder.HasOne(a => a.Student)
                   .WithMany(t => t.Tutition)
                   .HasForeignKey(a => a.StudentId)
                   .HasConstraintName("fk_academic_load_student")
                   .OnDelete(DeleteBehavior.Restrict);

            // Relaciones
            builder.HasOne(a => a.Grade)
                   .WithMany(t => t.Tutition)
                   .HasForeignKey(a => a.GradeId)
                   .HasConstraintName("fk_academic_load_grade")
                   .OnDelete(DeleteBehavior.Restrict);


        }
    }
}