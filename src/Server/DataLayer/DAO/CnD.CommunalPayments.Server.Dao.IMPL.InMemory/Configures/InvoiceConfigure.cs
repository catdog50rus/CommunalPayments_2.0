using CnD.CommunalPayments.Server.Dao.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CnD.CommunalPayments.Server.Dao.IMPL.InMemory.Configures;

internal class InvoiceConfigure : IEntityTypeConfiguration<InvoiceEntity>
{
    public void Configure(EntityTypeBuilder<InvoiceEntity> builder)
    {
        builder.ToTable("Invoices");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at");
        builder.Property(x => x.CreatorName).HasColumnName("creator_name");
        builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
        builder.Property(x => x.UpdatorName).HasColumnName("updator_name");

        builder.Property(x => x.IsPaid).HasColumnName("is_paid").HasDefaultValue(false);
        builder.Property(x => x.ProviderId).HasColumnName("provider_id");
        builder.Property(x => x.PeriodId).HasColumnName("period_id");
    }
}