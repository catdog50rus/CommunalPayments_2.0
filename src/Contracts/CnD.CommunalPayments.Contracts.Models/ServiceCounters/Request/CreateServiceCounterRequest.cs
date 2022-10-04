namespace CnD.CommunalPayments.Contracts.Models.ServiceCounters.Request;

public class CreateServiceCounterRequest
{
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

public class UpdateServiceCounterRequest
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
