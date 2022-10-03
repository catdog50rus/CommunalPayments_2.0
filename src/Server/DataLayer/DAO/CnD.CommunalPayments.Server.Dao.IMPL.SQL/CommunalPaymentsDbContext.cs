using CnD.CommunalPayments.Server.Dao.Entities.Models;
using CnD.CommunalPayments.Server.Dao.IMPL.SQL.Configures;
using Microsoft.EntityFrameworkCore;

namespace CnD.CommunalPayments.Server.Dao.IMPL.SQL;

public class CommunalPaymentsDbContext : DbContext
{
    public DbSet<InvoiceEntity> Invoices { get; set; } = null!;

    public CommunalPaymentsDbContext(DbContextOptions<CommunalPaymentsDbContext> options) : base(options) 
    {
        Database.EnsureCreated();
        //Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InvoiceConfigure).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProviderConfigure).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PeriodConfigure).Assembly);
    }
}