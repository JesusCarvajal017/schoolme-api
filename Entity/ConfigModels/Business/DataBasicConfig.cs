
using Entity.ConfigModels.global;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Business
{
    public class DataBasicConfig : IEntityTypeConfiguration<DataBasic>
    {
        public void Configure(EntityTypeBuilder<DataBasic> builder)
        {
            builder.ToTable("dataBasic", schema: "business");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();
            builder.Property(p => p.PersonId)
                .HasColumnName("personaId")
                .IsRequired();

            builder.Property(p => p.RhId)
                .HasColumnName("rhId")
                .IsRequired();

            builder.Property(p => p.Adress)
                .HasColumnName("adress")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.BrithDate)
                .HasColumnName("birthDate")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.StratumStatus)
                .HasColumnName("stratumStatus")
                .IsRequired();

            builder.Property(p => p.MaterialStatusId)
                .HasColumnName("materialStatusId")
                .IsRequired();

            builder.Property(p => p.EpsId)
                .HasColumnName("epsId")
                .IsRequired();

            builder.Property(p => p.MunisipalityId)
                .HasColumnName("munisipalityId")
                .IsRequired();

            builder.HasIndex(p => p.PersonId).IsUnique();

            // Llaves foraenas
            builder.HasOne(db => db.Person)       
             .WithOne(p => p.DataBasic)     
             .HasForeignKey<DataBasic>(db => db.PersonId)  
             .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ur => ur.Rh)
              .WithMany(r => r.DataBasics)
              .HasForeignKey(ur => ur.RhId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ur => ur.Eps)
              .WithMany(r => r.DataBasics)
              .HasForeignKey(ur => ur.EpsId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ur => ur.Munisipality)
              .WithMany(r => r.DataBasics)
              .HasForeignKey(ur => ur.MunisipalityId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ur => ur.MaterialStatus)
              .WithMany(r => r.DataBasic)
              .HasForeignKey(ur => ur.MaterialStatusId)
              .OnDelete(DeleteBehavior.Restrict);


            builder.MapBaseModel();

            
            builder.HasData(
                new DataBasic
                {
                    Id = 1,
                    PersonId = 1,
                    RhId = 1,
                    Adress = "Calle 10 #15-20",
                    BrithDate = new DateTime(1993, 05, 12),
                    StratumStatus = 3,
                    MaterialStatusId = 1,
                    EpsId = 1,
                    MunisipalityId = 200,
                    Status = 1
                },
                new DataBasic
                {
                    Id = 2,
                    PersonId = 2,
                    RhId = 2,
                    Adress = "Carrera 25 #8-30",
                    BrithDate = new DateTime(2000, 11, 03),
                    StratumStatus = 4,
                    MaterialStatusId = 2,
                    EpsId = 1,
                    MunisipalityId = 200,
                    Status = 1
                },
                new DataBasic
                {
                    Id = 3,
                    PersonId = 3,
                    RhId = 3,
                    Adress = "Diagonal 45 #20-15",
                    BrithDate = new DateTime(1993, 05, 12),
                    StratumStatus = 2,
                    MaterialStatusId = 2,
                    EpsId = 1,
                    MunisipalityId = 200,
                    Status = 1
                },
                new DataBasic
                {
                    Id = 4,
                    PersonId = 4,
                    RhId = 1,
                    Adress = "Avenida 7 #12-45",
                    BrithDate = new DateTime(1993, 05, 12),
                    StratumStatus = 5,
                    MaterialStatusId = 1,
                    EpsId = 1,
                    MunisipalityId = 200,
                    Status = 1
                },
                new DataBasic
                {
                    Id = 5,
                    PersonId = 5,
                    RhId = 2,
                    Adress = "Calle 50 #25-18",
                    BrithDate = new DateTime(1993, 05, 12),
                    StratumStatus = 3,
                    MaterialStatusId = 2,
                    EpsId = 1,
                    MunisipalityId = 200,
                    Status = 1
                }
            );


        }
    }
}
