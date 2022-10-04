namespace CnD.CommunalPayments.Contracts.Models.Services.Request;

public class CreateServicesRequest
{
    /// <summary>
    /// Наименование услуги ЖКХ
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Предусмотрен ли счетчик услуги
    /// </summary>
    public bool IsCounter { get; set; }
}

public class UpdateServiceRequest
{
    public int Id { get; set; }

    /// <summary>
    /// Наименование услуги ЖКХ
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Предусмотрен ли счетчик услуги
    /// </summary>
    public bool IsCounter { get; set; }
}
