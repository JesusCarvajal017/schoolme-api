using Entity.ConfigModels.global;
using Entity.Model.Paramters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Parameters
{
    public class TypeAnswareConfig : IEntityTypeConfiguration<TypeAnsware>
    {
        public void Configure(EntityTypeBuilder<TypeAnsware> builder)
        {

            builder.ToTable("type_answare", schema: "parameters");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(t => t.Name)
                   .HasColumnName("name")
                   .IsRequired()
                   .HasMaxLength(80);

            builder.Property(t => t.Description)
                   .HasColumnName("description")
                   .HasMaxLength(250);

            builder.MapBaseModel();

            builder.HasData(
                new TypeAnsware { Id = 1, Name = "Text", Description = "Respuesta de texto libre", Status = 1 },
                new TypeAnsware { Id = 2, Name = "Bool", Description = "Sí / No", Status = 1 },
                new TypeAnsware { Id = 3, Name = "Number", Description = "Numérica", Status = 1 },
                new TypeAnsware { Id = 4, Name = "Date", Description = "Fecha", Status = 1 },
                new TypeAnsware { Id = 5, Name = "OptionSingle", Description = "Selección de opción única", Status = 1 }
            );

        }
    }
}
