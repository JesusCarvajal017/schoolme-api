using Entity.ConfigModels.global;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Business
{
    public class GroupDirectorConfig : IEntityTypeConfiguration<GroupDirector>
    {
        public void Configure(EntityTypeBuilder<GroupDirector> builder)
        {
            builder.ToTable("group_director", schema: "business");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(x => x.TeacherId)
                   .HasColumnName("teacher_id")
                   .IsRequired();

            builder.Property(x => x.GroupId)
                   .HasColumnName("group_id")
                   .IsRequired();

            // Auditoría/estado de ABaseEntity (created_at, updated_at, status, etc.)
            builder.MapBaseModel();

            builder.HasOne(x => x.Teacher)
                   .WithMany(t => t.GroupDirector)          // colección ya la tienes en Teacher
                   .HasForeignKey(x => x.TeacherId)
                   .HasConstraintName("fk_group_director_teacher")
                   .OnDelete(DeleteBehavior.Restrict);

            // 1:1 Group <-> GroupDirector (PK-FK compartida)
            builder.HasOne(x => x.Groups)
                   .WithOne(g => g.GroupDirector)
                   .HasForeignKey<GroupDirector>(x => x.GroupId)
                   .HasConstraintName("fk_group_director_group")
                   .OnDelete(DeleteBehavior.Restrict); // si se borra el grupo, se borra su registro de director

            


        }
    }
}