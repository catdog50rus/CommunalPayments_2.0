using CnD.CommunalPayments.Server.Dao.Entities.Base;

namespace CnD.CommunalPayments.Server.Dao.Entities.Models;

public class InvoiceServicesEntity : EntityBase
{
    public int InvoiceId { get; set; }

    public InvoiceEntity Invoice { get; set; }

    public int ServiceId { get; set; }

    public ServiceEntity Service { get; set; }

    public int Amount { get; set; }
}