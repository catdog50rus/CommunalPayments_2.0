using CnD.CommunalPayments.Server.Domen.Models.BaseModels;

namespace CnD.CommunalPayments.Server.Domen.Models.Base;

public abstract class DomenModelBase : IDomenModel
{
    public ModelId Id { get; set; }
}
