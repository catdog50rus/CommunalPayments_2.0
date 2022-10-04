using CnD.CommunalPayments.Server.Domen.Models.Base;
using CnD.CommunalPayments.Server.Domen.Models.BaseModels;

namespace CnD.CommunalPayments.Server.Domen.Models;

/// <summary>
/// Поставщик услуги
/// </summary>
public class Provider : DomenModelBase
{
    /// <summary>
    /// Наименование поставщика услуги ЖКХ
    /// </summary>
    public ServiceName NameProvider { get; set; }

    /// <summary>
    /// Путь к личному кабинету поставщика
    /// </summary>
    public WebSite WebSite { get; set; }
}