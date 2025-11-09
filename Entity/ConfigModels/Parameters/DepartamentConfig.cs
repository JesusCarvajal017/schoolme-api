using Entity.ConfigModels.global;
using Entity.Model.Paramters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Parameters
{
    public class DepartamentConfig : IEntityTypeConfiguration<Departament>
    {
        public void Configure(EntityTypeBuilder<Departament> builder)
        {
            builder.ToTable("departamet", schema: "parameters");

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
                new Departament { Id = 1, Name = "Amazonas", Status = 1 },
                new Departament { Id = 2, Name = "Antioquia",Status = 1 },
                new Departament { Id = 3, Name = "Arauca", Status = 1 },
                new Departament { Id = 4, Name = "Atlántico", Status = 1 },
                new Departament { Id = 5, Name = "Bolívar", Status = 1 },
                new Departament { Id = 6, Name = "Boyacá", Status = 1 },
                new Departament { Id = 7, Name = "Caldas", Status = 1 },
                new Departament { Id = 8, Name = "Caquetá", Status = 1 },
                new Departament { Id = 9, Name = "Casanare", Status = 1 },
                new Departament { Id = 10, Name = "Cauca", Status = 1 },
                new Departament { Id = 11, Name = "Cesar", Status = 1 },
                new Departament { Id = 12, Name = "Chocó", Status = 1 },
                new Departament { Id = 13, Name = "Córdoba", Status = 1 },
                new Departament { Id = 14, Name = "Cundinamarca", Status = 1 },
                new Departament { Id = 15, Name = "Guainía", Status = 1 },
                new Departament { Id = 16, Name = "Guaviare", Status = 1 },
                new Departament { Id = 17, Name = "Huila", Status = 1 },
                new Departament { Id = 18, Name = "La Guajira", Status = 1 },
                new Departament { Id = 19, Name = "Magdalena", Status = 1 },
                new Departament { Id = 20, Name = "Meta", Status = 1 },
                new Departament { Id = 21, Name = "Nariño", Status = 1 },
                new Departament { Id = 22, Name = "Norte de Santander", Status = 1 },
                new Departament { Id = 23, Name = "Putumayo", Status = 1 },
                new Departament { Id = 24, Name = "Quindío", Status = 1 },
                new Departament { Id = 25, Name = "Risaralda", Status = 1 },
                new Departament { Id = 26, Name = "San Andrés y Providencia", Status = 1 },
                new Departament { Id = 27, Name = "Santander", Status = 1 },
                new Departament { Id = 28, Name = "Sucre", Status = 1 },
                new Departament { Id = 29, Name = "Tolima", Status = 1 },
                new Departament { Id = 30, Name = "Valle del Cauca", Status = 1 },
                new Departament { Id = 31, Name = "Vaupés", Status = 1 },
                new Departament { Id = 32, Name = "Vichada", Status = 1 }
            );

        }
    }
}
