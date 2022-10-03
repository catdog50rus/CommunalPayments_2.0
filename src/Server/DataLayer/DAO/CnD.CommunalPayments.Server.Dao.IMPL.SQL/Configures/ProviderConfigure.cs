using CnD.CommunalPayments.Server.Dao.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CnD.CommunalPayments.Server.Dao.IMPL.SQL.Configures;

internal class ProviderConfigure : IEntityTypeConfiguration<ProviderEntity>
{
    public void Configure(EntityTypeBuilder<ProviderEntity> builder)
    {
        builder.ToTable("Providers");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at");
        //builder.Property(x => x.CreatorName).HasColumnName("creator_name");
        builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
        //builder.Property(x => x.UpdatorName).HasColumnName("updator_name");
        
        builder.Property(x => x.NameProvider).HasColumnName("name_provider");
        builder.Property(x => x.WebSite).HasColumnName("website");
    }
}