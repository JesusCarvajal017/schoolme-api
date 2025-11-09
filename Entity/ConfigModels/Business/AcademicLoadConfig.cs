using Entity.ConfigModels.global;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Business
{
    public class AcademicLoadConfig : IEntityTypeConfiguration<AcademicLoad>
    {
        public void Configure(EntityTypeBuilder<AcademicLoad> builder)
        {
            // Tabla y esquema
            builder.ToTable("academic_load", schema: "business");

            // PK (asumiendo que ABaseEntity define Id)
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                   .HasColumnName("id")
                   .IsRequired();

            // Columnas simples
            builder.Property(a => a.TeacherId)
                   .HasColumnName("teacher_id")
                   .IsRequired();

            builder.Property(a => a.SubjectId)
                   .HasColumnName("subject_id")
                   .IsRequired();

            builder.Property(a => a.GroupId)
                   .HasColumnName("group_id")
                   .IsRequired();

            builder.Property(a => a.Days)
                  .HasColumnName("days")
                  .HasConversion<int>()        
                  .HasDefaultValue(0)
                  .IsRequired();

            builder.MapBaseModel();


            // Evita duplicados exactos del mismo bloque
            builder.HasIndex(a => new { a.TeacherId, a.GroupId, a.SubjectId, a.Days })
                   .HasDatabaseName("uq_academic_load_slot")
                   .IsUnique();

            // Relaciones
            builder.HasOne(a => a.Teacher)
                   .WithMany(t => t.AcademicLoad)
                   .HasForeignKey(a => a.TeacherId)
                   .HasConstraintName("fk_academic_load_teacher")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Subject)
                   .WithMany(s => s.AcademicLoads) // crea ICollection<AcademicLoad> en Subject si no la tienes
                   .HasForeignKey(a => a.SubjectId)
                   .HasConstraintName("fk_academic_load_subject")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Group)
                   .WithMany(g => g.AcademicLoad) // crea ICollection<AcademicLoad> en Group si no la tienes
                   .HasForeignKey(a => a.GroupId)
                   .HasConstraintName("fk_academic_load_group")
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}