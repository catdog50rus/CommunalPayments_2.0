namespace CnD.CommunalPayments.Contracts.Models.Orders.Request;

public class CreateOrderRequest
{
    /// <summary>
    /// Имя файла
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// Скан-образ документа
    /// </summary>
    public byte[] OrderScreen { get; set; }
}

public class UpdateOrderRequest
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Имя файла
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// Скан-образ документа
    /// </summary>
    public byte[] OrderScreen { get; set; }
}
