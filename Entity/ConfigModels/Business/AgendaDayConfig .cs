
using Entity.ConfigModels.global;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entity.ConfigModels.Business
{
    public class AgendaDayConfig : IEntityTypeConfiguration<AgendaDay>
    {
        public void Configure(EntityTypeBuilder<AgendaDay> builder)
        {
            // Tabla y esquema
            builder.ToTable("agenda_day", schema: "business");

            // PK (de ABaseEntity)
            builder.HasKey(e => e.Id);

            // Columnas
            builder.Property(e => e.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(e => e.GroupId)
                   .HasColumnName("group_id")
                   .IsRequired();

            builder.Property(e => e.AgendaId)
                   .HasColumnName("agenda_id")
                   .IsRequired();

            // DateOnly -> DATE (portable) CONVIERTE EL DATAONLY  A DATE EN LA DB
            var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
                v => v.ToDateTime(TimeOnly.MinValue),     // C# -> SQL
                v => DateOnly.FromDateTime(v)             // SQL -> C#
            );

            builder.Property(e => e.Date)
                   .HasColumnName("date")
                   .HasConversion(dateOnlyConverter)
                   .HasColumnType("date")
                   .IsRequired();

            builder.Property(e => e.OpenedAt)
                   .HasColumnName("opened_at");

            builder.Property(e => e.ClosedAt)
                   .HasColumnName("closed_at");

            // Auditoría / estado comunes (ABaseEntity)
            builder.MapBaseModel();

            // Índice único: 1 planilla por (grupo, agenda, fecha)
            builder.HasIndex(e => new { e.GroupId, e.AgendaId, e.Date })
                   .HasDatabaseName("uq_agenda_day_group_agenda_date")
                   .IsUnique();

            // Índices de apoyo para consultas típicas
            builder.HasIndex(e => new { e.GroupId, e.Date })
                   .HasDatabaseName("ix_agenda_day_group_date");

            // Relaciones
            builder.HasOne(e => e.Group)
                   .WithMany(g => g.AgendaDay)                // asegúrate de tener ICollection<AgendaDay> AgendaDays en Groups
                   .HasForeignKey(e => e.GroupId)
                   .HasConstraintName("fk_agenda_day_group")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Agenda)
                   .WithMany(a => a.AgendaDays)
                   .HasForeignKey(e => e.AgendaId)
                   .HasConstraintName("fk_agenda_day_agenda")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.AgendaDayStudents)
                   .WithOne(s => s.AgendaDay)
                   .HasForeignKey(s => s.AgendaDayId)
                   .HasConstraintName("fk_ads_agenda_day")
                   .OnDelete(DeleteBehavior.Cascade);
        }


        
    }
}
