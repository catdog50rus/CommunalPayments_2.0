namespace CnD.CommunalPayments.Server.Domen.Models;

public class Service
{
    public int Id { get; set; }

    /// <summary>
    /// Наименование услуги ЖКХ
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Предусмотрен ли счетчик услуги
    /// </summary>
    public bool IsCounter { get; set; }
}