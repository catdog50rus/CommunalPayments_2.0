namespace CnD.CommunalPayments.Server.Dao.Entities.Base;

public abstract class EntityBase
{
    public int Id { get; set; }

    public string CreatorName { get; set; }

    public string UpdatorName { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}