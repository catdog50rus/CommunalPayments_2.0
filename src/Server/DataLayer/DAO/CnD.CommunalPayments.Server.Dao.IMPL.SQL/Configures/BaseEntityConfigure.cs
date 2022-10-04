using CnD.CommunalPayments.Server.Dao.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CnD.CommunalPayments.Server.Dao.IMPL.SQL.Configures
{
    public abstract class BaseEntityConfigure
    {
        public void Configure(EntityTypeBuilder<EntityBase> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at");
            //builder.Property(x => x.CreatorName).HasColumnName("creator_name");
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
            //builder.Property(x => x.UpdatorName).HasColumnName("updator_name");
        }
    }
}
