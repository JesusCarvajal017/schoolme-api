using Entity.ConfigModels.global;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Entity.ConfigModels.Security
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users", schema: "security");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(p => p.Photo)
                .HasColumnName("photo")
                .IsRequired()
                .IsUnicode(false);

            builder.Property(p => p.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Password)
               .HasColumnName("password")
               .IsRequired();

            builder.Property(p => p.TwoStep)
             .HasColumnName("twostep")
             .HasDefaultValue(false);

            builder.Property(p => p.PersonId)
                 .HasColumnName("person_id")
                 .IsUnicode()
                 .IsRequired();

            builder.MapBaseModel();

            builder.HasIndex(p => p.PersonId)
                    .IsUnique();

            builder.HasIndex(p => p.Email)
               .HasDatabaseName("ux_users_email")
               .IsUnique();


            builder.HasOne(p => p.Person)
               .WithOne() 
               .HasForeignKey<User>(p => p.PersonId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new User
                {
                    Id = 1,
                    Photo = "./icons/default.png",
                    Email = "ejemplo1@gmail.com",
                    Password = "$2a$11$6LpgqG3XuJ3xbpRp4gcJXeL/pQT79cDv6Vt063Tk5c2klWRpNgR0.",
                    PersonId = 1
                },
                new User
                {
                    Id = 2,
                    Photo = "./icons/default.png",
                    Email = "ejemplo2@gmail.com",
                    Password = "$2a$11$6LpgqG3XuJ3xbpRp4gcJXeL/pQT79cDv6Vt063Tk5c2klWRpNgR0.",
                    PersonId = 2
                },
                new User
                {
                    Id = 3,
                    Photo = "./icons/default.png",
                    Email = "ejemplo3@gmail.com",
                    Password = "$2a$11$6LpgqG3XuJ3xbpRp4gcJXeL/pQT79cDv6Vt063Tk5c2klWRpNgR0.",
                    PersonId = 3
                },
                new User
                {
                    Id = 4,
                    Photo = "./icons/default.png",
                    Email = "ejemplo4@gmail.com",
                    Password = "$2a$11$6LpgqG3XuJ3xbpRp4gcJXeL/pQT79cDv6Vt063Tk5c2klWRpNgR0.",
                    PersonId = 4
                },
                new User
                {
                    Id = 5,
                    Photo = "./icons/default.png",
                    Email = "ejemplo5@gmail.com",
                    Password = "$2a$11$6LpgqG3XuJ3xbpRp4gcJXeL/pQT79cDv6Vt063Tk5c2klWRpNgR0.",
                    PersonId = 5
                }
            );



        }
    }
    
}
