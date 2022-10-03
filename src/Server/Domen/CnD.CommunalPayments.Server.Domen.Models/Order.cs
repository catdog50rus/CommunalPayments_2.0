using CnD.CommunalPayments.Server.Domen.Models.BaseModels;

namespace CnD.CommunalPayments.Server.Domen.Models;

/// <summary>
/// Платежка
/// </summary>
public class Order
{
    /// <summary>
    /// Id
    /// </summary>
    public ModelId Id { get; set; }

    /// <summary>
    /// Имя файла
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// Скан-образ документа
    /// </summary>
    public byte[] OrderScreen { get; set; }
}