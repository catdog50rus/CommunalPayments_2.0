namespace CnD.CommunalPayments.Server.Domen.Models;

public class Payment
{
    public int Id { get; set; }

    /// <summary>
    /// Дата платежа
    /// </summary>
    public string DatePayment { get; set; }

    /// <summary>
    /// Сумма платежа
    /// </summary>
    public decimal PaymentSum { get; set; }
 
    /// <summary>
    /// Счет за ЖКХ
    /// </summary>
    public Invoice Invoice { get; set; }

    /// <summary>
    /// Флаг была ли произведена оплата
    /// </summary>
    public bool Paid { get; set; }

    /// <summary>
    /// Скан платежки
    /// </summary>
    public Order Order { get; set; }
}