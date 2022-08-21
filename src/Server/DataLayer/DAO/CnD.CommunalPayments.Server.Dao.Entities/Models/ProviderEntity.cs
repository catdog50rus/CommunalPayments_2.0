using CnD.CommunalPayments.Server.Dao.Entities.Base;

namespace CnD.CommunalPayments.Server.Dao.Entities.Models;

public class ProviderEntity : EntityBase
{
    /// <summary>
    /// Наименование поставщика услуги ЖКХ
    /// </summary>
    public string NameProvider { get; set; }

    /// <summary>
    /// Путь к личному кабинету поставщика
    /// </summary>
    public string WebSite { get; set; }
}