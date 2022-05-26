using CnD.CommunalPayments.Server.Dao.Entities.Base;

namespace CnD.CommunalPayments.Server.Dao.Entities.Models;

public class PaymentEntity : EntityBase
{
    /// <summary>
    /// Дата платежа
    /// </summary>
    public string DatePayment { get; set; }

    /// <summary>
    /// Сумма платежа
    /// </summary>
    public decimal PaymentSum { get; set; }

    public int InvoiceId { get; set; }

    /// <summary>
    /// Счет за ЖКХ
    /// </summary>
    public InvoiceEntity Invoice { get; set; }

    /// <summary>
    /// Флаг была ли произведена оплата
    /// </summary>
    public bool Paid { get; set; }

    public int OrderId { get; set; }

    /// <summary>
    /// Скан платежки
    /// </summary>
    public OrderEntity Order { get; set; }
}