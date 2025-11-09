
using Entity.ConfigModels.global;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Business
{
    public class QuestionOptionConfig : IEntityTypeConfiguration<QuestionOption>
    {
        public void Configure(EntityTypeBuilder<QuestionOption> builder)
        {
            // Tabla y esquema
            builder.ToTable("question_option", schema: "business");

            // Clave primaria
            builder.HasKey(qo => qo.Id);

            // Columnas
            builder.Property(qo => qo.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(qo => qo.QuestionId)
                   .HasColumnName("question_id")
                   .IsRequired();

            builder.Property(qo => qo.Text)
                   .IsRequired()
                   .IsUnicode()
                   .HasMaxLength(200);

            builder.Property(qo => qo.Order)
                   .HasColumnName("order")
                   .IsRequired()
                   .HasDefaultValue(0);

            builder.MapBaseModel();

            // Relaciones
            builder.HasOne(qo => qo.Question)
                   .WithMany(q => q.QuestionOptions)
                   .HasForeignKey(qo => qo.QuestionId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Índices / restricciones
            builder.HasIndex(qo => new { qo.QuestionId, qo.Order })
                   .IsUnique(); // evita duplicar el orden dentro de la misma pregunta
        }
    }
}
