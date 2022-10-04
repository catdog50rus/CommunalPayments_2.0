using CnD.CommunalPayments.Server.Domen.Models.Base;

namespace CnD.CommunalPayments.Server.Domen.Models;

/// <summary>
/// Платежка
/// </summary>
public class Order : DomenModelBase
{
    /// <summary>
    /// Имя файла
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// Скан-образ документа
    /// </summary>
    public byte[] OrderScreen { get; set; }
}