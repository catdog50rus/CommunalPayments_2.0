using CnD.CommunalPayments.Server.Dao.Entities.Base;

namespace CnD.CommunalPayments.Server.Dao.Entities.Models;

public class InvoiceEntity : EntityBase
{
    public int PeriodId { get; set; }

    /// <summary>
    /// Период за который выставлен счет
    /// </summary>
    public PeriodEntity Period { get; set; }

    public int ProviderId { get; set; }

    /// <summary>
    /// Id поставщика услуги
    /// </summary>
    public ProviderEntity Provider { get; set; }

    /// <summary>
    /// Сумма счета
    /// </summary>
    public decimal Sum { get; set; }

    public bool Pay { get; set; }
}