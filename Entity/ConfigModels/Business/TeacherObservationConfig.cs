using Entity.ConfigModels.global;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Business
{
    public class TeacherObservationConfig : IEntityTypeConfiguration<TeacherObservation>
    {
        public void Configure(EntityTypeBuilder<TeacherObservation> builder)
        {
            // Tabla y esquema
            builder.ToTable("teacher_observation", schema: "business");

            // PK (de ABaseEntity)
            builder.HasKey(e => e.Id);

            // Columnas
            builder.Property(e => e.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(e => e.TeacherId)
                   .HasColumnName("teacher_id")
                   .IsRequired();

            builder.Property(e => e.AgendaDayStudentId)
                   .HasColumnName("agenda_day_student_id")
                   .IsRequired();

            builder.Property(e => e.Text)
                   .HasColumnName("text")
                   .HasMaxLength(1000)       // ajusta si quieres más
                   .IsRequired();

            // Auditoría / estado comunes (created_at, updated_at, status, etc.)
            builder.MapBaseModel();

            // Índices
            //builder.HasIndex(e => e.AgendaDayStudentId)
            //       .HasDatabaseName("ix_to_agenda_day_student");

            //builder.HasIndex(e => new { e.AgendaDayStudentId, e.TeacherId, e.CreatedAt })
            //       .HasDatabaseName("ix_to_ads_teacher_created");

            // Relaciones
            builder.HasOne(e => e.AgendaDayStudent)
                   .WithMany(s => s.TeacherObservation)
                   .HasForeignKey(e => e.AgendaDayStudentId)
                   .HasConstraintName("fk_to_agenda_day_student")
                   .OnDelete(DeleteBehavior.Cascade); // si se borra la hoja del día, se van las observaciones

            builder.HasOne(e => e.Teacher)
                   .WithMany(t => t.TeacherObservation)
                   .HasForeignKey(e => e.TeacherId)
                   .HasConstraintName("fk_to_teacher")
                   .OnDelete(DeleteBehavior.Restrict); // protege al docente (borrado lógico recomendado)

        }
    }
}
