
using Entity.ConfigModels.global;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Business
{
    public class StudentAnswareOptionsConfig : IEntityTypeConfiguration<StudentAnswerOption>
    {
        public void Configure(EntityTypeBuilder<StudentAnswerOption> builder)
        {
            // Tabla y esquema
            builder.ToTable("student_answer_option", schema: "business");

            // PK (de ABaseEntity)
            builder.HasKey(e => e.Id);

            // Columnas
            builder.Property(e => e.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(e => e.StudentAnswerId)
                   .HasColumnName("student_answer_id")
                   .IsRequired();

            builder.Property(e => e.QuestionOptionId)
                   .HasColumnName("question_option_id")
                   .IsRequired();

            // Auditoría / estado comunes
            builder.MapBaseModel();

            // Único: no repetir la misma opción para la misma respuesta
            builder.HasIndex(e => new { e.StudentAnswerId, e.QuestionOptionId })
                   .HasDatabaseName("uq_sao_answer_option")
                   .IsUnique();

            // Índices de apoyo
            //builder.HasIndex(e => e.StudentAnswerId)
            //       .HasDatabaseName("ix_sao_answer");
            //builder.HasIndex(e => e.QuestionOptionId)
            //       .HasDatabaseName("ix_sao_question_option");

            // Relaciones
            builder.HasOne(e => e.StudentAnswer)
                   .WithMany(a => a.SelectedOptions)
                   .HasForeignKey(e => e.StudentAnswerId)
                   .HasConstraintName("fk_sao_student_answer")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.QuestionOption)
                   .WithMany(e=> e.StudentAnswerOptions) // o .WithMany(qo => qo.StudentAnswerOptions) si tienes la colección en QuestionOption
                   .HasForeignKey(e => e.QuestionOptionId)
                   .HasConstraintName("fk_sao_question_option")
                   .OnDelete(DeleteBehavior.Restrict);
        }
  
    }
}
