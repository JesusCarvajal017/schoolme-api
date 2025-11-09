using Entity.ConfigModels.global;
using Entity.Model.Paramters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Parameters
{
    public class RhConfig : IEntityTypeConfiguration<Rh>
    {
        public void Configure(EntityTypeBuilder<Rh> builder)
        {
            builder.ToTable("rh", schema: "parameters");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();
            builder.Property(p => p.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.MapBaseModel();

            builder.HasData
            (
                new Rh
                {
                    Id = 1,
                    Name = "O+"
                },
                new Rh
                {
                    Id = 2,
                    Name = "O-"
                },
                new Rh
                {
                    Id = 3,
                    Name = "A+"
                }
            );

            
        }
    }
}
