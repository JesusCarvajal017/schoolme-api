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

            builder.HasOne(p => p.User)
               .WithOne(p => p.Person)
               .HasForeignKey<User>(p => p.PersonId)
               .OnDelete(DeleteBehavior.Cascade);



            builder.MapBaseModel();

            builder.HasData(
                new Person
                {
                    Id = 1,
                    DocumentTypeId = 1,
                    Identification = 100000001,
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
                    Identification = 10000002,
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
                    Identification = 10000003,
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
                    Identification = 10000004,
                    FisrtName = "Laura",
                    SecondName = "Isabel",
                    LastName = "Moreno",
                    SecondLastName = "Castro",
                    //Nation = "Colombia",
                    Phone = 301654987,
                    Gender = GenderEmun.Femenino,
                    Age = 29,
                    Status = 3
                },
                new Person
                {
                    Id = 5,
                    DocumentTypeId = 2,
                    Identification = 10000005,
                    FisrtName = "Santiago",
                    SecondName = "Esteban",
                    LastName = "Ramírez",
                    SecondLastName = "Torres",
                    //Nation = "Colombia",
                    Phone = 312789654,
                    Gender = GenderEmun.NoBinario,
                    Age = 21
                },

                new Person
                {
                    Id = 6,
                    DocumentTypeId = 1,
                    Identification = 10000006,
                    FisrtName = "Sebastian",
                    SecondName = "Jose",
                    LastName = "Perdomo",
                    SecondLastName = "Castro",
                    //Nation = "Colombia",
                    Phone = 3000000001,
                    Gender = GenderEmun.Masculino,
                    Age = 29
                },
                new Person
                {
                    Id = 7,
                    DocumentTypeId = 1,
                    Identification = 10000007,
                    FisrtName = "Ashley",
                    SecondName = "Sofia",
                    LastName = "Buitrago",
                    SecondLastName = "Uran",
                    //Nation = "Colombia",
                    Phone = 3000000002,
                    Gender = GenderEmun.Femenino,
                    Age = 29
                }, new Person
                {
                    Id = 8,
                    DocumentTypeId = 1,
                    Identification = 10000008,
                    FisrtName = "Karol",
                    LastName = "Pastrana",
                    SecondLastName = "Borrero",
                    //Nation = "Colombia",
                    Phone = 3000000003,
                    Gender = GenderEmun.Femenino,
                    Age = 29,
                 
                }, new Person
                {
                    Id = 9,
                    DocumentTypeId = 1,
                    Identification = 10000009,
                    FisrtName = "Lauriano",
                    SecondName = "Jose",
                    LastName = "Robledo",
                    SecondLastName = "Narvaez",
                    //Nation = "Colombia",
                    Phone = 3000000004,
                    Gender = GenderEmun.Femenino,
                    Age = 29
                }, new Person
                {
                    Id = 10,
                    DocumentTypeId = 1,
                    Identification = 10000010,
                    FisrtName = "Misael",
                    LastName = "Borbon",
                    SecondLastName = "Murcia",
                    //Nation = "Colombia",
                    Phone = 3000000005,
                    Gender = GenderEmun.Masculino,
                    Age = 29
                }, new Person
                {
                    Id = 11, 
                    DocumentTypeId = 1,
                    Identification = 10000011,
                    FisrtName = "Wilson",
                    LastName = "Guevara",
                    SecondLastName = "Perez",
                    //Nation = "Colombia",
                    Phone = 3000000006,
                    Gender = GenderEmun.Masculino,
                    Age = 29
                }
            );
        }
    }
}
