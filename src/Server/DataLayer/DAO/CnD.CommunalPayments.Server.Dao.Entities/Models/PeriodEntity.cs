using CnD.CommunalPayments.Server.Dao.Entities.Base;

namespace CnD.CommunalPayments.Server.Dao.Entities.Models;

public class PeriodEntity : EntityBase
{
    public string Year { get; set; }

    public string Month { get; set; }
}