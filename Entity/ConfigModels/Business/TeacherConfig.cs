using Entity.ConfigModels.global;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Business
{
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            // Tabla y esquema
            builder.ToTable("teacher", schema: "business");

            // PK (asumiendo que ABaseEntity trae Id)
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .HasColumnName("id")
                   .IsRequired();

            // Columnas
            builder.Property(t => t.PersonId)
                   .HasColumnName("person_id")
                   .IsRequired();

            // Auditoría / estado del ABaseEntity (created_at, updated_at, status, etc.)
            builder.MapBaseModel();

            // Índices
            // Un maestro por persona (recomendado): evita duplicar el mismo Person como Teacher
            builder.HasIndex(t => t.PersonId)
                   .HasDatabaseName("uq_teacher_person")
                   .IsUnique();

            // Relaciones

            // Teacher (N) -> (1) Person  (1:1 lógico por el índice único)
            builder.HasOne(t => t.Person)
                   .WithMany() // o .WithMany(p => p.Teachers) si tienes la colección
                   .HasForeignKey(t => t.PersonId)
                   .HasConstraintName("fk_teacher_person")
                   .OnDelete(DeleteBehavior.Restrict);

            // Teacher (1) -> (N) GroupDirector
            builder.HasMany(t => t.GroupDirector)
                   .WithOne(gd => gd.Teacher)          // requiere propiedad .Teacher en GroupDirector
                   .HasForeignKey(gd => gd.TeacherId)  // requiere columna teacher_id en GroupDirector
                   .HasConstraintName("fk_group_director_teacher")
                   .OnDelete(DeleteBehavior.Restrict);

            // Teacher (1) -> (N) AcademicLoad
            builder.HasMany(t => t.AcademicLoad)
                   .WithOne(al => al.Teacher)          // requiere propiedad .Teacher en AcademicLoad
                   .HasForeignKey(al => al.TeacherId)  // requiere columna teacher_id en AcademicLoad
                   .HasConstraintName("fk_academic_load_teacher")
                   .OnDelete(DeleteBehavior.Restrict);

            // Teacher (1) -> (N) TeacherObservation
            builder.HasMany(t => t.TeacherObservation)
                   .WithOne(to => to.Teacher)          // agrega la navegación en TeacherObservation si aún no la tienes
                   .HasForeignKey(to => to.TeacherId)  // requiere columna teacher_id en TeacherObservation
                   .HasConstraintName("fk_teacher_observation_teacher")
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasData
            (
                new Teacher {Id=1, Status = 1, PersonId = 2 }
            );

        }
    }
}
