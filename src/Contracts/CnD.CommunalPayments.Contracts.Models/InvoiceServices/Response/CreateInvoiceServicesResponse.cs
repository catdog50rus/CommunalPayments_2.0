namespace CnD.CommunalPayments.Contracts.Models.InvoiceServices.Response;

public class CreateInvoiceServicesResponse
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

public class UpdateInvoiceServicesResponse
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


public class InvoiceServicesResponse
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
