using CnD.CommunalPayments.Server.Dao.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CnD.CommunalPayments.Server.Dao.IMPL.SQL.Configures;

internal class PeriodConfigure : BaseEntityConfigure, IEntityTypeConfiguration<PeriodEntity>
{
    public void Configure(EntityTypeBuilder<PeriodEntity> builder)
    {
        builder.ToTable("Periods");

        //builder.HasKey(x => x.Id);

        //builder.Property(x => x.Id).HasColumnName("id");
        //builder.Property(x => x.CreatedAt).HasColumnName("created_at");
        ////builder.Property(x => x.CreatorName).HasColumnName("creator_name");
        //builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
        ////builder.Property(x => x.UpdatorName).HasColumnName("updator_name");

        builder.Property(x => x.Month).HasColumnName("month").HasMaxLength(8);
        builder.Property(x => x.Year).HasColumnName("year").HasMaxLength(4);
    }
}