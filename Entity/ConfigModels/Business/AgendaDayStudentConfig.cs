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
            builder.Property(e => e.StudentsId)
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
            builder.HasIndex(e => new { e.AgendaDayId, e.StudentsId })
                   .HasDatabaseName("uq_ads_agenda_day_student")
                   .IsUnique();

            // Índices de apoyo
            //builder.HasIndex(e => e.StudentsId)
            //       .HasDatabaseName("ix_ads_student");
            //builder.HasIndex(e => e.AgendaDayId)
            //       .HasDatabaseName("ix_ads_agenda_day");

            // (Opcional) CHECK de estado (0=Pending, 1=Completed)
            // Nota: MySQL < 8.0.16 ignora CHECKs
            // builder.HasCheckConstraint("ck_ads_status", "[agenda_day_student_status] IN (0,1)");

            // Relaciones
            builder.HasOne(e => e.AgendaDay)
                   .WithMany(d => d.AgendaDayStudents)
                   .HasForeignKey(e => e.AgendaDayId)
                   .HasConstraintName("fk_ads_agenda_day")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Students)
                   .WithMany() // o .WithMany(s => s.AgendaDayStudents) si tienes la colección en Student
                   .HasForeignKey(e => e.StudentsId)
                   .HasConstraintName("fk_ads_student")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.StudentAnswers)
                   .WithOne(a => a.AgendaDayStudent)
                   .HasForeignKey(a => a.AgendaDayStudentId)
                   .HasConstraintName("fk_student_answer_ads")
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
