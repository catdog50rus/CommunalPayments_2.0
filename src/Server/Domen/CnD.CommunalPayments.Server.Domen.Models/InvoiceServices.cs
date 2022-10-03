using CnD.CommunalPayments.Server.Domen.Models.BaseModels;

namespace CnD.CommunalPayments.Server.Domen.Models;

/// <summary>
/// Услуга в счете
/// </summary>
public class InvoiceServices
{
    /// <summary>
    /// Id
    /// </summary>
    public ModelId Id { get; set; }

    /// <summary>
    /// Счет
    /// </summary>
    public Invoice Invoice { get; set; }

    /// <summary>
    /// Сервис
    /// </summary>
    public Service Service { get; set; }

    /// <summary>
    /// Количсетво услуги
    /// </summary>
    public Amount Amount { get; set; }
}