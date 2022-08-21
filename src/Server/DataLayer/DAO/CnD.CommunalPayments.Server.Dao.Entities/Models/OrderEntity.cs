using CnD.CommunalPayments.Server.Dao.Entities.Base;

namespace CnD.CommunalPayments.Server.Dao.Entities.Models;

public class OrderEntity : EntityBase
{
    public string FileName { get; set; }

    public byte[] OrderScreen { get; set; }
}