namespace CnD.CommunalPayments.Server.Domen.Models;

public class ServiceCounter
{
    public int Id { get; set; }

    public Service Service { get; set; }

    public string DateCount { get; set; }

    public int Value { get; set; }
}