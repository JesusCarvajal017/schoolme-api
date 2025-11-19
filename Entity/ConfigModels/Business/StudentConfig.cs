
using Entity.ConfigModels.global;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Business
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // Tabla y esquema
            builder.ToTable("student", schema: "business");

            // Clave primaria
            builder.HasKey(s => s.Id);

            // Columnas
            builder.Property(s => s.Id)
                   .HasColumnName("id")
                   .IsRequired();

            //builder.Property(s => s.TutionId)
            //       .HasColumnName("tution_id")   // si es "tuition", renombra la columna/FK
            //       .IsRequired();

            builder.Property(s => s.PersonId)
                   .HasColumnName("person_id")
                   .IsRequired();


            builder.Property(s => s.GroupId)
                   .HasColumnName("group_id")
                   .IsRequired(false);

            // Id / Status (y auditoría) del ABaseEntity
            builder.MapBaseModel();

            // Relaciones: muchos(Student) -> uno(Person)
            builder.HasOne(s => s.Person)
                   .WithMany() // usa .WithMany(p => p.Students) si existe la colección en Person
                   .HasForeignKey(s => s.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Relaciones: muchos(Student) -> uno(Group)
            builder.HasOne(s => s.Groups)
                   .WithMany() // usa .WithMany(g => g.Student) o g.Students si existe la colección
                   .HasForeignKey(s => s.GroupId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData
            (
               new Student { Id= 1,Status = 1, PersonId= 3 }
            );
        }
    }
}
