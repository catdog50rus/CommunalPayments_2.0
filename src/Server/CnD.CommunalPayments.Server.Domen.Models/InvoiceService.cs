namespace CnD.CommunalPayments.Server.Domen.Models;

public class InvoiceService
{
    public int Id { get; set; }

    public Invoice Invoice { get; set; }

    public Service Service { get; set; }

    public int Amount { get; set; }
}