using Entity.Model.Auditoria;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Logs
{
    public class LogConfig : IEntityTypeConfiguration<Auditoria>
    {
        public void Configure(EntityTypeBuilder<Auditoria> builder)
        {
            builder.ToTable("auditoria", schema: "main");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Timestamp)
                .HasColumnName("time_stamp")
                .IsRequired();
            builder.Property(p => p.OperationType)
                .HasColumnName("operation_type")
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.CommandText)
                .HasColumnName("commands_text")
                .IsRequired();
            builder.Property(p => p.ParametersJson)
              .HasColumnName("parameters_json")
              .IsRequired();
            builder.Property(p => p.AffectedEntities)
               .HasColumnName("afected_entities")
               .IsRequired();
            builder.Property(p => p.DurationMs)
              .HasColumnName("duration_ms")
              .IsRequired();
        }
    }
}
