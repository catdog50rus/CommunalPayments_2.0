using CnD.CommunalPayments.Server.Domen.Models.Base;
using CnD.CommunalPayments.Server.Domen.Models.BaseModels;

namespace CnD.CommunalPayments.Server.Domen.Models;

/// <summary>
/// Счетчик услуги
/// </summary>
public class ServiceCounter : DomenModelBase
{
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