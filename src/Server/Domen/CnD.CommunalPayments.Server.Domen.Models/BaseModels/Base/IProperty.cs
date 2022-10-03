namespace CnD.CommunalPayments.Server.Domen.Models.BaseModels.Base;

public interface IProperty<TValue>
{
    TValue Value { get; }

    TValue GetValue();
}
