using Entity.ConfigModels.global;
using Entity.Model.Paramters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Parameters
{
    public class MaterialStatusConfig : IEntityTypeConfiguration<MaterialStatus>
    {
        public void Configure(EntityTypeBuilder<MaterialStatus> builder)
        {
            builder.ToTable("materialStatus", schema: "parameters");

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
               new MaterialStatus
               {
                   Id = 1,
                   Name = "Casado"
               },
                new MaterialStatus
                {
                    Id= 2,
                    Name = "Soltero"
                }
            );


        }
    }
}
