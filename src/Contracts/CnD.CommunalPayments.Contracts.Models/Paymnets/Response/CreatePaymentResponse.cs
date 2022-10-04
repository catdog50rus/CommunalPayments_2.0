namespace CnD.CommunalPayments.Contracts.Models.Payments.Response;

public class CreatePaymentResponse
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
    public int InvoiceId { get; set; }

    /// <summary>
    /// Флаг была ли произведена оплата
    /// </summary>
    public bool Paid { get; set; }

    /// <summary>
    /// Платежка
    /// </summary>
    public int OrderId { get; set; }
}

public class UpdatePaymentResponse
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
    public int InvoiceId { get; set; }

    /// <summary>
    /// Флаг была ли произведена оплата
    /// </summary>
    public bool Paid { get; set; }

    /// <summary>
    /// Платежка
    /// </summary>
    public int OrderId { get; set; }
}

public class PaymentResponse
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
    public int InvoiceId { get; set; }

    /// <summary>
    /// Флаг была ли произведена оплата
    /// </summary>
    public bool Paid { get; set; }

    /// <summary>
    /// Платежка
    /// </summary>
    public int OrderId { get; set; }
}
