namespace CnD.CommunalPayments.Contracts.Models.InvoiceServices.Request;

public class CreateInvoiceServicesRequest
{
    /// <summary>
    /// Счет
    /// </summary>
    public int InvoiceId { get; set; }

    /// <summary>
    /// Сервис
    /// </summary>
    public int ServiceId { get; set; }

    /// <summary>
    /// Количсетво услуги
    /// </summary>
    public int Amount { get; set; }
}

public class UpdateInvoiceServicesRequest
{
    public int Id { get; set; }

    /// <summary>
    /// Счет
    /// </summary>
    public int InvoiceId { get; set; }

    /// <summary>
    /// Сервис
    /// </summary>
    public int ServiceId { get; set; }

    /// <summary>
    /// Количсетво услуги
    /// </summary>
    public int Amount { get; set; }
}
