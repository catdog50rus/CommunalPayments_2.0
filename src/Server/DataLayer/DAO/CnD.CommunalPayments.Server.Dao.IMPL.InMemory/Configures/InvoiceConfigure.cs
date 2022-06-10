using CnD.CommunalPayments.Server.Dao.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnD.CommunalPayments.Server.Dao.IMPL.InMemory.Configures
{
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


        }
    }
}
