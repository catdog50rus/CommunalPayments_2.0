using CnD.CommunalPayments.Server.Domen.Models.BaseModels;

namespace CnD.CommunalPayments.Server.Domen.Models;

/// <summary>
/// Поставщик услуги
/// </summary>
public class Provider
{
    /// <summary>
    /// Id
    /// </summary>
    public ModelId Id { get; set; }

    /// <summary>
    /// Наименование поставщика услуги ЖКХ
    /// </summary>
    public ServiceName NameProvider { get; set; }

    /// <summary>
    /// Путь к личному кабинету поставщика
    /// </summary>
    public WebSite WebSite { get; set; }
}