namespace CnD.CommunalPayments.Contracts.Models.Orders.Response;

public class CreateOrderResponse
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

public class UpdateOrderResponse
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

public class OrderResponse
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
