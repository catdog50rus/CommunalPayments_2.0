namespace CnD.CommunalPayments.Server.Domen.Models;

public class Invoice
{
    public int Id { get; set; }

    /// <summary>
    /// Период за который выставлен счет
    /// </summary>
    public Period? Period { get; set; }

    /// <summary>
    /// Id поставщика услуги
    /// </summary>
    public Provider? Provider { get; set; }

    /// <summary>
    /// Сумма счета
    /// </summary>
    public decimal Sum { get; set; }

    public bool IsPaid { get; set; }
}