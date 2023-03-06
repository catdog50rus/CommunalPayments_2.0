namespace CnD.CommunalPayments.Front.ViewModels.Invoices;

public class InvoicesListItemViewModel
{
    public int Id { get; set; }

    /// <summary>
    /// Период за который выставлен счет
    /// </summary>
    public string Period { get; set; }

    /// <summary>
    /// Id поставщика услуги
    /// </summary>
    public string  Provider { get; set; }

    /// <summary>
    /// Сумма счета
    /// </summary>
    public decimal Sum { get; set; }

    public bool IsPaid { get; set; }
}