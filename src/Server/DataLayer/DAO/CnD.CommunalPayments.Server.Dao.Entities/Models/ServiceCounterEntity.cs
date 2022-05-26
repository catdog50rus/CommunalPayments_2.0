using CnD.CommunalPayments.Server.Dao.Entities.Base;

namespace CnD.CommunalPayments.Server.Dao.Entities.Models;

public class ServiceCounterEntity : EntityBase
{
    public int ServiceId { get; set; }

    public ServiceEntity Service { get; set; }

    public string DateCount { get; set; }

    public int Value { get; set; }
}