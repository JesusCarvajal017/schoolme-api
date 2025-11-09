using Entity.ConfigModels.global;
using Entity.Enum;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Security
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("person", schema: "security");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(p => p.FisrtName)
                .HasColumnName("fisrtName")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.SecondName)
               .HasColumnName("secondName")
               .HasMaxLength(100);

            builder.Property(p => p.LastName)
                .HasColumnName("lastName")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.SecondLastName)
             .HasColumnName("secondLastName")
             .HasMaxLength(100);

            builder.Property(p => p.Identification)
               .HasColumnName("identification")
               .IsRequired();

            // Índice único
            builder.HasIndex(p => p.Identification).IsUnique();

            builder.Property(p => p.Phone)
               .HasColumnName("phone")
               .IsRequired();

            builder.Property(p => p.Gender)
               .HasColumnName("gender")
               .IsRequired();

            builder.Property(p => p.Age)
              .HasColumnName("age")
              .IsRequired();

            builder.HasOne(ur => ur.DocumentType)
              .WithMany(r => r.Persons)
              .HasForeignKey(ur => ur.DocumentTypeId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.MapBaseModel();

            builder.HasData(
                new Person
                {
                    Id = 1,
                    DocumentTypeId = 1,
                    Identification = 100200300,
                    FisrtName = "Carlos",
                    SecondName = "Andrés",
                    LastName = "Pérez",
                    SecondLastName = "García",
                    //Nation = "Colombia",
                    Phone = 300123456,
                    Gender = GenderEmun.Masculino,
                    Age = 32
                },
                new Person
                {
                    Id = 2,
                    DocumentTypeId = 2,
                    Identification = 500600700,
                    FisrtName = "María",
                    SecondName = "Fernanda",
                    LastName = "López",
                    SecondLastName = "Martínez",
                    //Nation = "Colombia",
                    Phone = 310987654,
                    Gender = GenderEmun.Femenino,
                    Age = 25
                },
                new Person
                {
                    Id = 3,
                    DocumentTypeId = 3,
                    Identification = 800900100,
                    FisrtName = "Juan",
                    SecondName = "Camilo",
                    LastName = "Rodríguez",
                    SecondLastName = "Hernández",
                    //Nation = "Colombia",
                    Phone = 320456789,
                    Gender = GenderEmun.Masculino,
                    Age = 18
                },
                new Person
                {
                    Id = 4,
                    DocumentTypeId = 1,
                    Identification = 111222333,
                    FisrtName = "Laura",
                    SecondName = "Isabel",
                    LastName = "Moreno",
                    SecondLastName = "Castro",
                    //Nation = "Colombia",
                    Phone = 301654987,
                    Gender = GenderEmun.Femenino,
                    Age = 29
                },
                new Person
                {
                    Id = 5,
                    DocumentTypeId = 2,
                    Identification = 444555666,
                    FisrtName = "Santiago",
                    SecondName = "Esteban",
                    LastName = "Ramírez",
                    SecondLastName = "Torres",
                    //Nation = "Colombia",
                    Phone = 312789654,
                    Gender = GenderEmun.NoBinario,
                    Age = 21
                }
            );
        }
    }
}
