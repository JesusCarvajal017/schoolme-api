using Entity.ConfigModels.global;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Business
{
    public class QuestionConfig : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            // Tabla y esquema
            builder.ToTable("question", schema: "business");

            // Clave primaria
            builder.HasKey(q => q.Id);

            // Columnas
            builder.Property(q => q.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(q => q.Text)
                   .IsRequired()
                   .IsUnicode()
                   .HasMaxLength(300);

            builder.Property(q => q.TypeAnswerId)
                   .HasColumnName("type_answer_id")
                   .IsRequired();

            // Campos base (Id, Status, auditoría si aplica)
            builder.MapBaseModel();

            // Índices
            builder.HasIndex(q => q.TypeAnswerId);

            // Relaciones
            // Muchos (Question) -> Uno (TypeAnsware)
            builder.HasOne(q => q.TypeAswer)                 // nav en Question
                   .WithMany(t => t.Questions)               // colección en TypeAnsware
                   .HasForeignKey(q => q.TypeAnswerId)       // FK en Question
                   .OnDelete(DeleteBehavior.Restrict);

            // 1 (Question) -> N (QuestionOption)
            builder.HasMany(q => q.QuestionOptions)
                   .WithOne(qo => qo.Question)
                   .HasForeignKey(qo => qo.QuestionId)
                   .OnDelete(DeleteBehavior.Cascade);

            // 1 (Question) -> N (CompositionAgendaQuestion)
            builder.HasMany(q => q.CompositionAgendaQuestion)
                   .WithOne(caq => caq.Question)
                   .HasForeignKey(caq => caq.QuestionId)
                   .OnDelete(DeleteBehavior.Cascade);

            // 1 (Question) -> N (StudentAnswer)
            builder.HasMany(q => q.StudentAnswers)
                   .WithOne(sa => sa.Question)
                   .HasForeignKey(sa => sa.QuestionId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
