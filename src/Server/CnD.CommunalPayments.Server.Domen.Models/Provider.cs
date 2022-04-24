namespace CnD.CommunalPayments.Server.Domen.Models;

public class Provider
{
    public int Id { get; set; }

    /// <summary>
    /// Наименование поставщика услуги ЖКХ
    /// </summary>
    public string NameProvider { get; set; }

    /// <summary>
    /// Путь к личному кабинету поставщика
    /// </summary>
    public string WebSite { get; set; }
}