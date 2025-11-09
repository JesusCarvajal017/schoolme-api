using Entity.ConfigModels.global;
using Entity.Model.Paramters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Parameters
{
    public class EpsConfig : IEntityTypeConfiguration<Eps>
    {
        public void Configure(EntityTypeBuilder<Eps> builder)
        {
            builder.ToTable("eps", schema: "parameters");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();
            builder.Property(p => p.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.MapBaseModel();

            builder.HasData(
               new Eps
               {
                   Id = 1,
                   Name = "Nueva eps",
                   Status = 1
               },
                new Eps
                {
                    Id = 2,
                    Name = "Sanitas",
                    Status = 1
                },
                new Eps
                {
                    Id = 3,
                    Name = "Coperacion indigena",
                    Status = 1
                },
                new Eps
                {
                    Id = 4,
                    Name = "Estocolmo",
                    Status = 1
                }
            );

        }
    }
}
