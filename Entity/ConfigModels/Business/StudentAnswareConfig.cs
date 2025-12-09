
using Entity.ConfigModels.global;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Business
{
    public class StudentAnswareConfig : IEntityTypeConfiguration<StudentAnswer>
    {
        public void Configure(EntityTypeBuilder<StudentAnswer> builder)
        {
            // Tabla y esquema
            builder.ToTable("student_answer", schema: "business");

            // Clave primaria (heredada de ABaseEntity)
            builder.HasKey(e => e.Id);

            // Columnas
            builder.Property(e => e.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(e => e.AgendaDayStudentId)
                   .HasColumnName("agenda_day_student_id")
                   .IsRequired();

            builder.Property(e => e.QuestionId)
                   .HasColumnName("question_id")
                   .IsRequired();

            builder.Property(e => e.ValueText)
                   .HasColumnName("value_text")
                   .HasMaxLength(1000);

            builder.Property(e => e.ValueBool)
                   .HasColumnName("value_bool");

            builder.Property(e => e.ValueNumber)
                   .HasColumnName("value_number")
                   .HasColumnType("decimal(10,2)");

            // Guardamos solo fecha (si en SQL es DATE)
            builder.Property(e => e.ValueDate)
                   .HasColumnName("value_date")
                   .HasColumnType("date");

            // Auditoría / estado del ABaseEntity (created_at, updated_at, status, etc.)
            builder.MapBaseModel();

            // Índice único: una respuesta por (alumno_día + pregunta)
            builder.HasIndex(e => new { e.AgendaDayStudentId, e.QuestionId })
                   .HasDatabaseName("uq_student_answer_ads_question")
                   .IsUnique();

            // Relaciones
            builder.HasOne(e => e.AgendaDayStudent)
                   .WithMany(s => s.StudentAnswers)
                   .HasForeignKey(e => e.AgendaDayStudentId)
                   .HasConstraintName("fk_student_answer_ads")
                   .OnDelete(DeleteBehavior.Cascade); // Si se elimina el padre los registro hijo deparecen de igual forma

            builder.HasOne(e => e.Question)
                   .WithMany(e=> e.StudentAnswers) // o .WithMany(q => q.StudentAnswers) si tienes navegación
                   .HasForeignKey(e => e.QuestionId)
                   .HasConstraintName("fk_student_answer_question")
                   .OnDelete(DeleteBehavior.Restrict);

            // 1:N con opciones seleccionadas (única o múltiple)
            builder.HasMany(e => e.SelectedOptions)
                   .WithOne(o => o.StudentAnswer)
                   .HasForeignKey(o => o.StudentAnswerId)
                   .HasConstraintName("fk_sao_answer")
                   .OnDelete(DeleteBehavior.Restrict);
        }
  
    }
}
