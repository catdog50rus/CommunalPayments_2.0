namespace CnD.CommunalPayments.Contracts.Models.Services.Response;

public class CreateServiceResponse
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

public class UpdateServiceResponse
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

public class ServiceResponse
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