
using Entity.ConfigModels.global;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Business
{
    public class AgendaConfig : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            // Tabla y esquema
            builder.ToTable("agenda", schema: "business");

            // PK (de ABaseEntity)
            builder.HasKey(a => a.Id);

            // Columnas
            builder.Property(a => a.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(a => a.Name)
                   .HasColumnName("name")
                   .HasMaxLength(120)
                   .IsRequired();

            builder.Property(a => a.Description)
                   .HasColumnName("description")
                   .HasMaxLength(500);

      
            // Auditoría / estado comunes
            builder.MapBaseModel();

            // Único por nombre (ajusta si manejas versiones)
            builder.HasIndex(a => a.Name)
                   .HasDatabaseName("uq_agenda_name")
                   .IsUnique();

            // Relaciones

            // 1:N Agenda -> CompositionAgenda (detalle de plantilla)
            builder.HasMany(a => a.CompositionAgendaQuestion)
                   .WithOne(c => c.Agenda)
                   .HasForeignKey(c => c.AgendaId)
                   .HasConstraintName("fk_composition_agenda_agenda")
                   .OnDelete(DeleteBehavior.Cascade);

            // 1:N Agenda -> AgendaDay (histórico de días que usaron esta agenda)
            builder.HasMany(a => a.AgendaDays)
                   .WithOne(d => d.Agenda)
                   .HasForeignKey(d => d.AgendaId)
                   .HasConstraintName("fk_agenda_day_agenda")
                   .OnDelete(DeleteBehavior.Restrict);

            // 1:N Agenda -> Groups (agenda activa en grupos)
            builder.HasMany(a => a.Groups)
                   .WithOne(g => g.Agenda)
                   .HasForeignKey(g => g.AgendaId)
                   .HasConstraintName("fk_group_agenda")
                   .OnDelete(DeleteBehavior.Restrict);
        }


        
    }
}
