namespace CnD.CommunalPayments.Contracts.Models.ServiceCounters.Response;

public class CreateServiceCounterResponse
{
    public int Id { get; set; }

    /// <summary>
    /// Услуга
    /// </summary>
    public int ServiceId { get; set; }

    /// <summary>
    /// Дата передачи показаний
    /// </summary>
    public string DateCount { get; set; }

    /// <summary>
    /// Количество услуги
    /// </summary>
    public int Amount { get; set; }
}

public class UpdateServiceCounterResponse
{
    public int Id { get; set; }

    /// <summary>
    /// Услуга
    /// </summary>
    public int ServiceId { get; set; }

    /// <summary>
    /// Дата передачи показаний
    /// </summary>
    public string DateCount { get; set; }

    /// <summary>
    /// Количество услуги
    /// </summary>
    public int Amount { get; set; }
}

public class ServiceCounterResponse
{
    public int Id { get; set; }

    /// <summary>
    /// Услуга
    /// </summary>
    public int ServiceId { get; set; }

    /// <summary>
    /// Дата передачи показаний
    /// </summary>
    public string DateCount { get; set; }

    /// <summary>
    /// Количество услуги
    /// </summary>
    public int Amount { get; set; }
}
