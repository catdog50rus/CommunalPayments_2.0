using CnD.CommunalPayments.Server.Domen.Models.Base;
using CnD.CommunalPayments.Server.Domen.Models.BaseModels;

namespace CnD.CommunalPayments.Server.Domen.Models;

/// <summary>
/// Услуга
/// </summary>
public class Service : DomenModelBase
{
    /// <summary>
    /// Наименование услуги ЖКХ
    /// </summary>
    public ServiceName Name { get; set; }

    /// <summary>
    /// Предусмотрен ли счетчик услуги
    /// </summary>
    public bool IsCounter { get; set; }
}