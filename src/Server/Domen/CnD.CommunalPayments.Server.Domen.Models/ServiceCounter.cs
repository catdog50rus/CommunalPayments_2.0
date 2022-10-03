using CnD.CommunalPayments.Server.Domen.Models.BaseModels;

namespace CnD.CommunalPayments.Server.Domen.Models;

/// <summary>
/// Счетчик услуги
/// </summary>
public class ServiceCounter
{
    /// <summary>
    /// Id
    /// </summary>
    public ModelId Id { get; set; }

    /// <summary>
    /// Услуга
    /// </summary>
    public Service Service { get; set; }

    /// <summary>
    /// Дата передачи показаний
    /// </summary>
    public Date DateCount { get; set; }

    /// <summary>
    /// Количество услуги
    /// </summary>
    public Amount Amount { get; set; }
}