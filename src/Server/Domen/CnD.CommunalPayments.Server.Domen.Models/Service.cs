using CnD.CommunalPayments.Server.Domen.Models.BaseModels;

namespace CnD.CommunalPayments.Server.Domen.Models;

/// <summary>
/// Услуга
/// </summary>
public class Service
{
    /// <summary>
    /// Id
    /// </summary>
    public ModelId Id { get; set; }

    /// <summary>
    /// Наименование услуги ЖКХ
    /// </summary>
    public ServiceName Name { get; set; }

    /// <summary>
    /// Предусмотрен ли счетчик услуги
    /// </summary>
    public bool IsCounter { get; set; }
}