
using Entity.Model.Global;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.global
{
    public static class ExtendsModelLongs
    {
        public static void MapBaseModel<T>(this EntityTypeBuilder<T> builder) where T : ABaseEntity
        {
            builder.Property(p => p.CreatedAt).HasColumnName("created_at");
            builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");
            builder.Property(p => p.DeleteAt).HasColumnName("deleted_at");
            builder.Property(p => p.Status)
                .HasColumnName("status")
                .IsRequired();
        }
        
    }
}
