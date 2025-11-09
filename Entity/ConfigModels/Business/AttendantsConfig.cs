using Entity.ConfigModels.global;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Business
{
    public class AttendantsConfig : IEntityTypeConfiguration<Attendants>
    {
        public void Configure(EntityTypeBuilder<Attendants> builder)
        {
            // Tabla y esquema
            builder.ToTable("attendants", schema: "business");

            // PK (de ABaseEntity)
            builder.HasKey(a => a.Id);

            // Columnas
            builder.Property(a => a.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(a => a.PersonId)
                   .HasColumnName("person_id")
                   .IsRequired();

            builder.Property(a => a.StudentId)
               .HasColumnName("student_id")
               .IsRequired();

            builder.Property(a => a.RelationShipTypeEnum)
                .HasColumnName("relationship_type")
                .IsRequired();

            // ÚNICO: un mismo Person no debe repetirse como acudiente del mismo Student
            builder.HasIndex(a => new { a.StudentId, a.PersonId })
                   .HasDatabaseName("uq_attendants_student_person")
                   .IsUnique();

            // Relaciones
            builder.HasOne(a => a.Student)
                   .WithMany(s => s.Attendants)         // agrega ICollection<Attendants> en Student si la quieres
                   .HasForeignKey(a => a.StudentId)
                   .HasConstraintName("fk_attendants_student")
                   .OnDelete(DeleteBehavior.Restrict);

            // Auditoría / estado comunes
            builder.MapBaseModel();

            builder.HasOne(a => a.Person)
                   .WithMany(p => p.Attendants)         // agrega ICollection<Attendants> en Person si la quieres
                   .HasForeignKey(a => a.PersonId)
                   .HasConstraintName("fk_attendants_person")
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
