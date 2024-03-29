using CnD.CommunalPayments.Server.Dao.Entities.Models;
using CnD.CommunalPayments.Server.Dao.IMPL.InMemory.Configures;
using Microsoft.EntityFrameworkCore;

namespace CnD.CommunalPayments.Server.Dao.IMPL.InMemory;

public class CommunalPaymentsDbContext : DbContext
{
    public DbSet<InvoiceEntity> Invoices { get; set; }
    public DbSet<ProviderEntity> Providers { get; set; }

    public DbSet<PeriodEntity> Periods { get; set; }

    public CommunalPaymentsDbContext(DbContextOptions<CommunalPaymentsDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("CommunalPaymentsInMemmoryDbase");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InvoiceConfigure).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProviderConfigure).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PeriodConfigure).Assembly);
    }
}