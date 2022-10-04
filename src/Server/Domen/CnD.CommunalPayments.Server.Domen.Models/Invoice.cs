using CnD.CommunalPayments.Server.Domen.Models.Base;
using CnD.CommunalPayments.Server.Domen.Models.BaseModels;

namespace CnD.CommunalPayments.Server.Domen.Models;

/// <summary>
/// Счет на услуги
/// </summary>
public class Invoice : DomenModelBase
{
    /// <summary>
    /// Период за который выставлен счет
    /// </summary>
    public Period Period { get; set; }

    /// <summary>
    /// Id поставщика услуги
    /// </summary>
    public Provider Provider { get; set; }

    /// <summary>
    /// Сумма счета
    /// </summary>
    public Sum Sum { get; set; }

    /// <summary>
    /// Флаг, оплачен ли счет
    /// </summary>
    public bool IsPaid { get; set; }
}