
using Entity.ConfigModels.global;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Business
{
    public class CompositionConfig : IEntityTypeConfiguration<CompositionAgendaQuestion>
    {
        public void Configure(EntityTypeBuilder<CompositionAgendaQuestion> builder)
        {
            // Tabla y esquema
            builder.ToTable("composition_agenda_question", schema: "business");

            // PK (de ABaseEntity)
            builder.HasKey(x => x.Id);

            // Columnas
            builder.Property(x => x.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(x => x.AgendaId)
                   .HasColumnName("agenda_id")
                   .IsRequired();

            builder.Property(x => x.QuestionId)
                   .HasColumnName("question_id")
                   .IsRequired();

            // Auditoría / estado del ABaseEntity (created_at, updated_at, status, etc.)
            builder.MapBaseModel();

            // Único: una misma pregunta no debe repetirse dentro de la misma agenda
            builder.HasIndex(x => new { x.AgendaId, x.QuestionId })
                   .HasDatabaseName("uq_comp_agenda_question")
                   .IsUnique();

            // Índices de apoyo
            //builder.HasIndex(x => x.AgendaId)
            //       .HasDatabaseName("ix_caq_agenda");
            //builder.HasIndex(x => x.QuestionId)
            //       .HasDatabaseName("ix_caq_question");

            // Relaciones
            builder.HasOne(x => x.Agenda)
                   // ajusta la colección en Agenda si la tienes, p. ej. .WithMany(a => a.CompositionQuestions)
                   .WithMany(x=> x.CompositionAgendaQuestion)
                   .HasForeignKey(x => x.AgendaId)
                   .HasConstraintName("fk_caq_agenda")
                   .OnDelete(DeleteBehavior.Cascade); // al borrar Agenda, se borran sus filas de composición

            builder.HasOne(x => x.Question)
                   // ajusta la colección en Question si la tienes
                   .WithMany(x => x.CompositionAgendaQuestion)
                   .HasForeignKey(x => x.QuestionId)
                   .HasConstraintName("fk_caq_question")
                   .OnDelete(DeleteBehavior.Restrict); // protege catálogo de preguntas
        }


        
    }
}
