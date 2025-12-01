using Entity.ConfigModels.global;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Business
{
    public class AgendaDayStudentConfig : IEntityTypeConfiguration<AgendaDayStudent>
    {
        public void Configure(EntityTypeBuilder<AgendaDayStudent> builder)
        {
            // Tabla y esquema
            builder.ToTable("agenda_day_student", schema: "business");

            // PK (de ABaseEntity)
            builder.HasKey(e => e.Id);

            // Columnas
            builder.Property(e => e.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(e => e.AgendaDayId)
                   .HasColumnName("agenda_day_id")
                   .IsRequired();

            // Ojo: tu propiedad se llama StudentsId (plural). Se mapea a student_id.
            builder.Property(e => e.StudentId)
                   .HasColumnName("student_id")
                   .IsRequired();

            builder.Property(e => e.AgendaDayStudentStatus)
                   .HasColumnName("agenda_day_student_status") // evita colisión con Status de ABaseEntity
                   .IsRequired();

            builder.Property(e => e.CompletedAt)
                   .HasColumnName("completed_at"); // es no-null en tu clase; si quieres permitir null, cambia la propiedad a DateTime?

            // Auditoría / estado comunes
            builder.MapBaseModel();

            // Índice único: 1 hoja por (día, estudiante)
            builder.HasIndex(e => new { e.AgendaDayId, e.StudentId })
                   .HasDatabaseName("uq_ads_agenda_day_student")
                   .IsUnique();

           
            // Relaciones
            builder.HasOne(e => e.AgendaDay)
                   .WithMany(d => d.AgendaDayStudents)
                   .HasForeignKey(e => e.AgendaDayId)
                   .HasConstraintName("fk_ads_agenda_day")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Student)
               .WithMany(s => s.AgendaDayStudents)
               .HasForeignKey(e => e.StudentId)
               .HasConstraintName("fk_ads_students")
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.StudentAnswers)
                   .WithOne(a => a.AgendaDayStudent)
                   .HasForeignKey(a => a.AgendaDayStudentId)
                   .HasConstraintName("fk_student_answer_ads")
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
