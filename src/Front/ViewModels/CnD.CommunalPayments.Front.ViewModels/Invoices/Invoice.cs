namespace CnD.CommunalPayments.Front.ViewModels.Invoices;

public class Invoice : ModelBase
{
    /// <summary>
    /// Период за который выставлен счет
    /// </summary>
    public ModelId PeriodId { get; set; }

    /// <summary>
    /// Id поставщика услуги
    /// </summary>
    public ModelId ProviderId { get; set; }

    /// <summary>
    /// Сумма счета
    /// </summary>
    public decimal Sum { get; set; }

    public bool IsPaid { get; set; }
}
