using CnD.CommunalPayments.Server.Domen.Models.Base;
using CnD.CommunalPayments.Server.Domen.Models.BaseModels;

namespace CnD.CommunalPayments.Server.Domen.Models;

/// <summary>
/// Оплата
/// </summary>
public class Payment : DomenModelBase
{
    /// <summary>
    /// Дата платежа
    /// </summary>
    public Date DatePayment { get; set; }

    /// <summary>
    /// Сумма платежа
    /// </summary>
    public Sum PaymentSum { get; set; }
 
    /// <summary>
    /// Счет за ЖКХ
    /// </summary>
    public Invoice Invoice { get; set; }

    /// <summary>
    /// Флаг была ли произведена оплата
    /// </summary>
    public bool Paid { get; set; }

    /// <summary>
    /// Платежка
    /// </summary>
    public Order Order { get; set; }
}