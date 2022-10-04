using CnD.CommunalPayments.Server.Dao.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CnD.CommunalPayments.Server.Dao.IMPL.SQL.Configures
{
    public class InvoiceServiceConfigure : BaseEntityConfigure, IEntityTypeConfiguration<InvoiceServicesEntity>
    {
        public void Configure(EntityTypeBuilder<InvoiceServicesEntity> builder)
        {
            builder.ToTable("InvoiceServices");

            builder.Property(x => x.InvoiceId).HasColumnName("InvoiceId");
            builder.Property(x => x.ServiceId).HasColumnName("ServiceId");
            builder.Property(x => x.Amount).HasColumnName("Amount");

            builder.HasOne(x => x.Invoice);
            builder.HasOne(x => x.Service);
        }
    }

    public class OrderConfigure : BaseEntityConfigure, IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable("Orders");

            builder.Property(x => x.FileName).HasColumnName("FileName");
            builder.Property(c => c.OrderScreen).HasColumnName("OrderScreen");
        }
    }

    public class PaymentConfigure : BaseEntityConfigure, IEntityTypeConfiguration<PaymentEntity>
    {
        public void Configure(EntityTypeBuilder<PaymentEntity> builder)
        {
            builder.ToTable("Payments");

            builder.Property(x => x.DatePayment).HasColumnName("DatePayment");
            builder.Property(x => x.PaymentSum).HasColumnName("PaymentSum");
            builder.Property(x => x.InvoiceId).HasColumnName("InvoiceId");
            builder.Property(x => x.OrderId).HasColumnName("OrderId");
            builder.Property(x => x.Paid).HasColumnName("Paid");

            builder.HasOne(x => x.Invoice);
            builder.HasOne(x => x.Order).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class ServiceCounterConfigure : BaseEntityConfigure, IEntityTypeConfiguration<ServiceCounterEntity>
    {
        public void Configure(EntityTypeBuilder<ServiceCounterEntity> builder)
        {
            builder.ToTable("ServiceCounters");

            builder.Property(x => x.Value).HasColumnName("Value");
            builder.Property(x => x.DateCount).HasColumnName("DateCount");
            builder.Property(x => x.ServiceId).HasColumnName("ServiceId");

            builder.HasOne(x => x.Service);
        }
    }

    public class ServiceConfigure : BaseEntityConfigure, IEntityTypeConfiguration<ServiceEntity>
    {
        public void Configure(EntityTypeBuilder<ServiceEntity> builder)
        {
            builder.ToTable("Services");

            builder.Property(x => x.IsCounter).HasColumnName("IsCounter");
            builder.Property(x => x.Name).HasColumnName("ServiceName");
        }
    }
}
