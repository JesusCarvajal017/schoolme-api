using Entity.ConfigModels.global;
using Entity.Enum;
using Entity.Model.Paramters;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Parameters
{
    public class DocumentTypeConfig : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.ToTable("documentType", schema: "parameters");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();
            builder.Property(p => p.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Acronym)
                .IsRequired()
                .HasMaxLength(5);

            builder.MapBaseModel();

            builder.HasData
            (
               new DocumentType
               {
                   Id = 1,
                   Name = "Cedula Ciudadana",
                   Acronym = "C.C", 
                   Status = 1

               },
              new DocumentType
              {
                  Id = 2,
                  Name = "Targeta de identidad",
                  Acronym = "T.I",
                  Status = 1

              },
               new DocumentType
               {
                   Id = 3,
                   Name = "Registro civil",
                   Acronym = "R.C",
                   Status = 1

               }

            );

        }
    }
}
