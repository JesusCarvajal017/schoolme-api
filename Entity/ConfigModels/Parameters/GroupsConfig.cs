using Entity.ConfigModels.global;
using Entity.Model.Business;
using Entity.Model.Paramters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Parameters
{
    public class GroupsConfig : IEntityTypeConfiguration<Groups>
    {
        public void Configure(EntityTypeBuilder<Groups> builder)
        {

            // Tabla y esquema
            builder.ToTable("group", schema: "business");

            // Clave primaria
            builder.HasKey(g => g.Id);

            // Columnas
            builder.Property(g => g.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(g => g.Name)
                   .HasColumnName("name")
                   .HasMaxLength(120)
                   .IsRequired();

            builder.Property(g => g.GradeId)
                   .HasColumnName("grade_id")
                   .IsRequired();

            builder.Property(g => g.AmountStudents)
                   .HasColumnName("amount_students")
                   .IsRequired();

            builder.Property(g => g.AgendaId)
                   .HasColumnName("agenda_id"); // nullable

     
            builder.MapBaseModel();


            // (Opcional pero recomendable) Evitar duplicados de nombre dentro del mismo grado
            builder.HasIndex(g => new { g.Name, g.GradeId })
                   .HasDatabaseName("uq_group_name_grade")
                   .IsUnique();

            // Muchos grupos -> un Grade
            builder.HasOne(g => g.Grade)
                   .WithMany(/* grade => grade.Groups */)  // agrega colección en Grade si quieres navegación inversa
                   .HasForeignKey(g => g.GradeId)
                   .HasConstraintName("fk_group_grade")
                   .OnDelete(DeleteBehavior.Restrict);

            // Muchos grupos -> una Agenda (agenda ACTIVA). FK opcional.
            builder.HasOne(g => g.Agenda)
                   .WithMany(a => a.Groups)               // agrega ICollection<Group> en Agenda si no la tienes
                   .HasForeignKey(g => g.AgendaId)
                   .HasConstraintName("fk_group_agenda")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData
            (
                new Groups {Id=1, Status = 1, Name = "Primero A", GradeId = 1, AmountStudents = 20 },
                new Groups {Id=3, Status = 1, Name = "Primero B", GradeId = 1 , AmountStudents = 20 },
                new Groups {Id=4, Status = 1, Name = "Primero C", GradeId = 1 , AmountStudents = 20 }

            );



        }
    }
}
