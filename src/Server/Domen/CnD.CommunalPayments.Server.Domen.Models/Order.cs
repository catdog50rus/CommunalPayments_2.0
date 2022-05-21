namespace CnD.CommunalPayments.Server.Domen.Models;

public class Order
{
    public int Id { get; set; }

    public string FileName { get; set; }

    public byte[] OrderScreen { get; set; }
}